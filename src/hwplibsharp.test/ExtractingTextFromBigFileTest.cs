using HwpLib.Reader;
using HwpLib.Tool.TextExtractor;

namespace HwpLibSharp.Test;

/// <summary>
/// 큰 파일에서 텍스트 추출 테스트
/// </summary>
[TestClass]
public class ExtractingTextFromBigFileTest
{
    private class MyListener : ITextExtractorListener
    {
        private readonly System.Text.StringBuilder _sb = new();
        
        public void ParagraphText(string text)
        {
            _sb.Append(text);
            Console.Write(text);
        }
        
        public string GetText() => _sb.ToString();
    }

    [TestMethod]
    public void ExtractTextFromBigFile_ShouldSucceed()
    {
        // Arrange
        var filePath = TestHelper.GetSamplePath("big_file.hwp");
        var listener = new MyListener();
        
        // Act
        // TODO: HWPReader.ForExtractText() 메서드가 라이브러리에 구현되면 활성화
        // HWPReader.ForExtractText(filePath, listener, TextExtractMethod.InsertControlTextBetweenParagraphText);
        
        // 대체 구현: 일반 로드 후 텍스트 추출
        var hwpFile = HWPReader.FromFile(filePath);
        var option = new TextExtractOption();
        option.SetMethod(TextExtractMethod.InsertControlTextBetweenParagraphText);
        var extractedText = TextExtractor.Extract(hwpFile, option);
        
        // Assert
        Assert.IsNotNull(extractedText, "큰 파일에서 텍스트 추출 성공");
        Console.WriteLine($"\n\n추출된 텍스트 길이: {extractedText.Length}");
    }
}
