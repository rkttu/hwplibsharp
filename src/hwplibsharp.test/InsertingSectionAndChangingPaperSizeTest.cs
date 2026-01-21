using HwpLib.Object.BodyText.Control;
using HwpLib.Tool.BlankFileMaker;
using HwpLib.Writer;

namespace HwpLibSharp.Test;

/// <summary>
/// 섹션 추가 및 용지 크기 변경 테스트
/// </summary>
[TestClass]
public class InsertingSectionAndChangingPaperSizeTest
{
    // 표준 용지 크기 (HWP 좌표)
    private const long A4Width = 59528;
    private const long A4Height = 84188;
    private const long A3Width = 84188;
    private const long A3Height = 119055;

    [TestMethod]
    public void InsertSectionAndChangePaperSize_ShouldSucceed()
    {
        // Arrange
        var hwpFile = BlankFileMaker.Make();
        Assert.IsNotNull(hwpFile);

        // Act - 새 섹션 추가
        var newSection = hwpFile.BodyText.AddNewSection();

        // 새 섹션에 빈 문단 추가
        // 중요: newSection.AddNewParagraph()를 직접 호출하면 내용이 없는(Uninitialized) 문단 객체만 생성되어
        // 파일 저장 시 필수 레코드(Header, Text, CharShape 등) 누락으로 인해 파일이 깨집니다.
        // 따라서 EmptyParagraphAdder를 사용하여 유효한 기본 구조를 갖춘 문단을 추가해야 합니다.
        EmptyParagraphAdder.Add(newSection);

        // 새 섹션의 용지 크기를 A3로 변경
        var firstParagraph = newSection.GetParagraph(0);
        if (firstParagraph.ControlList != null)
        {
            foreach (var control in firstParagraph.ControlList)
            {
                if (control is ControlSectionDefine sectionDefine)
                {
                    sectionDefine.PageDef.PaperWidth = A3Width;
                    sectionDefine.PageDef.PaperHeight = A3Height;
                }
            }
        }

        // Assert
        Assert.HasCount(2, hwpFile.BodyText.SectionList, "섹션이 2개여야 합니다.");

        var writePath = TestHelper.GetResultPath("result-inserting-section.hwp");
        HWPWriter.ToFile(hwpFile, writePath);
        Assert.IsTrue(File.Exists(writePath));
    }
}
