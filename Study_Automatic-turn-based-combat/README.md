# [턴제 자동 전투] 2022.12.26 월요일

# 과제목적

---

자동사냥을 만들어보자

# 과제 내용

---

- 두 명의 서로 다른 플레이어가 전투를 벌인다.
- 플레이어의 머리위엔 체력바가 있다.
- 플레이어가 피격을 당하면 머리위에 대미지가 숫자로 표시되며 체력바가 줄어든다.
    - 심화) 숫자가 위로 움직이며 서서히 투명해지며 사라진다.
    - 심화) 체력바가 즉시 줄어들지 않고 서서히 줄어든다.
- 플레이어는 **속도**라는 스탯을 가지고 있다.
    - 속도는 게임을 시작했을때 정해지며, 상대방과 같을수도 있고 다를수도 있다.
- 플레이어는 **행동 게이지**를 가지고 있다
    - 행동 게이지는 체력바 밑에 **바** 형태로 있으며, 시간이 흐를때마다 점점 차오른다.
        - 심화) 행동게이지가 즉시 차오르지 않고 서서히 차오른다.
        서서히 차오르지만 눈으로 봤을때 게이지가 차오르는 중이어도, 수치상 가득 찼다면 공격을 한다.
    - 차오르는 속도는 **속도**스텟에 영향을 받는다.
        - 속도가 높을수록 빠르게 차오르고 낮을수록 느리게 차오른다.
    - 행동 게이지가 가득 차면 공격을 할 수 있다. 공격을 하게되면 행동게이지가 0으로 초기화된다.
        - 심화) 행동게이지가 가득차서 공격을 하게되면 플레이어가 상대 플레이어앞까지 이동했다가 돌아오는 공격 연출을 한다. 공격연출중엔 상대 플레이어의 행동 게이지는 잠시동안 오르지 않는다.
- 플레이어중 한 명의 체력이 0이된다면 전투를 종료한다.(게이지가 차오르지 않는다)