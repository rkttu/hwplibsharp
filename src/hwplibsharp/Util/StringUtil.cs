using System.Text;

namespace HwpLib.Util;

/// <summary>
/// 문자열 관련 유틸리티 클래스
/// </summary>
public static class StringUtil
{
    private static readonly char[] HexArray = "0123456789ABCDEF".ToCharArray();

    /// <summary>
    /// 문자열(UTF-16LE)이 저장될 때 필요한 byte의 개수를 반환한다.
    /// </summary>
    /// <param name="s">문자열</param>
    /// <returns>문자열(UTF-16LE)이 저장될 때 필요한 byte의 개수</returns>
    public static int GetUTF16LEStringSize(string? s)
    {
        if (s == null)
        {
            return 2;
        }
        else
        {
            return 2 + s.Length * 2;
        }
    }

    /// <summary>
    /// 바이트 배열을 16진수 문자열로 바꾼다.
    /// </summary>
    /// <param name="bytes">바이트 배열</param>
    /// <returns>16진수 문자열</returns>
    public static string BytesToHex(byte[] bytes)
    {
        char[] hexChars = new char[bytes.Length * 3];
        for (int j = 0; j < bytes.Length; j++)
        {
            int v = bytes[j] & 0xFF;
            hexChars[j * 3] = HexArray[(v >> 4) & 0x0F];
            hexChars[j * 3 + 1] = HexArray[v & 0x0F];
            hexChars[j * 3 + 2] = ' ';
        }
        return new string(hexChars);
    }

    /// <summary>
    /// 두 문자열이 같은지 비교한다. null 처리 포함.
    /// </summary>
    /// <param name="str1">첫 번째 문자열</param>
    /// <param name="str2">두 번째 문자열</param>
    /// <returns>두 문자열이 같으면 true</returns>
    public static bool Equals(string? str1, string? str2)
    {
        if (str1 == null)
        {
            return str2 == null;
        }
        else
        {
            return str1.Equals(str2);
        }
    }

    /// <summary>
    /// 문자열에서 여러 검색어를 찾아 대체 문자열로 바꾼다.
    /// </summary>
    /// <param name="text">원본 문자열</param>
    /// <param name="searchList">검색어 목록</param>
    /// <param name="replacementList">대체 문자열 목록</param>
    /// <returns>대체된 문자열</returns>
    public static string? ReplaceEach(string? text, string?[]? searchList, string?[]? replacementList)
    {
        return ReplaceEach(text, searchList, replacementList, false, 0);
    }

    private static string? ReplaceEach(
        string? text, string?[]? searchList, string?[]? replacementList, bool repeat, int timeToLive)
    {
        // if recursing, this shouldn't be less than 0
        if (timeToLive < 0)
        {
            var searchSet = new HashSet<string?>(searchList ?? Array.Empty<string?>());
            var replacementSet = new HashSet<string?>(replacementList ?? Array.Empty<string?>());
            searchSet.IntersectWith(replacementSet);
            if (searchSet.Count > 0)
            {
                throw new InvalidOperationException("Aborting to protect against StackOverflowError - " +
                    "output of one loop is the input of another");
            }
        }

        if (IsEmpty(text) || ArrayUtil.IsEmpty(searchList) || ArrayUtil.IsEmpty(replacementList) || 
            (ArrayUtil.IsNotEmpty(searchList) && timeToLive == -1))
        {
            return text;
        }

        int searchLength = searchList!.Length;
        int replacementLength = replacementList!.Length;

        // make sure lengths are ok, these need to be equal
        if (searchLength != replacementLength)
        {
            throw new ArgumentException("Search and Replace array lengths don't match: "
                + searchLength + " vs " + replacementLength);
        }

        // keep track of which still have matches
        bool[] noMoreMatchesForReplIndex = new bool[searchLength];

        // index on index that the match was found
        int textIndex = -1;
        int replaceIndex = -1;
        int tempIndex;

        // index of replace array that will replace the search string found
        for (int i = 0; i < searchLength; i++)
        {
            if (noMoreMatchesForReplIndex[i] || IsEmpty(searchList[i]) || replacementList[i] == null)
            {
                continue;
            }
            tempIndex = text!.IndexOf(searchList[i]!, StringComparison.Ordinal);

            // see if we need to keep searching for this
            if (tempIndex == -1)
            {
                noMoreMatchesForReplIndex[i] = true;
            }
            else if (textIndex == -1 || tempIndex < textIndex)
            {
                textIndex = tempIndex;
                replaceIndex = i;
            }
        }

        // no search strings found, we are done
        if (textIndex == -1)
        {
            return text;
        }

        int start = 0;

        // get a good guess on the size of the result buffer so it doesn't have to double if it goes over a bit
        int increase = 0;

        // count the replacement text elements that are larger than their corresponding text being replaced
        for (int i = 0; i < searchList.Length; i++)
        {
            if (searchList[i] == null || replacementList[i] == null)
            {
                continue;
            }
            int greater = replacementList[i]!.Length - searchList[i]!.Length;
            if (greater > 0)
            {
                increase += 3 * greater; // assume 3 matches
            }
        }
        // have upper-bound at 20% increase, then let runtime take over
        increase = Math.Min(increase, text!.Length / 5);

        var buf = new StringBuilder(text.Length + increase);

        while (textIndex != -1)
        {
            for (int i = start; i < textIndex; i++)
            {
                buf.Append(text[i]);
            }
            buf.Append(replacementList[replaceIndex]);

            start = textIndex + searchList[replaceIndex]!.Length;

            textIndex = -1;
            replaceIndex = -1;
            // find the next earliest match
            for (int i = 0; i < searchLength; i++)
            {
                if (noMoreMatchesForReplIndex[i] || searchList[i] == null ||
                    string.IsNullOrEmpty(searchList[i]) || replacementList[i] == null)
                {
                    continue;
                }
                tempIndex = text.IndexOf(searchList[i]!, start, StringComparison.Ordinal);

                // see if we need to keep searching for this
                if (tempIndex == -1)
                {
                    noMoreMatchesForReplIndex[i] = true;
                }
                else if (textIndex == -1 || tempIndex < textIndex)
                {
                    textIndex = tempIndex;
                    replaceIndex = i;
                }
            }
        }

        int textLength = text.Length;
        for (int i = start; i < textLength; i++)
        {
            buf.Append(text[i]);
        }

        string result = buf.ToString();
        if (!repeat)
        {
            return result;
        }

        return ReplaceEach(result, searchList, replacementList, repeat, timeToLive - 1);
    }

    /// <summary>
    /// 문자열이 비어있거나 null인지 확인한다.
    /// </summary>
    /// <param name="cs">확인할 문자열</param>
    /// <returns>문자열이 비어있거나 null이면 true</returns>
    public static bool IsEmpty(string? cs)
    {
        return cs == null || cs.Length == 0;
    }
}
