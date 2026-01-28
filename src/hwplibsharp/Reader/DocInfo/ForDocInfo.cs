// =====================================================================
// Java Original: kr/dogfoot/hwplib/reader/docinfo/ForDocInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.Etc;
using System;
using DocInfoType = HwpLib.Object.DocInfo.DocInfo;


namespace HwpLib.Reader.DocInfo
{

    /// <summary>
    /// 문서 정보(DocInfo) 스트림을 읽기 위한 객체
    /// </summary>
    public class ForDocInfo
    {
        /// <summary>
        /// 문서 정보 스트림을 나타내는 객체
        /// </summary>
        private DocInfoType? _docInfo;

        /// <summary>
        /// 스트림 리더
        /// </summary>
        private CompoundStreamReader? _sr;

        /// <summary>
        /// 생성자
        /// </summary>
        public ForDocInfo()
        {
        }

        /// <summary>
        /// 문서 정보(DocInfo) 스트림를 읽는다.
        /// </summary>
        /// <param name="di">문서 정보 스트림을 나타내는 객체</param>
        /// <param name="sr">스트림 리더</param>
        public void Read(DocInfoType di, CompoundStreamReader sr)
        {
            _sr = sr;
            _docInfo = di;

            while (!sr.IsEndOfStream())
            {
                sr.ReadRecordHeader();
                ReadRecordBody();
            }
        }

        /// <summary>
        /// 이미 읽은 레코드 헤더에 따른 레코드 내용을 읽는다.
        /// </summary>
        private void ReadRecordBody()
        {
            if (_sr == null || _docInfo == null || _sr.CurrentRecordHeader == null)
                return;

            var tagId = (short)_sr.CurrentRecordHeader.TagId;

            if (tagId == HWPTag.DocumentProperties)
                ReadDocumentProperties(_docInfo.DocumentProperties);
            else if (tagId == HWPTag.IdMappings)
                ReadIdMappings(_docInfo.IdMappings);
            else if (tagId == HWPTag.BinData)
                ReadBinData();
            else if (tagId == HWPTag.FaceName)
                ReadFaceName();
            else if (tagId == HWPTag.BorderFill)
                ReadBorderFill();
            else if (tagId == HWPTag.CharShape)
                ReadCharShape();
            else if (tagId == HWPTag.TabDef)
                ReadTabDef();
            else if (tagId == HWPTag.Numbering)
                ReadNumbering();
            else if (tagId == HWPTag.Bullet)
                ReadBullet();
            else if (tagId == HWPTag.ParaShape)
                ReadParaShape();
            else if (tagId == HWPTag.Style)
                ReadStyle();
            else if (tagId == HWPTag.DocData)
                ReadDocData();
            else if (tagId == HWPTag.ForbiddenChar)
                ReadForbiddenChar();
            else if (tagId == HWPTag.DistributeDocData)
                ReadDistributeDocData();
            else if (tagId == HWPTag.CompatibleDocument)
                ReadCompatibleDocument();
            else if (tagId == HWPTag.LayoutCompatibility)
                ReadLayoutCompatibility();
            else if (tagId == HWPTag.TrackChange)
                ReadTrackChange();
            else if (tagId == HWPTag.MemoShape)
                ReadMemoShape();
            else if (tagId == HWPTag.TrackChange2)
                ReadTrackChange2();
            else if (tagId == HWPTag.TrackChangeAuthor)
                ReadTrackChangeAuthor();
            else
                _sr.SkipToEndRecord(); // 알려지지 않은 태그는 스킵
        }

        /// <summary>
        /// 문서 속성 레코드를 읽는다.
        /// </summary>
        /// <param name="dp">읽은 내용을 저장할 객체</param>
        private void ReadDocumentProperties(HwpLib.Object.DocInfo.DocumentPropertiesInfo dp)
        {
            ForDocumentProperties.Read(dp, _sr!);
        }

        /// <summary>
        /// 아이디 매핑 헤더 레코드를 읽는다.
        /// </summary>
        /// <param name="im">읽은 내용을 저장할 객체</param>
        private void ReadIdMappings(HwpLib.Object.DocInfo.IDMappings im)
        {
            ForIDMappings.Read(im, _sr!);
        }

        /// <summary>
        /// 바이너리 데이터 레코드를 읽는다.
        /// </summary>
        private void ReadBinData()
        {
            var bd = _docInfo!.AddNewBinData();
            ForBinData.Read(bd, _sr!);
        }

        /// <summary>
        /// 글꼴 레코드를 읽는다.
        /// </summary>
        private void ReadFaceName()
        {
            var fn = new HwpLib.Object.DocInfo.FaceNameInfo();
            ForFaceName.Read(fn, _sr!);
            AddFaceNameByIDMappings(fn);
        }

