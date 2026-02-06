// =====================================================================
// Java Original: kr/dogfoot/hwplib/writer/docinfo/ForDocInfo.java
// Repository: https://github.com/neolord0/hwplib
// =====================================================================

using HwpLib.CompoundFile;
using HwpLib.Object.DocInfo;
using HwpLib.Object.Etc;
using System.Collections.Generic;

namespace HwpLib.Writer.DocInfo
{
    /// <summary>
    /// 문서 정보(DocInfo) 스트림을 쓰기 위한 객체
    /// </summary>
    public static class ForDocInfo
    {
        /// <summary>
        /// 문서 정보(DocInfo) 스트림을 쓴다.
        /// </summary>
        /// <param name="docInfo">문서 정보 객체</param>
        /// <param name="sw">스트림 라이터</param>
        public static void Write(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            DocumentProperties(docInfo, sw);
            IDMappings(docInfo, sw);

            sw.UpRecordLevel();

            BinData(docInfo, sw);
            FaceName(docInfo, sw);
            BorderFill(docInfo, sw);
            CharShape(docInfo, sw);
            TabDef(docInfo, sw);
            Numbering(docInfo, sw);
            Bullet(docInfo, sw);
            ParaShape(docInfo, sw);
            Style(docInfo, sw);
            MemoShape(docInfo, sw);
            TrackChangeAuthor(docInfo, sw);
            TrackChange2(docInfo, sw);

            sw.DownRecordLevel();

            DocData(docInfo, sw);
            ForbiddenChar(docInfo, sw);
            CompatibleDocument(docInfo, sw);

            sw.UpRecordLevel();

            LayoutCompatibility(docInfo, sw);

            sw.DownRecordLevel();

            DistributeDocData(docInfo, sw);

            sw.UpRecordLevel();

            TrackChange(docInfo, sw);

            sw.DownRecordLevel();
        }

        /// <summary>
        /// 문서 속성 레코드를 쓴다.
        /// </summary>
        private static void DocumentProperties(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            var dp = docInfo.DocumentProperties;
            if (dp == null)
            {
                return;
            }
            ForDocumentProperties.Write(dp, sw);
        }

        /// <summary>
        /// 아이디 매핑 헤더 레코드를 쓴다.
        /// </summary>
        private static void IDMappings(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            var im = docInfo.IdMappings;
            if (im == null)
            {
                return;
            }
            ForIDMappings.Write(im, sw);
        }

        /// <summary>
        /// 바이너리 데이터 레코드를 쓴다.
        /// </summary>
        private static void BinData(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            foreach (var bd in docInfo.BinDataList)
            {
                ForBinData.Write(bd, sw);
            }
        }

        /// <summary>
        /// 글꼴 레코드들을 쓴다.
        /// </summary>
        private static void FaceName(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            FaceNameList(docInfo.HangulFaceNameList, sw);
            FaceNameList(docInfo.EnglishFaceNameList, sw);
            FaceNameList(docInfo.HanjaFaceNameList, sw);
            FaceNameList(docInfo.JapaneseFaceNameList, sw);
            FaceNameList(docInfo.EtcFaceNameList, sw);
            FaceNameList(docInfo.SymbolFaceNameList, sw);
            FaceNameList(docInfo.UserFaceNameList, sw);
        }

        /// <summary>
        /// 글꼴 리스트를 쓴다.
        /// </summary>
        private static void FaceNameList(IReadOnlyList<FaceNameInfo> faceNameList, CompoundStreamWriter sw)
        {
            foreach (var fa in faceNameList)
            {
                ForFaceName.Write(fa, sw);
            }
        }

        /// <summary>
        /// 테두리/배경 레코드들을 쓴다.
        /// </summary>
        private static void BorderFill(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            foreach (var bf in docInfo.BorderFillList)
            {
                ForBorderFill.Write(bf, sw);
            }
        }

        /// <summary>
        /// 글자 모양 레코드들을 쓴다.
        /// </summary>
        private static void CharShape(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            foreach (var cs in docInfo.CharShapeList)
            {
                ForCharShape.Write(cs, sw);
            }
        }

