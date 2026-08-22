using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo.BorderFill.FillInfo;
using HwpLib.Object.FileHeader;
using OpenMcdf;
using ReaderForFillInfo = HwpLib.Reader.DocInfo.BorderFill.ForFillInfo;
using WriterForFillInfo = HwpLib.Writer.DocInfo.BorderFill.ForFillInfo;

namespace HwpLibSharp.Test;

/// <summary>
/// 이슈 #17의 업스트림 변경과 후속 롤백 이후 PictureInfo 필드 순서를 검증한다.
/// 최신 Java 구현은 모든 사용처에서 contrast, brightness 순서를 공통으로 사용한다.
/// </summary>
[TestClass]
public class PictureInfoSerializationTest
{
    private static readonly byte[] SerializedPictureInfo =
    {
        0xEF, // contrast: -17
        0x2A, // brightness: 42
        0x02, // effect: BlackWhite
        0x34, 0x12, // BinItemID: 0x1234 (little endian)
    };

    [TestMethod]
    public void PictureInfoWriter_ShouldWriteContrastBeforeBrightness()
    {
        // Arrange
        var pictureInfo = new PictureInfo
        {
            Contrast = -17,
            Brightness = 42,
            Effect = PictureEffect.BlackWhite,
            BinItemID = 0x1234,
        };
        var writer = new CompoundStreamWriter("PictureInfo", false, CreateFileVersion());

        // Act
        WriterForFillInfo.PictureInfo(pictureInfo, writer);
        var bytes = writer.GetDataBytes();
        writer.Close();

        // Assert
        CollectionAssert.AreEqual(SerializedPictureInfo, bytes);
    }

    [TestMethod]
    public void PictureInfoReader_ShouldReadContrastBeforeBrightness()
    {
        // Arrange
        using var rootStorage = RootStorage.CreateInMemory();
        using var stream = rootStorage.CreateStream("PictureInfo");
        stream.Write(SerializedPictureInfo, 0, SerializedPictureInfo.Length);
        stream.Position = 0;

        using var reader = CompoundStreamReader.Create(
            new StreamWrapper(stream),
            false,
            false,
            CreateFileVersion());
        var pictureInfo = new PictureInfo();

        // Act
        ReaderForFillInfo.ReadPictureInfo(pictureInfo, reader);

        // Assert
        Assert.AreEqual((sbyte)-17, pictureInfo.Contrast);
        Assert.AreEqual((sbyte)42, pictureInfo.Brightness);
        Assert.AreEqual(PictureEffect.BlackWhite, pictureInfo.Effect);
        Assert.AreEqual(0x1234, pictureInfo.BinItemID);
    }

    private static FileVersion CreateFileVersion()
    {
        var version = new FileVersion();
        version.SetVersion(5, 1, 0, 0);
        return version;
    }
}
