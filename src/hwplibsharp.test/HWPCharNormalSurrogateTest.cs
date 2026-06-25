using System.Text;
using HwpLib.Object.BodyText.Paragraph.Text;

namespace HwpLibSharp.Test;

/// <summary>
/// HWPCharNormal의 보충 평면(서러게이트 쌍) 문자 처리 테스트.
///
/// 업스트림 hwplib 커밋 6f69a45f("보충 평면 문자(서러게이트 쌍)가 U+FFFD로 깨지는 문제 수정")
/// 대응 테스트. 보충 평면 문자는 두 개의 HWPCharNormal에 UTF-16 서러게이트 쌍으로 나뉘어
/// 저장되며, 각 코드 단위를 그대로 보존해야 이어붙일 때 올바른 코드 포인트로 합쳐진다.
/// </summary>
[TestClass]
public class HWPCharNormalSurrogateTest
{
    [TestMethod]
    public void NonBmpCharacter_ShouldRecombineFromSurrogatePair()
    {
        // Arrange: 한컴 사용자영역의 겹낫표 『(U+F0854)는 보충 평면 문자로,
        // UTF-16 서러게이트 쌍(2개의 코드 단위)으로 표현된다.
        const int codePoint = 0xF0854;
        string original = char.ConvertFromUtf32(codePoint);
        Assert.AreEqual(2, original.Length, "보충 평면 문자는 2개의 UTF-16 코드 단위로 표현되어야 한다.");

        // HWP는 각 코드 단위를 별도의 HWPCharNormal로 저장한다.
        var high = new HWPCharNormal(original[0]);
        var low = new HWPCharNormal(original[1]);

        // Act: TextExtractor 등에서 하듯 StringBuilder로 이어붙인다.
        var sb = new StringBuilder();
        sb.Append(high.Ch);
        sb.Append(low.Ch);
        string result = sb.ToString();

        // Assert: 서러게이트 쌍이 올바른 코드 포인트로 다시 합쳐져야 한다.
        Assert.AreEqual(original, result);
        Assert.AreEqual(codePoint, char.ConvertToUtf32(result, 0));
        Assert.DoesNotContain("�", result, "U+FFFD(대체 문자)로 깨지면 안 된다.");
    }

    [TestMethod]
    public void BmpCharacter_ShouldDecodeUnchanged()
    {
        // Arrange & Act: BMP 문자(가, U+AC00)는 기존 동작과 동일해야 한다.
        var ch = new HWPCharNormal('가');

        // Assert
        Assert.AreEqual("가", ch.Ch);
    }
}
