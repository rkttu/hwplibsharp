using HwpLib.CompoundFile;
using HwpLib.Object.BodyText.Control;
using HwpLib.Object.BodyText.Control.CtrlHeader;
using HwpLib.Object.Etc;
using HwpLib.Object.FileHeader;
using OpenMcdf;
using ReaderForCtrlHeaderGso = HwpLib.Reader.BodyText.Control.Gso.Part.ForCtrlHeaderGso;

namespace HwpLibSharp.Test;

[TestClass]
public class CtrlHeaderGsoReadingTest
{
    [TestMethod]
    [DataRow(new byte[] { }, false, null)]
    [DataRow(new byte[] { 0, 0 }, false, "")]
    [DataRow(new byte[] { 1, 0, 0, 0xAC }, false, "가")]
    [DataRow(new byte[] { 1, 0, 0, 0, 0, 0 }, true, "")]
    [DataRow(new byte[] { 0, 0, 0, 0, 1, 0, 0, 0xAC }, false, "가")]
    [DataRow(new byte[] { 1, 0, 0, 0, 1, 0, 0, 0xAC }, true, "가")]
    public void ReadOptionalFields_ShouldPreserveNextRecord(
        byte[] optionalFields, bool preventPageDivide, string? explanation)
    {
        ReadAndAssert(optionalFields, preventPageDivide, explanation, null);
    }

    [TestMethod]
    public void ReadOptionalFields_ShouldPreserveUnknownTrailingBytes()
    {
        ReadAndAssert(
            new byte[] { 1, 0, 0, 0, 1, 0, 0, 0xAC, 0xDE, 0xAD, 0xBE, 0xEF },
            true, "가", new byte[] { 0xDE, 0xAD, 0xBE, 0xEF });
    }

    private static void ReadAndAssert(
        byte[] optionalFields, bool preventPageDivide, string? explanation, byte[]? unknown)
    {
        // A preceding record makes the absolute stream offset differ from the
        // number of bytes consumed within CTRL_HEADER (unlike Java's accessor).
        using var bytes = new MemoryStream();
        using (var writer = new BinaryWriter(bytes, System.Text.Encoding.Unicode, leaveOpen: true))
        {
            writer.Write((uint)(HWPTag.ParaText | (64 << 20)));
            writer.Write(new byte[64]);
            writer.Write((uint)(HWPTag.CtrlHeader | (1 << 10) | ((40 + optionalFields.Length) << 20)));
            writer.Write(ControlType.Table.GetCtrlId());
            writer.Write(0x12345678u); // property
            writer.Write(100u); // yOffset
            writer.Write(200u); // xOffset
            writer.Write(300u); // width
            writer.Write(400u); // height
            writer.Write(-5); // zOrder
            writer.Write((ushort)10);
            writer.Write((ushort)20);
            writer.Write((ushort)30);
            writer.Write((ushort)40);
            writer.Write(0x87654321u); // instanceId
            writer.Write(optionalFields);
            writer.Write((uint)(HWPTag.ParaText | (2 << 10) | (4 << 20)));
            writer.Write(0xDEADBEEFu);
        }

        using var storage = RootStorage.CreateInMemory();
        using var stream = storage.CreateStream("Section0");
        var data = bytes.ToArray();
        stream.Write(data, 0, data.Length);
        stream.Position = 0;
        var version = new FileVersion();
        version.SetVersion(5, 1, 0, 0);
        using var reader = CompoundStreamReader.Create(new StreamWrapper(stream), false, false, version);

        Assert.IsTrue(reader.ReadRecordHeader());
        reader.SkipToEndRecord();
        Assert.IsTrue(reader.ReadRecordHeader());
        Assert.AreEqual(ControlType.Table.GetCtrlId(), reader.ReadUInt4());
        var header = new CtrlHeaderGso(ControlType.Table);

        ReaderForCtrlHeaderGso.Read(header, reader);

        Assert.AreEqual(0x12345678u, header.Property.Value);
        Assert.AreEqual(100u, header.YOffset);
        Assert.AreEqual(200u, header.XOffset);
        Assert.AreEqual(300u, header.Width);
        Assert.AreEqual(400u, header.Height);
        Assert.AreEqual(-5, header.ZOrder);
        Assert.AreEqual(10, header.OutterMarginLeft);
        Assert.AreEqual(20, header.OutterMarginRight);
        Assert.AreEqual(30, header.OutterMarginTop);
        Assert.AreEqual(40, header.OutterMarginBottom);
        Assert.AreEqual(0x87654321u, header.InstanceId);
        Assert.AreEqual(preventPageDivide, header.PreventPageDivide);
        Assert.AreEqual(explanation, header.Explanation.ToUTF16LEString());
        if (unknown == null)
            Assert.IsNull(header.Unknown);
        else
            CollectionAssert.AreEqual(unknown, header.Unknown);

        Assert.AreEqual(0L, reader.RemainingBytes);
        Assert.IsTrue(reader.ReadRecordHeader());
        Assert.AreEqual((ushort)HWPTag.ParaText, reader.CurrentRecordHeader!.TagId);
        Assert.AreEqual((ushort)2, reader.CurrentRecordHeader.Level);
        Assert.AreEqual(4u, reader.CurrentRecordHeader.Size);
        Assert.AreEqual(0xDEADBEEFu, reader.ReadUInt4());
        Assert.IsTrue(reader.IsEndOfStream());
    }
}