        /// <summary>
        /// 탭 정의 레코드들을 쓴다.
        /// </summary>
        private static void TabDef(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            foreach (var td in docInfo.TabDefList)
            {
                ForTabDef.Write(td, sw);
            }
        }

        /// <summary>
        /// 문단 번호 레코드들을 쓴다.
        /// </summary>
        private static void Numbering(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            foreach (var n in docInfo.NumberingList)
            {
                ForNumbering.Write(n, sw);
            }
        }

        /// <summary>
        /// 글머리표 레코드들을 쓴다.
        /// </summary>
        private static void Bullet(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            foreach (var b in docInfo.BulletList)
            {
                ForBullet.Write(b, sw);
            }
        }

        /// <summary>
        /// 문단 모양 레코드들을 쓴다.
        /// </summary>
        private static void ParaShape(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            foreach (var ps in docInfo.ParaShapeList)
            {
                ForParaShape.Write(ps, sw);
            }
        }

        /// <summary>
        /// 스타일 레코드들을 쓴다.
        /// </summary>
        private static void Style(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            foreach (var s in docInfo.StyleList)
            {
                ForStyle.Write(s, sw);
            }
        }

        /// <summary>
        /// 문서 임의의 데이터 레코드를 쓴다.
        /// </summary>
        private static void DocData(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            if (docInfo.DocData != null)
            {
                ForUnknown.Write(docInfo.DocData, HWPTag.DocData, sw);
            }
        }

        /// <summary>
        /// 금칙처리 문자 레코드를 쓴다.
        /// </summary>
        private static void ForbiddenChar(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            if (docInfo.ForbiddenChar != null)
            {
                ForUnknown.Write(docInfo.ForbiddenChar, HWPTag.ForbiddenChar, sw);
            }
        }

        /// <summary>
        /// 배포용 문서 데이터 레코드를 쓴다.
        /// </summary>
        private static void DistributeDocData(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            if (docInfo.DistributeDocData != null)
            {
                ForUnknown.Write(docInfo.DistributeDocData, HWPTag.DistributeDocData, sw);
            }
        }

        /// <summary>
        /// 호환 문서 레코드를 쓴다.
        /// </summary>
        private static void CompatibleDocument(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            if (docInfo.CompatibleDocument != null)
            {
                ForCompatibleDocument.Write(docInfo.CompatibleDocument, sw);
            }
        }

        /// <summary>
        /// 레이아웃 호환성 레코드를 쓴다.
        /// </summary>
        private static void LayoutCompatibility(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            if (docInfo.LayoutCompatibility != null)
            {
                ForLayoutCompatibility.Write(docInfo.LayoutCompatibility, sw);
            }
        }

        /// <summary>
        /// 변경 추적 정보 레코드를 쓴다.
        /// </summary>
        private static void TrackChange(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            if (docInfo.TrackChange != null)
            {
                ForUnknown.Write(docInfo.TrackChange, HWPTag.TrackChange, sw);
            }
        }

        /// <summary>
        /// 메모 모양 레코드를 쓴다.
        /// </summary>
        private static void MemoShape(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            foreach (var memoShape in docInfo.MemoShapeList)
            {
                ForMemoShape.Write(memoShape, sw);
            }
        }

        /// <summary>
        /// 변경 추적 내용 및 모양 레코드를 쓴다.
        /// </summary>
        private static void TrackChange2(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            foreach (var trackChange2 in docInfo.TrackChange2List)
            {
                ForUnknown.Write(trackChange2, HWPTag.TrackChange2, sw);
            }
        }

        /// <summary>
        /// 변경 추적 작성자 레코드를 쓴다.
        /// </summary>
        private static void TrackChangeAuthor(Object.DocInfo.DocInfo docInfo, CompoundStreamWriter sw)
        {
            foreach (var trackChangeAuthor in docInfo.TrackChangeAuthorList)
            {
                ForUnknown.Write(trackChangeAuthor, HWPTag.TrackChangeAuthor, sw);
            }
        }
    }
}
