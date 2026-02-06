using HwpLib.Reader;
using HwpLib.Tool.ObjectFinder;
using HwpLib.Tool.TextExtractor;

namespace HwpLibSharp.Test;

/// <summary>
/// 누름틀 필드 컨트롤의 텍스트를 구하는 테스트
/// </summary>
[TestClass]
public class GettingClickHereFieldTextTest
{
    [TestMethod]
    public void GetClickHereFieldText_ShouldSucceed()
    {
        // Arrange
        var filePath = TestHelper.GetSamplePath("getting_clickhere_text.hwp");
        var hwpFile = HWPReader.FromFile(filePath);

        Assert.IsNotNull(hwpFile);

        // Act
        var text1 = FieldFinder.GetClickHereText(hwpFile, "필드1"/*, TextExtractMethod.OnlyMainParagraph*/);
        var text2 = FieldFinder.GetClickHereText(hwpFile, "필드2"/*, TextExtractMethod.OnlyMainParagraph*/);
        var text3 = FieldFinder.GetClickHereText(hwpFile, "Table필드1"/*, TextExtractMethod.OnlyMainParagraph*/);
        var text4 = FieldFinder.GetClickHereText(hwpFile, "멀티라인누름틀"/*, TextExtractMethod.OnlyMainParagraph*/);
        var text5 = FieldFinder.GetClickHereText(hwpFile, "xxx"/*, TextExtractMethod.OnlyMainParagraph*/);
        var longText = FieldFinder.GetClickHereText(hwpFile, "long"/*, TextExtractMethod.OnlyMainParagraph*/);

        // Assert
        Console.WriteLine($"필드1 ==> {text1}");
        Console.WriteLine($"필드2 ==> {text2}");
        Console.WriteLine($"Table필드1 ==> {text3}");
        Console.WriteLine($"멀티라인누름틀 ==> {text4}");
        Console.WriteLine($"xxx ==> {text5}");
        Console.WriteLine($"long ==> {longText}");

        Assert.IsNotNull(text1, "필드1 텍스트 가져오기 성공");
    }
}
