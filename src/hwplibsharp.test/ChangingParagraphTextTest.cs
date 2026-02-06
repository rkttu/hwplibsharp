using HwpLib.Object.BodyText;
using HwpLib.Object.BodyText.Paragraph;
using HwpLib.Object.BodyText.Paragraph.Text;
using HwpLib.Reader;
using HwpLib.Writer;

namespace HwpLibSharp.Test;

/// <summary>
/// 문단 텍스트 변경 테스트
/// </summary>
[TestClass]
public class ChangingParagraphTextTest
{
    private const string Source1 = "안녕하세요.";
    private const string Target1 = "Hello.";
    private const string Source2 = "이것은 샘플입니다.";
    private const string Target2 = "This is Sample.";

    [TestMethod]
    public void ChangeParagraphText_ShouldSucceed()
    {
        // Arrange
        var filePath = TestHelper.GetSamplePath("changing-paragraph-text.hwp");
        var hwpFile = HWPReader.FromFile(filePath);

        Assert.IsNotNull(hwpFile);

        // Act
        Section s = hwpFile.BodyText.SectionList[0];
        int count = s.ParagraphCount;
        for (int index = 0; index < count; index++)
        {
            ChangeParagraphText(hwpFile.BodyText.SectionList[0].GetParagraph(index));
        }

        var writePath = TestHelper.GetResultPath("result-changing-paragraph-text.hwp");
        HWPWriter.ToFile(hwpFile, writePath);

        // Assert
        Assert.IsTrue(File.Exists(writePath), "문단 텍스트 변경 성공");
    }

    private static void ChangeParagraphText(Paragraph? paragraph)
    {
        if (paragraph?.Text == null) return;

        var newCharList = GetNewCharList(paragraph.Text.CharList.ToList());
        ChangeNewCharList(paragraph, newCharList);
        RemoveLineSeg(paragraph);
        RemoveCharShapeExceptFirstOne(paragraph);
    }

    private static List<HWPChar> GetNewCharList(List<HWPChar> oldList)
    {
        var newList = new List<HWPChar>();
        var listForText = new List<HWPChar>();

        foreach (var ch in oldList)
        {
            if (ch.Type == HWPCharType.Normal)
            {
                listForText.Add(ch);
            }
            else
            {
                if (listForText.Count > 0)
                {
                    var text = ToString(listForText);
                    listForText.Clear();
                    var newText = ChangeText(text);

                    newList.AddRange(ToHwpCharList(newText));
                }
                newList.Add(ch);
            }
        }

        if (listForText.Count > 0)
        {
            var text = ToString(listForText);
            listForText.Clear();
            var newText = ChangeText(text);

            newList.AddRange(ToHwpCharList(newText));
        }

        return newList;
    }

    private static string ToString(List<HWPChar> listForText)
    {
        var sb = new System.Text.StringBuilder();
        foreach (var ch in listForText)
        {
            var chn = (HWPCharNormal)ch;
            sb.Append(chn.Ch);
        }
        return sb.ToString();
    }

    private static string? ChangeText(string text)
    {
        if (Source1 == text)
        {
            return Target1;
        }
        else if (Source2 == text)
        {
            return Target2;
        }
        return null;
    }

    private static List<HWPChar> ToHwpCharList(string? text)
    {
        var list = new List<HWPChar>();
        if (text == null) return list;

        int count = text.Length;
        for (int index = 0; index < count; index++)
        {
            var chn = new HWPCharNormal();
            chn.Code = (short)char.ConvertToUtf32(text, index);
            list.Add(chn);
            // 서로게이트 페어 처리
            if (char.IsHighSurrogate(text[index]) && index + 1 < count && char.IsLowSurrogate(text[index + 1]))
            {
                index++;
            }
        }
        return list;
    }

    private static void ChangeNewCharList(Paragraph paragraph, List<HWPChar> newCharList)
    {
        // Java 버전과 동일하게: CharList를 clear하고 새로운 문자들을 추가
        paragraph.Text!.Clear();
        foreach (var ch in newCharList)
        {
            paragraph.Text!.AddChar(ch);
        }
        paragraph.Header.CharacterCount = newCharList.Count;
    }

    private static void RemoveLineSeg(Paragraph paragraph)
    {
        paragraph.DeleteLineSeg();
    }

    private static void RemoveCharShapeExceptFirstOne(Paragraph paragraph)
    {
        if (paragraph.CharShape == null) return;

        int size = paragraph.CharShape.PositionShapeIdPairList.Count;
        if (size > 1)
        {
            // Java 버전과 동일하게: 인덱스 1부터 반복하여 삭제
            for (int index = 0; index < size - 1; index++)
            {
                paragraph.CharShape.RemoveParaCharShapeAt(1);
            }
            paragraph.Header.CharShapeCount = 1;
        }
    }
}
