<div align="center"><h1> RuningGame</h1>
</div>


# 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [팀소개](#팀소개)
3. [프로젝트 계기](#프로젝트-계기)
4. [주요기능](#주요기능)
5. [개발기간](#개발기간)
6. [기술스택](#기술스택)
7. [와이어프레임](#와이어프레임)
8. [UML](#UML)
9. [프로젝트 파일 구조](#프로젝트-파일-구조)
10. [Trouble Shooting](#trouble-shooting)
# 프로젝트 소개
 - 프로젝트 이름 : RuningGame
 - 개발언어 및 엔진 : C#, 유니티3D 
 - ## 게임 설명
    몰려오는 좀비를 죽이는 게임입니다. 아이템을 먹어 플레이어를 강화하거나, 동료를 늘려보세요!
 - ## 게임 플레이 방식 
|![image](https://github.com/ChungRaeGyu/RuningGame/assets/125470068/adcd937d-4d02-4791-af68-dfc4e1c5d131)|![image](https://github.com/ChungRaeGyu/RuningGame/assets/125470068/457cca5a-a4c0-4ed7-9bbd-5fccfd745b79)|![image](https://github.com/ChungRaeGyu/RuningGame/assets/125470068/ebb62819-a26a-4799-8813-9bf4ff4e6376)|
|:---:|:---:|:---:|
|로비|업적|게임시작 전|
|스테이지를 선택합니다.<br>이전 스테이지 클리어시 다음 스테이지가 오픈 됩니다.|진행중인 업적을 표시합니다.|스테이지에 대한 설명과 게임시작 버튼이 있습니다.|
|![image](https://github.com/ChungRaeGyu/RuningGame/assets/125470068/fdd812e8-2002-425c-9717-319ad3514dfd)|![image](https://github.com/ChungRaeGyu/RuningGame/assets/125470068/acccedec-8694-4999-bd38-02872c37a9d0)|![image](https://github.com/ChungRaeGyu/RuningGame/assets/125470068/9efc130e-072c-47c1-b240-2686fab8401e)|
|게임진행|게임종료|설정|
|게임을 진행합니다. |클리어시 스테이지이름을 알려줍니다. 로비로 돌아가는 버튼이 있습니다.|배경음악, 효과음, 화면사이즈를 조절할 수 있습니다.|
# 팀소개
 - 팀장 : 문경건
 - 팀원 : 최윤화
 - 팀원 : 고도희
 - 팀원 : 정래규
# 프로젝트 계기
 출시를 해보려고 합니다.
# 주요기능
 - 플레이어의 움직임(new InputSystem)
 - 적 식별(RayCast)
 - 플레이어의 공격
 - 맵 재사용
 - 아이템의 랜덤 샌성
 - 몬스터의 움직임(플레이어를 따라온다.)

# 개발기간
 개발 기간 : 2024.06.03 ~ 2024.06.11
# 기술스택
|![image](https://github.com/choiyunhwa/RuningGame/assets/82863756/bca72594-c744-4bfe-9432-a59b58a16295)|![image](https://github.com/choiyunhwa/RuningGame/assets/82863756/ab527bb2-a85d-45c6-9036-faa7533520ce)|![image](https://github.com/choiyunhwa/RuningGame/assets/82863756/e53fce63-6924-40f1-83fa-8055a89bc352)|![image](https://github.com/choiyunhwa/RuningGame/assets/82863756/80297e45-d969-4ffc-bd03-0235beb3ed23)
|:---:|:---:|:---:|:---:|
|Unity|C#|VisualStudio|GitHub|
# 와이어프레임
![image](https://github.com/choiyunhwa/RuningGame/assets/82863756/e5982a75-230f-44db-9aa8-244bc3c92ec2)
# UML
![image](https://github.com/choiyunhwa/RuningGame/assets/82863756/14952685-0b58-43d6-abc3-1e8187927588)
# 프로젝트 파일 구조
![image](https://github.com/choiyunhwa/RuningGame/assets/125470068/6e4b841b-5ea2-453c-b36d-6fbdf18e4975)
# Trouble Shooting
문경건
- Problem : 캐릭터를 움직일지, 맵을 움직일 지 선택 고민
- Cause : 게임 설계 상 두 가지 방법 모두 가능 / 플레이어 경험 최적화 필요 / 구현 복잡성과 성능 고려
- Solve : 캐릭터 고정으로 충돌 검사와 애니메이션 처리가 단순해져 성능이 향상 되고 좌표 시스템의 일관성으로 효과 추가가 쉬워져 맵을 움직이는 것으로 결정

고도희
- Problem : 마우스의 방향을 향해 플레이어를 이동 처리하려고 하였으나 플레이어의 이동량이 작아 움직임이 느껴지지 않음
- Cause : ScreenToWorldPoint 함수를 사용하여 마우스 위치를 받아오는 과정에서 X좌표값의 문제로 원하는 이동 처리가 제대로 구현되지 않음
- Solve : Ray를 사용하여 ScreenPointToRay 함수를 호출하여 마우스 입력과 함께
마우스가 가르키는 지점에서 시작하는 레이를 생성한 뒤 마우스의 위치와 플레이어의 위치를 동일하게 만듬

정래규
- Problem : Json으로 정보를 저장하기 위해 Dictionary 사용하였으나 저장된 Json파일에 정보가 나타나지 않음
- Cause : 저장 시 직렬화를 해야했으나 Dictionary는 직렬화되지 않음
- Solve : List를 사용하여 직렬화 문제를 해결

최윤화
- Problem : 한 곳의 위치에서 플레이어가 생성되었을때 플레이어 간의 충돌로 인해 튕기는 문제 발생
- Solve : insideUnitSphere을 이용하여 플레이어의 뒤쪽에서 랜덤으로 생성한 뒤
주변을 검사하여 플레이어에게 근처로 이동 처리

