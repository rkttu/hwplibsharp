// =====================================================================
// Java Original: kr/dogfoot/hwplib/tool/objectfinder/TextBuffer.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using System.Collections.Generic;

namespace HwpLib.Tool.ObjectFinder
{
    /// <summary>
    /// 텍스트 버퍼
    /// </summary>
    public class TextBuffer
    {
        /// <summary>
        /// 텍스트 리스트
        /// </summary>
        private readonly List<string> _textList;

        /// <summary>
        /// 텍스트 갯수
        /// </summary>
        private readonly int _textCount;

        /// <summary>
        /// 현재 사용중인 텍스트 인덱스
        /// </summary>
        private int _currentIndex;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="textList">텍스트 리스트</param>
        public TextBuffer(List<string> textList)
        {
            _textList = textList;
            _textCount = textList.Count;
            _currentIndex = 0;
        }

        /// <summary>
        /// 다음 텍스트를 반환한다.
        /// </summary>
        /// <returns>다음 텍스트</returns>
        public string NextText()
        {
            var text = _textList[_currentIndex];
            _currentIndex++;
            return text;
        }

        /// <summary>
        /// 다음 텍스트가 존재하는지 여부를 반환한다.
        /// </summary>
        /// <returns>다음 텍스트가 존재하는지 여부</returns>
        public bool HasNext()
        {
            return _currentIndex < _textCount;
        }

        /// <summary>
        /// 텍스트를 모두 사용했는지 여부를 반환한다.
        /// </summary>
        /// <returns>텍스트를 모두 사용했는지 여부</returns>
        public bool UsedAll()
        {
            return _currentIndex == _textCount;
        }

        /// <summary>
        /// 텍스트를 하나도 사용하지 않았는지 여부를 반환한다.
        /// </summary>
        /// <returns>텍스트를 하나도 사용하지 않았는지 여부</returns>
        public bool NotUsed()
        {
            return _currentIndex == 0;
        }
    }
}