        /// <summary>
        /// 글꼴 레코드 객체를 아이디 매핑 레코드의 글꼴 개수에 따라 추가한다.
        /// </summary>
        /// <param name="fn">글꼴 레코드 객체</param>
        private void AddFaceNameByIDMappings(HwpLib.Object.DocInfo.FaceNameInfo fn)
        {
            var idm = _docInfo!.IdMappings;
            if (_docInfo.HangulFaceNameList.Count < idm.HangulFaceNameCount)
            {
                _docInfo.AddFaceNameToHangulList(fn);
            }
            else if (_docInfo.EnglishFaceNameList.Count < idm.EnglishFaceNameCount)
            {
                _docInfo.AddFaceNameToEnglishList(fn);
            }
            else if (_docInfo.HanjaFaceNameList.Count < idm.HanjaFaceNameCount)
            {
                _docInfo.AddFaceNameToHanjaList(fn);
            }
            else if (_docInfo.JapaneseFaceNameList.Count < idm.JapaneseFaceNameCount)
            {
                _docInfo.AddFaceNameToJapaneseList(fn);
            }
            else if (_docInfo.EtcFaceNameList.Count < idm.EtcFaceNameCount)
            {
                _docInfo.AddFaceNameToEtcList(fn);
            }
            else if (_docInfo.SymbolFaceNameList.Count < idm.SymbolFaceNameCount)
            {
                _docInfo.AddFaceNameToSymbolList(fn);
            }
            else if (_docInfo.UserFaceNameList.Count < idm.UserFaceNameCount)
            {
                _docInfo.AddFaceNameToUserList(fn);
            }
            else
            {
                throw new InvalidOperationException("Count of FaceName is greater than ID Mappings");
            }
        }

        /// <summary>
        /// 테두리/배경 레코드를 읽는다.
        /// </summary>
        private void ReadBorderFill()
        {
            var bf = _docInfo!.AddNewBorderFill();
            ForBorderFill.Read(bf, _sr!);
        }

        /// <summary>
        /// 글자 모양 레코드를 읽는다.
        /// </summary>
        private void ReadCharShape()
        {
            var cs = _docInfo!.AddNewCharShape();
            ForCharShape.Read(cs, _sr!);
        }

        /// <summary>
        /// 탭 정의 레코드를 읽는다.
        /// </summary>
        private void ReadTabDef()
        {
            var td = _docInfo!.AddNewTabDef();
            ForTabDef.Read(td, _sr!);
        }

        /// <summary>
        /// 문단 번호 레코드를 읽는다.
        /// </summary>
        private void ReadNumbering()
        {
            var n = _docInfo!.AddNewNumbering();
            ForNumbering.Read(n, _sr!);
        }

        /// <summary>
        /// 글머리표 레코드를 읽는다.
        /// </summary>
        private void ReadBullet()
        {
            var b = _docInfo!.AddNewBullet();
            ForBullet.Read(b, _sr!);
        }

        /// <summary>
        /// 문단 모양 레코드를 읽는다.
        /// </summary>
        private void ReadParaShape()
        {
            var ps = _docInfo!.AddNewParaShape();
            ForParaShape.Read(ps, _sr!);
        }

        /// <summary>
        /// 스타일 레코드를 읽는다.
        /// </summary>
        private void ReadStyle()
        {
            var s = _docInfo!.AddNewStyle();
            ForStyle.Read(s, _sr!);
        }

        /// <summary>
        /// 문서 임의의 데이터 레코드를 읽는다.
        /// </summary>
        private void ReadDocData()
        {
            _docInfo!.CreateDocData(_sr!.CurrentRecordHeader!);
            ForUnknown.Read(_docInfo.DocData!, _sr!);
        }

        /// <summary>
        /// 배포용 문서 데이터 레코드를 읽는다.
        /// </summary>
        private void ReadDistributeDocData()
        {
            _docInfo!.CreateDistributeDocData(_sr!.CurrentRecordHeader!);
            ForUnknown.Read(_docInfo.DistributeDocData!, _sr!);
        }

        /// <summary>
        /// 호환 문서 레코드를 읽는다.
        /// </summary>
        private void ReadCompatibleDocument()
        {
            _docInfo!.CreateCompatibleDocument();
            ForCompatibleDocument.Read(_docInfo.CompatibleDocument!, _sr!);
        }

        /// <summary>
        /// 레이아웃 호환성 레코드를 읽는다.
        /// </summary>
        private void ReadLayoutCompatibility()
        {
            _docInfo!.CreateLayoutCompatibility();
            ForLayoutCompatibility.Read(_docInfo.LayoutCompatibility!, _sr!);
        }

        /// <summary>
        /// 변경 추적 정보 레코드를 읽는다.
        /// </summary>
        private void ReadTrackChange()
        {
            _docInfo!.CreateTrackChange(_sr!.CurrentRecordHeader!);
            ForUnknown.Read(_docInfo.TrackChange!, _sr!);
        }

        /// <summary>
        /// 메모 모양 레코드를 읽는다.
        /// </summary>
        private void ReadMemoShape()
        {
            var ms = _docInfo!.AddNewMemoShape();
            ForMemoShape.Read(ms, _sr!);
        }

        /// <summary>
        /// 금칙처리 문자 레코드를 읽는다.
        /// </summary>
        private void ReadForbiddenChar()
        {
            _docInfo!.CreateForbiddenChar(_sr!.CurrentRecordHeader!);
            ForUnknown.Read(_docInfo.ForbiddenChar!, _sr!);
        }

        /// <summary>
        /// 변경 추적 내용 및 모양 레코드를 읽는다.
        /// </summary>
        private void ReadTrackChange2()
        {
            var ur = _docInfo!.AddNewTrackChange2(_sr!.CurrentRecordHeader!);
            ForUnknown.Read(ur, _sr!);
        }

        /// <summary>
        /// 변경 추적 작성자 레코드를 읽는다.
        /// </summary>
        private void ReadTrackChangeAuthor()
        {
            var ur = _docInfo!.AddNewTrackChangeAuthor(_sr!.CurrentRecordHeader!);
            ForUnknown.Read(ur, _sr!);
        }
    }

}