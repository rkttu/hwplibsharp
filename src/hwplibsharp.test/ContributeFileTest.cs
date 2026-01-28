using HwpLib.Reader;
using HwpLib.Tool.TextExtractor;

namespace HwpLibSharp.Test;

/// <summary>
/// Contribute 디렉터리의 파일 읽기 테스트 (이슈 #7 관련)
/// </summary>
[TestClass]
public class ContributeFileTest
{
    /// <summary>
    /// Contribute 샘플 HWP 파일의 전체 경로를 반환합니다.
    /// </summary>
    private static string GetContributeSamplePath(string filename)
    {
        return Path.Combine(TestHelper.GetProjectRoot(), "sample_hwp", "contribute", filename);
    }

    [TestMethod]
    [Timeout(30000, CooperativeCancellation = true)] // 30초 타임아웃
    [DataRow("KTX.hwp")]
    [DataRow("디지털 증거 수집 및 처리 등에 관한 규칙 일부개정규칙안.hwp")]
    public void ReadContributeFile_ShouldNotHang(string filename)
    {
        // Arrange
        var filePath = GetContributeSamplePath(filename);

        // Act
        var hwpFile = HWPReader.FromFile(filePath);

        // Assert
        Assert.IsNotNull(hwpFile);
        Assert.IsNotEmpty(hwpFile.BodyText.SectionList, $"{filename} 읽기 성공");
    }

    [TestMethod]
    [Timeout(30000, CooperativeCancellation = true)] // 30초 타임아웃
    [DataRow("KTX.hwp")]
    [DataRow("디지털 증거 수집 및 처리 등에 관한 규칙 일부개정규칙안.hwp")]
    public void ExtractTextFromContributeFile_ShouldNotHang(string filename)
    {
        // Arrange
        var filePath = GetContributeSamplePath(filename);

        // Act
        var hwpFile = HWPReader.FromFile(filePath);

        var option = new TextExtractOption();
        option.SetMethod(TextExtractMethod.OnlyMainParagraph);
        option.SetWithControlChar(false);
        option.SetAppendEndingLF(true);

        var extractedText = TextExtractor.Extract(hwpFile, option);

        // Assert
        Assert.IsNotNull(extractedText);
    }
}
