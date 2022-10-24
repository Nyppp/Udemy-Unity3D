# Udemy-Unity3D
 Complete C# Unity Game Developer 3D 강의 학습 기록 저장소

|프로젝트 이름|요약|저장소 링크|
|:----:|:----:|:----:|
|Obstacle Course|[Summery](#obstacle-course)|<a href=https://github.com/Nyppp/Udemy-Unity3D/tree/main/ObstacleCourse>link</a>|
|Project Boost|[Summery](#project-boost)|<a href=https://github.com/Nyppp/Udemy-Unity3D/tree/main/ProjectBoost>link</a>|
|Argon Assault|[Summery](#argon-assault)|<a href=https://github.com/Nyppp/Udemy-Unity3D/tree/main/ArgonAssult/Assets>link</a>|
|Realm Rush|[Summery](#argon-assault)|<a href=https://github.com/Nyppp/Udemy-Unity3D/tree/main/Realm%20Rush>link</a>|
|Zombie Runner|[Summery](#zombie-runner)|<a href=https://github.com/Nyppp/Udemy-Unity3D/tree/main/Zombie%20Runner>link</a>|
#
# 학습 기록

# Obstacle Course
### 위, 아래 방향키를 사용해 장애물을 피해 목적지로 이동하는 게임
- 유니티에서의 변수 선언과 접근 제한자 및 인스펙터 사용 방법 학습 + SerializedField
- 유니티 제공 콜백함수(Start, Update, FixedUpdate) 사용한 오브젝트 조작
- Input클래스 사용한 오브젝트 이동
- Cinemachin을 사용해 오브젝트를 따라다니는 Follow Camera 기능 구현
- 기본적인 레벨 디자인 및 씬 내의 오브젝트 배치


# Project Boost
### 로켓을 발사시켜 부스트, 회전을 이용해 목적지로 이동하는 게임
- Update 함수에서 키 입력 처리를 받고, 플레이어의 물리적 처리를 FixedUpdate에서 처리하는 방법 학습
- 오브젝트 회전에서, 직접 transform을 수정하는 것 대신 쿼터니언의 오일러각을 이용해 더 적은 오차로 회전
- 사운드와 파티클 시스템 기본적 사용 방법 학습
- 오브젝트 이동을 sin함수와 같은 수식으로 구현하는 방법 학습

# Argon Assault
### 정해진 경로를 기준으로, 전투기를 움직이며 다가오는 적을 피하거나 레이저를 쏴서 격추시키며 목적지에 도달하는 게임
- 툴을 사용한 터레인 맵 제작 방법 기초 학습
- 타임라인 사용한 컷씬 연출 방법 
- Input 시스템 학습(일반 Input 사용한 키입력 받기 - 업데이트문 사용, InputAction으로 키 매핑하여 입력 받기 - 콜백 처리)
- Lerp(선형 보간)을 통해 플레이어 입력을 받아 회전하는 동작을 자연스럽게 처리
- 인스펙터(툴)를 사용한 라이팅 조정, 포스트 프로세싱을 추가해 조명 보정, 후처리 방법 학습
- 싱글톤 패턴을 사용해 배경음악 재생 오브젝트 구현

# Realm Rush
### 웨이브가 있으며, 이를 막기 위해 타워를 설치하여 막는 타워 디펜스 게임
- 프리펩을 상속하여 자식 프리펩을 만들고 활용하는 방법 학습
- 코루틴 내부에서 Lerp를 사용해 특정 위치로 부드럽게 이동
- 임의의 좌표계 크기를 지정하고, TextMeshPro 사용해 오브젝트 위에 overlay시켜 좌표를 표시하는 방법 학습
- 리스트와 배열의 차이, 힙 메모리 데이터를 스택으로 불러올 때의 메모리 캐싱과 GC 동작 
- 파티클 이펙트에 대한 콜리젼 설정 학습
- 최단경로 알고리즘(BFS, 다익스트라, A*) 기본 학습, BFS를 통한 최단경로 도출

# Zombie Runner
### 1인칭 좀비 슈터 게임
- 학습 중...
