using HwpLib.Object;
using HwpLib.Reader;
using HwpLib.Tool.BlankFileMaker;
using HwpLib.Tool.TextExtractor;
using HwpLib.Writer;
using System.Text;

namespace HwpLibSharp.Test;

/// <summary>
/// 메모(Memo) 읽기/쓰기 테스트 (이슈 #11)
/// </summary>
[TestClass]
public class ReadingWritingMemoTest
{
    [TestMethod]
    public void WriteAndReadMemo_ShouldPreserveMemoText()
    {
        // Arrange
        var hwpFile = BlankFileMaker.Make();
        Assert.IsNotNull(hwpFile);
        AddMemo(hwpFile, 0, "첫 번째 메모입니다.");

        // Act
        var readFile = WriteAndRead(hwpFile);

        // Assert
        Assert.IsNotNull(readFile.BodyText.MemoList);
        Assert.HasCount(1, readFile.BodyText.MemoList);

        var memo = readFile.BodyText.MemoList[0];
        Assert.AreEqual(0L, memo.MemoList.MemoIndex);
        Assert.AreEqual(1, memo.ListHeader.ParaCount);
        Assert.AreEqual("첫 번째 메모입니다.\n", memo.ParagraphList.GetNormalString());
    }

    [TestMethod]
    public void WriteAndReadMultipleMemos_ShouldPreserveAll()
    {
        // Arrange
        var hwpFile = BlankFileMaker.Make();
        Assert.IsNotNull(hwpFile);
        AddMemo(hwpFile, 0, "첫 번째 메모입니다.");
        AddMemo(hwpFile, 1, "두 번째 메모입니다.");

        // Act
        var readFile = WriteAndRead(hwpFile);

        // Assert
        Assert.IsNotNull(readFile.BodyText.MemoList);
        Assert.HasCount(2, readFile.BodyText.MemoList);
        Assert.AreEqual(0L, readFile.BodyText.MemoList[0].MemoList.MemoIndex);
        Assert.AreEqual(1L, readFile.BodyText.MemoList[1].MemoList.MemoIndex);
        Assert.AreEqual("첫 번째 메모입니다.\n", readFile.BodyText.MemoList[0].ParagraphList.GetNormalString());
        Assert.AreEqual("두 번째 메모입니다.\n", readFile.BodyText.MemoList[1].ParagraphList.GetNormalString());
    }

    [TestMethod]
    public void ExtractTextFromMemo_ShouldReturnMemoText()
    {
        // Arrange
        var hwpFile = BlankFileMaker.Make();
        Assert.IsNotNull(hwpFile);
        AddMemo(hwpFile, 0, "메모 본문 텍스트");

        // Act
        var readFile = WriteAndRead(hwpFile);

        var sb = new StringBuilder();
        foreach (var memo in readFile.BodyText.MemoList!)
        {
            ForParagraphList.Extract(
                memo.ParagraphList,
                TextExtractMethod.InsertControlTextBetweenParagraphText,
                null,
                sb);
        }

        // Assert
        StringAssert.Contains(sb.ToString(), "메모 본문 텍스트");
    }

    /// <summary>
    /// 문서에 메모를 추가한다.
    /// </summary>
    private static void AddMemo(HWPFile hwpFile, long memoIndex, string text)
    {
        var memo = hwpFile.BodyText.AddNewMemo();
        memo.MemoList.MemoIndex = memoIndex;
        memo.ListHeader.ParaCount = 1;
        memo.ListHeader.TextWidth = 42520;
        memo.ListHeader.TextHeight = 4252;

        var paragraph = memo.ParagraphList.AddNewParagraph();
        paragraph.Header.ParaShapeId = 1;
        paragraph.Header.StyleId = 1;
        paragraph.CreateText();
        paragraph.Text?.AddString(text);
        paragraph.CreateCharShape();
        paragraph.CharShape?.AddParaCharShape(0, 2);
    }

    /// <summary>
    /// 파일을 스트림에 쓴 뒤 다시 읽어서 반환한다.
    /// </summary>
    private static HWPFile WriteAndRead(HWPFile hwpFile)
    {
        byte[] bytes;
        using (var ms = new MemoryStream())
        {
            HWPWriter.ToStream(hwpFile, ms);
            bytes = ms.ToArray();
        }

        using var readStream = new MemoryStream(bytes);
        var readFile = HWPReader.FromStream(readStream);
        Assert.IsNotNull(readFile);
        return readFile;
    }
}
