using HwpLib.Object.BodyText.Control;
using HwpLib.Reader;
using HwpLib.Tool.ObjectFinder;
using HwpLib.Tool.TextExtractor;

namespace HwpLibSharp.Test;

/// <summary>
/// 파일에 있는 모든 필드 컨트롤의 텍스트를 찾는 테스트
/// </summary>
[TestClass]
public class FindingAllFieldTest
{
    [TestMethod]
    public void FindAllClickHereField_ShouldSucceed()
    {
        // Arrange
        var filePath = TestHelper.GetSamplePath("finding-all-field.hwp");
        var hwpFile = HWPReader.FromFile(filePath);

        Assert.IsNotNull(hwpFile);

        // Act - 필드A의 모든 누름틀 텍스트 찾기
        var result = FieldFinder.GetAllClickHereText(hwpFile, "필드A"/*, TextExtractMethod.OnlyMainParagraph*/);

        // Assert
        Assert.IsNotNull(result);
        foreach (var text in result)
        {
            Console.WriteLine($"\"필드A\"= {text}");
        }
    }

    [TestMethod]
    public void FindAllFieldByControlType_ShouldSucceed()
    {
        // Arrange
        var filePath = TestHelper.GetSamplePath("finding-all-field.hwp");
        var hwpFile = HWPReader.FromFile(filePath);

        Assert.IsNotNull(hwpFile);

        // Act - 필드B의 모든 누름틀 텍스트 찾기
        var result = FieldFinder.GetAllFieldText(hwpFile, ControlType.FIELD_CLICKHERE, "필드B"/*, TextExtractMethod.OnlyMainParagraph*/);

        // Assert
        Assert.IsNotNull(result);
        foreach (var text in result)
        {
            Console.WriteLine($"\"필드B\" = {text}");
        }
    }
}
