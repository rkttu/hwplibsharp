# 테스트 현황 문서

> 마지막 업데이트: 2026년 9월 13일

## 📊 테스트 결과 요약

| 항목 | 개수 | 비율 |
|------|------|------|
| **총 테스트** | 173개 | 100% |
| **성공** | 172개 | 99.4% |
| **실패** | 0개 | 0% |
| **건너뜀** | 1개 | 0.6% |

### 📈 진행 상황 비교

| 항목 | 12/16 오전 | 12/16 오후 | 12/16 밤 | 2026년 9월 13일 | 변화(12/16 밤 대비) |
|------|------------|------------|--------------|------------|---------------------|
| 총 테스트 | 148개 | 148개 | 143개 | 173개 | +30개 |
| 성공 | 70개 (47.3%) | 142개 (95.9%) | 143개 (100%) | 172개 (99.4%) | +29개 |
| 실패 | 75개 (50.7%) | 0개 (0%) | 0개 (0%) | 0개 (0%) | 변화 없음 |
| 건너뜀 | 3개 (2.0%) | 6개 (4.1%) | 0개 (0%) | 1개 (0.6%) | +1개 |

---

## 이슈 #18의 짧은 컨트롤 헤더 읽기 수정

2026년 9월 13일에 [이슈 #18](https://github.com/rkttu/hwplibsharp/issues/18)의 본문과 추가 댓글을 확인하고
Java 업스트림 `cdfb2690..6746c27f`의 전체 6개 커밋을 대조했습니다.
서브모듈을 `6746c27f17ebf5277493206284aa32044a1839c4`로 동기화했습니다.

### 업스트림의 최종 조건 반영

[업스트림 수정](https://github.com/neolord0/hwplib/commit/877c78af2f327f84b8a07e1691fe3c79d53b43d0)에 따라
`ForCtrlHeaderGso.Read`는 레코드에 4바이트보다 많이 남았을 때만 `PreventPageDivide`를 읽습니다.
42바이트 표 컨트롤 헤더에서는 이 필드를 생략하고 남은 2바이트를 빈 설명문으로 읽습니다.
Java의 `getCurrentPositionAfterHeader()`는 레코드 안에서 읽은 바이트 수를 반환하므로
C#에서는 같은 의미의 조건을 `RemainingBytes > 4`로 표현했습니다.

그 밖의 Java 변경은 `MutableSection`의 import 순서 조정과
`ForParagraphList`, `ForDocInfo`의 미사용 import 제거에 한정됩니다.
C#은 해당 의존성을 사용하지 않아 추가 구현 변경이 없습니다.
읽기 동작 수정과 Java 1.1.11 기준 동기화를 반영해 프로젝트 버전을 `1.1.11.0`으로 갱신했습니다.

### 회귀 테스트와 전체 검증 결과

[업스트림 PR #315](https://github.com/neolord0/hwplib/pull/315)의 재현 조건을 바탕으로
경계값 테스트 7개와 실제 HWP 파일 테스트 2개를 추가했습니다.
수정 전에는 짧은 헤더를 다루는 경계값 테스트 2개가 실패했고 수정 후에는 9개 모두 통과했습니다.

- 경계값 검증: 선택 필드가 없는 헤더, 빈 설명문, 한 글자 설명문, 쪽나눔 방지 플래그, 후행 미해석 바이트
- 레코드 정렬 검증: 선행 레코드가 있는 스트림에서 다음 레코드의 태그, 레벨, 크기, 데이터 보존
- 실제 파일 검증: 표 읽기, 다시 저장, 셀 텍스트 입력 후 표 구조와 텍스트 보존
- 라이브러리 빌드: `netstandard2.0`, `net472`, `net8.0` 모두 성공, 경고 0개와 오류 0개
- `net8.0` 전체 테스트: 172개 성공, 1개 건너뜀, 0개 실패
- `net472` 전체 테스트: 172개 성공, 1개 건너뜀, 0개 실패
- 건너뛴 테스트: 외부 네트워크 접근 제한에 따른 `ReadHwpFromUrl_ShouldSucceed`

### 재현 파일과 생성한 HWP

재현 파일은 [공개된 고정 커밋의 원본](https://github.com/emptinessform/hwplib/blob/5452db19228015ffbe3250c6fbaa6d6526901eb5/sample_hwp/issue-315-table-ctrl-header.hwp)을
`sample_hwp/basic/issue-315-table-ctrl-header.hwp`에 저장했습니다.
파일 크기는 13,312바이트이며 SHA-256은 `9AD77288BAC007C2C90C3779B585B78C5CD0387D0D9943C6A0DEC3512A56320F`입니다.

이번 전체 테스트 실행에서 HWP 88개를 생성하거나 갱신했습니다.
기존 결과를 포함해 `sample_hwp/result`의 105개 파일과 별도 누름틀 결과 1개를 검사했습니다.
106개 모두 OLE 서명 검사와 `HWPReader` 재읽기에 성공했습니다.
한글 뷰어 2024 13.0.0.652에서 원본과 이슈 #18 결과 2개의 전체 쪽 화면을 확인했습니다.
재저장 결과는 원본과 같은 2행 8열 표 배치를 유지했습니다.
첫 셀에 문장을 넣은 결과에서는 줄바꿈과 첫 행 높이 증가를 관찰했습니다.
확대 대화상자의 Computer Use 창 활성화 오류로 글자 잘림 여부와 세부 렌더링 판정은 보류했습니다.
나머지 생성 결과 86개는 화면을 확인하지 않았습니다. 관찰 내용을 확정 결함으로 분류하거나 별도 이슈로 등록하지 않았습니다.

- 원본 표 재저장: `sample_hwp/result/result-issue18-short-table-rewrite.hwp`
- 첫 셀 텍스트 입력: `sample_hwp/result/result-issue18-short-table-filled.hwp`
- 기존 생성 및 편집 테스트 결과: `sample_hwp/result/`
- 별도 누름틀 결과: `sample_hwp/basic/result-setting-필드-누름틀.hwp`
- 로컬 테스트 기록: `TestResults/issue18/net8.0.trx`, `TestResults/issue18/net472.trx`
- 로컬 HWP 검증 목록: `TestResults/issue18/hwp-validation.json`
- 로컬 렌더링 검토 기록과 화면: `TestResults/issue18/render-review/REVIEW.md`

생성 결과와 로컬 검증 기록은 기존 `.gitignore` 규칙에 따라 Git 추적에서 제외합니다.
재현 입력 파일은 회귀 테스트와 함께 보관합니다.

---

## 2026년 8월 22일 - 이슈 #17 업스트림 동기화

### 분석 및 반영 내용

1. Java 업스트림 `a32b5cd4`에서 `ImageFill`과 `ShapeComponentPicture`의
   brightness/contrast 순서를 분리했으나, 후속 커밋 `cdfb2690`에서 해당 기능 변경을 롤백함
2. 최신 Java와 C# 모두 `PictureInfo`를 `contrast → brightness` 순서로 읽고 쓰므로
   C# 기능 구현은 이미 일치하는 상태임을 확인함
3. `hwplib` 서브모듈을 최신 `cdfb2690`으로 동기화함
4. 서로 다른 brightness/contrast 값을 사용한 읽기·쓰기 회귀 테스트 2개를 추가함
5. 실행 로직과 공개 API의 변경이 없어 라이브러리 버전은 `1.1.10.8`로 유지하고 NuGet 배포는 생략함

### 검증 결과

- 라이브러리 빌드: `netstandard2.0`, `net472`, `net8.0` 모두 성공(경고 0, 오류 0)
- `net8.0`: 163개 성공, 1개 건너뜀, 0개 실패
- `net472`: 163개 성공, 1개 건너뜀, 0개 실패
- 건너뛴 테스트: 외부 네트워크 접근이 필요한 `ReadHwpFromUrl_ShouldSucceed`
- HWP 생성·편집 배치 테스트: 85개 모두 성공
- 이번 배치에서 생성·갱신된 HWP 84개 모두 OLE 서명 및 `HWPReader` 재파싱에 성공하고 Viewer 수동 확인을 완료함

---

## 🎉 12월 16일 밤 - 100% 테스트 성공 달성!

### 주요 변경 사항

1. **테이블 컨트롤 Reader 완성**
   - `FindControl_WithFilter_ShouldSucceed` 테스트 활성화 및 통과
   - Java 서브모듈과 구현 일치 확인 완료

2. **모든 [Ignore] 속성 제거**
   - 기존에 건너뛰던 테스트 모두 활성화 및 통과

3. **Java 버전과 테스트 케이스 통일**
   - Java 서브모듈에 없는 추가 테스트 파일 삭제
   - 삭제된 파일: `GsoReadingTest.cs`, `OldVersionPictureControlTest.cs`, `Test1.cs`
   - 148개 → 143개로 정리

---

## ✅ 12월 16일 주요 변경 사항

### 커밋 이력 (최신순)

1. **result 파일명 변경** (`7e1cb5f`)
   - `result-adding-paragraph-original.hwp`로 결과 파일명 변경

2. **컨트롤 파싱 구조 단순화 및 불필요 코드 제거** (`ea48ed5`)
   - `CompoundStreamReader`의 `ReadToEndRecord` 메서드 삭제
   - `ForCtrlHeaderGso` 파일 삭제
   - `ForSection`에서 GSO 및 기타 컨트롤의 별도 파싱/스킵 로직 제거
   - `ParaCharShape`, `ParaLineSeg`, `ParaRangeTag` 관련 구조 단순화

3. **GSO/테이블 Reader 미구현 테스트 Ignore 및 주석 추가** (`4b7feac`)
   - `AddingParagraphBetweenHwpFileTest` 테스트 정리
   - `MakingCaptionTest`, `MergingCellTest`에 `[Ignore]` 속성 추가

4. **GSO 및 복합 컨트롤 파싱 개선 및 관련 코드 추가** (`7eb8bac`)
   - `CompoundStreamReader`에 기능 추가
   - `ForCtrlHeaderGso` 파서 추가
   - `ForSection`에 GSO 파싱 로직 추가

5. **FindControl_WithFilter 테스트 임시 비활성화** (`028cf48`)
   - 필터 기능 테스트 임시 비활성화

6. **CharList 개수 검사 로직 분리 및 조건 개선** (`5876e5c`)
   - `ForParaText`에서 CharList 검사 로직 개선

7. **결과 파일명 변경 및 CRLF로 라인 엔딩 통일** (`0ddfc2f`)
   - 테스트 파일 라인 엔딩 통일

8. **Section 파서에 컨트롤 및 CtrlData 파싱 기능 추가** (`1df86af`)
   - `ForControlField` 파서 추가
   - `ForCtrlData` 파서 추가
   - `ForParameterSet` 파서 추가
   - `ForSection`에 컨트롤 파싱 로직 추가

9. **HWP Section 본문 파싱 기능 및 문단 구조 해석 추가** (`a818c44`)
   - `ForSection` 본문 파싱 구현
   - `ForParaCharShape`, `ForParaHeader`, `ForParaLineSeg`, `ForParaRangeTag` 파서 추가

10. **HWP 형식 압축 데이터 복원 로직 추가** (`91721f0`)
    - `Compressor`에 압축 해제 로직 추가

11. **BodyText 스토리지 및 섹션 읽기 로직 기본 구현** (`c0b6588`)
    - `HWPReader`에 BodyText 읽기 로직 추가

12. **CompoundFileWriter에 SwitchTo 사용 및 자원 관리 개선** (`0a18cee`)
    - 파일 쓰기 시 자원 관리 개선

13. **테스트 파일명 충돌 수정**
    - `ChangePaperSize_ToA3_ShouldSucceed` 테스트 결과 파일명을 고유하게 변경
    - 병렬 테스트 실행 시 파일 액세스 경쟁 문제 해결

---

## ✅ 해결된 문제들

### ~~우선순위 1: Compound File Writer 수정~~ ✅ 해결됨
- **상태**: 대부분의 FAT Sector ID 오류 해결
- **해결 커밋**: `0a18cee` - CompoundFileWriter에 SwitchTo 사용 및 자원 관리 개선
- **결과**: RewriteFile 테스트 전체 통과

### ~~우선순위 2: BodyText Section 파싱 로직~~ ✅ 해결됨
- **상태**: Section 본문 파싱 구현 완료
- **해결 커밋**: `a818c44`, `1df86af`, `c0b6588`
- **결과**: ReadBasicFile 테스트 대부분 통과

### ~~우선순위 3: 테스트 파일 경쟁 조건~~ ✅ 해결됨
- **상태**: 병렬 테스트 실행 시 파일명 충돌 해결
- **수정 파일**: `ChangingPaperSizeTest.cs`
- **결과**: `ChangePaperSize_ToA3_ShouldSucceed` 테스트 통과

### ~~우선순위 4: GSO/테이블 Reader 구현~~ ✅ 해결됨
- **상태**: 테이블 컨트롤 Reader 구현 완료
- **결과**: `FindControl_WithFilter_ShouldSucceed` 테스트 통과

### ~~우선순위 5: 기타 미구현 기능~~ ✅ 해결됨
- URL에서 HWP 읽기 기능 ✅
- 대용량 파일 처리 ✅
- 컨트롤 필터 기능 ✅

---

## 🔧 향후 개선 사항 (선택적)

### HWP 버전 호환성 확장
- **파일**: `src/hwplibsharp/Reader/` 디렉토리
- **작업**: minor version 59 이상의 HWP 파일 형식 완전 지원
- **참고**: Java 버전 hwplib의 최신 구현 참조
- **현황**: 현재 경고 메시지만 출력되며 기능은 정상 작동

---

## 📁 관련 파일 목록

### 테스트 파일 (Java 버전과 1:1 대응)
- `src/hwplibsharp.test/AddingParagraphBetweenClonedHwpFileTest.cs`
- `src/hwplibsharp.test/AddingParagraphBetweenHwpFileTest.cs`
- `src/hwplibsharp.test/ChangingImageTest.cs`
- `src/hwplibsharp.test/ChangingPaperSizeTest.cs`
- `src/hwplibsharp.test/ChangingParagraphTextTest.cs`
- `src/hwplibsharp.test/CloningHwpFileTest.cs`
- `src/hwplibsharp.test/ExtractingTextFromBigFileTest.cs`
- `src/hwplibsharp.test/ExtractingTextTest.cs`
- `src/hwplibsharp.test/ExtractingTextWithParaHeadTest.cs`
- `src/hwplibsharp.test/FindingAllFieldTest.cs`
- `src/hwplibsharp.test/FindingControlTest.cs`
- `src/hwplibsharp.test/GettingClickHereFieldTextTest.cs`
- `src/hwplibsharp.test/InsertingCharShapeTest.cs`
- `src/hwplibsharp.test/InsertingHeaderFooterTest.cs`
- `src/hwplibsharp.test/InsertingHyperLinkTest.cs`
- `src/hwplibsharp.test/InsertingImageCellTest.cs`
- `src/hwplibsharp.test/InsertingImageTest.cs`
- `src/hwplibsharp.test/InsertingSectionAndChangingPaperSizeTest.cs`
- `src/hwplibsharp.test/InsertingTableTest.cs`
- `src/hwplibsharp.test/InsertingTableWithImageBackTest.cs`
- `src/hwplibsharp.test/MakingBlankFileTest.cs`
- `src/hwplibsharp.test/MakingCaptionTest.cs`
- `src/hwplibsharp.test/MergingCellTest.cs`
- `src/hwplibsharp.test/ReadingDistributionHwpFileTest.cs`
- `src/hwplibsharp.test/ReadingHwpFromFileTest.cs`
- `src/hwplibsharp.test/ReadingHwpFromUrlTest.cs`
- `src/hwplibsharp.test/RemovingTableRowTest.cs`
- `src/hwplibsharp.test/RewritingHwpFileTest.cs`
- `src/hwplibsharp.test/SettingCellTextByFieldTest.cs`
- `src/hwplibsharp.test/SettingClickHereFieldTextTest.cs`
- `src/hwplibsharp.test/SettingFieldTextTest.cs`
- `src/hwplibsharp.test/SimpleEditingHwpFileTest.cs`

### 핵심 구현 파일
- `src/hwplibsharp/CompoundFile/Wrappers.cs`
- `src/hwplibsharp/CompoundFile/CompoundFileReader.cs`
- `src/hwplibsharp/CompoundFile/CompoundStreamReader.cs`
- `src/hwplibsharp/CompoundFile/CompoundFileWriter.cs`
- `src/hwplibsharp/Reader/HWPReader.cs`
- `src/hwplibsharp/Reader/BodyText/ForSection.cs`

### 테이블 Reader 관련 파일
- `src/hwplibsharp/Reader/BodyText/Control/ForControlTable.cs`
- `src/hwplibsharp/Reader/BodyText/Control/Tbl/ForTable.cs`
- `src/hwplibsharp/Reader/BodyText/Control/Tbl/ForCell.cs`
- `src/hwplibsharp/Reader/BodyText/Control/Gso/Part/ForCtrlHeaderGso.cs`
- `src/hwplibsharp/Reader/BodyText/Control/Gso/Part/ForCaption.cs`

### 테스트 데이터
- `sample_hwp/basic/` - 원본 HWP 파일들
- `sample_hwp/result/` - 쓰기 테스트 결과 파일들

---

## 🔗 참조 자료

- **원본 Java 라이브러리**: [neolord0/hwplib](https://github.com/neolord0/hwplib)
- **OpenMcdf 라이브러리**: [ironfede/openmcdf](https://github.com/ironfede/openmcdf)
- **HWP 파일 형식 문서**: 한글과컴퓨터 공식 문서

---

## 📝 변경 이력

| 날짜 | 변경 내용 |
|------|-----------|
| 2026년 9월 13일 | 이슈 #18 업스트림 `6746c27f` 동기화, 짧은 GSO 헤더 읽기 수정, 회귀 테스트 9개 추가, 각 대상에서 172/173 성공 및 네트워크 테스트 1개 건너뜀, HWP 88개 생성 또는 갱신 |
| 2026-08-22 | 이슈 #17 업스트림 `cdfb2690` 동기화, PictureInfo 순서 회귀 테스트 추가, 163/164 성공(1개 네트워크 테스트 건너뜀) |
| 2025-12-16 (밤) | 🎉 **100% 테스트 성공 달성** (143/143), Java 버전과 테스트 케이스 통일 |
| 2025-12-16 (오후 2) | 테스트 파일명 충돌 수정, 실패 테스트 0개 달성 (142/148 성공) |
| 2025-12-16 (오후) | Section 파싱, 컨트롤 파싱, CompoundFileWriter 개선으로 테스트 성공률 47.3% → 95.3% 향상 |
| 2025-12-16 (오전) | 최초 문서 작성, 테스트 현황 분석 |
