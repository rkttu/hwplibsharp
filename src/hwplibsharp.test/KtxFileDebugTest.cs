using HwpLib.CompoundFile;
using HwpLib.Object.BodyText;
using HwpLib.Object.DocInfo;
using HwpLib.Reader.BodyText;
using HwpLib.Reader.DocInfo;

namespace HwpLibSharp.Test;

/// <summary>
/// KTX.hwp 파일 디버깅용 테스트
/// </summary>
[TestClass]
public class KtxFileDebugTest
{
    private static string GetContributeSamplePath(string filename)
    {
        return Path.Combine(TestHelper.GetProjectRoot(), "sample_hwp", "contribute", filename);
    }

    [TestMethod]
    [Timeout(30000, CooperativeCancellation = true)]
    public void ReadKtxFileHeader_ShouldNotHang()
    {
        // Arrange
        var filePath = GetContributeSamplePath("KTX.hwp");
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var cfr = new CompoundFileReader(stream);

        // FileHeader 읽기
        using var sr = cfr.GetChildStreamReader("FileHeader", false, null);
        var fileHeader = new HwpLib.Object.FileHeader.FileHeader();
        HwpLib.Reader.ForFileHeader.Read(fileHeader, sr);

        // Assert
        Assert.IsNotNull(fileHeader);
        Console.WriteLine($"Version: {fileHeader.Version}");
        Console.WriteLine($"Compressed: {fileHeader.Compressed}");
    }

    [TestMethod]
    [Timeout(30000, CooperativeCancellation = true)]
    public void ReadKtxDocInfo_ShouldNotHang()
    {
        // Arrange
        var filePath = GetContributeSamplePath("KTX.hwp");
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var cfr = new CompoundFileReader(stream);

        // FileHeader 읽기
        using var srHeader = cfr.GetChildStreamReader("FileHeader", false, null);
        var fileHeader = new HwpLib.Object.FileHeader.FileHeader();
        HwpLib.Reader.ForFileHeader.Read(fileHeader, srHeader);

        // DocInfo 읽기
        using var sr = cfr.GetChildStreamReader("DocInfo", fileHeader.Compressed, fileHeader.Version);
        var docInfo = new DocInfo();
        new ForDocInfo().Read(docInfo, sr);

        // Assert
        Assert.IsNotNull(docInfo);
        Console.WriteLine($"FaceNames: {docInfo.HangulFaceNameList.Count}");
    }

    [TestMethod]
    [Timeout(60000, CooperativeCancellation = true)]
    public void ReadKtxBodyText_ShouldNotHang()
    {
        // Arrange
        var filePath = GetContributeSamplePath("KTX.hwp");
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var cfr = new CompoundFileReader(stream);

        // FileHeader 읽기
        using var srHeader = cfr.GetChildStreamReader("FileHeader", false, null);
        var fileHeader = new HwpLib.Object.FileHeader.FileHeader();
        HwpLib.Reader.ForFileHeader.Read(fileHeader, srHeader);

        // BodyText 읽기
        if (cfr.IsChildStorage("BodyText"))
        {
            cfr.MoveChildStorage("BodyText");

            var sectionNames = cfr.ListChildNames()
                .Where(name => name.StartsWith("Section"))
                .OrderBy(name =>
                {
                    string numPart = name.Substring("Section".Length);
                    return int.TryParse(numPart, out int num) ? num : 0;
                })
                .ToList();

            Console.WriteLine($"Found {sectionNames.Count} sections");

            foreach (var sectionName in sectionNames)
            {
                Console.WriteLine($"Reading section: {sectionName}");
                using var sr = cfr.GetChildStreamReader(sectionName, fileHeader.Compressed, fileHeader.Version);
                Console.WriteLine($"Section stream size: {sr.Size}");

                // 레코드 수 카운트
                int recordCount = 0;
                while (!sr.IsEndOfStream())
                {
                    if (!sr.ReadRecordHeader())
                        break;

                    recordCount++;
                    sr.SkipToEndRecord();

                    // 무한 루프 방지
                    if (recordCount > 100000)
                    {
                        Console.WriteLine("Too many records - possible infinite loop");
                        break;
                    }
                }
                Console.WriteLine($"Section {sectionName} has {recordCount} records");
            }

            cfr.MoveParentStorage();
        }
    }

    [TestMethod]
    [Timeout(120000, CooperativeCancellation = true)]
    public void ReadKtxSection_WithForSection_ShouldNotHang()
    {
        // Arrange
        var filePath = GetContributeSamplePath("KTX.hwp");
        using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        using var cfr = new CompoundFileReader(stream);

        // FileHeader 읽기
        using var srHeader = cfr.GetChildStreamReader("FileHeader", false, null);
        var fileHeader = new HwpLib.Object.FileHeader.FileHeader();
        HwpLib.Reader.ForFileHeader.Read(fileHeader, srHeader);

        // BodyText 읽기
        if (cfr.IsChildStorage("BodyText"))
        {
            cfr.MoveChildStorage("BodyText");

            using var sr = cfr.GetChildStreamReader("Section0", fileHeader.Compressed, fileHeader.Version);
            Console.WriteLine($"Section0 stream size: {sr.Size}");

            var section = new Section();
            var forSection = new ForSection();
            forSection.Read(section, sr);

            Console.WriteLine($"Paragraphs in section: {section.ParagraphCount}");

            cfr.MoveParentStorage();
        }
    }
}
