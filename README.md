# photon


![image](https://user-images.githubusercontent.com/80494367/123888473-88e19280-d98e-11eb-95c2-f2490927416c.png)

![image](https://user-images.githubusercontent.com/80494367/123888552-b595aa00-d98e-11eb-915a-57c9b6e432cc.png)

![image](https://user-images.githubusercontent.com/80494367/123888749-1fae4f00-d98f-11eb-87e0-86f6597879e1.png)
 
 ![image](https://user-images.githubusercontent.com/80494367/123888982-89c6f400-d98f-11eb-9665-7fec55b5b6f3.png)
 
 Unreliable : 송신만 해주고  수신 시 손실가능 (계속 송신이라  무거움)
 Unreliable On Change : 가장 자주 사용
 
 ![image](https://user-images.githubusercontent.com/80494367/123889179-ea563100-d98f-11eb-8d17-2843a48350de.png)

 우클릭 통해서도  방장 넘길 수 있다. 방장 나가면 보통 2번째 사람이 방장으로
 
 ![image](https://user-images.githubusercontent.com/80494367/123889334-44ef8d00-d990-11eb-8ca1-ea71a228cf1c.png)

네트워크에서 불러올 프리팹 (객체)에  Photon View가 존재해야함 instant사용 가능
Set a RunTime. 실행하면 자동으로 값 입력

![image](https://user-images.githubusercontent.com/80494367/123889584-c6dfb600-d990-11eb-84a3-23b5a2ca54da.png)

Id : 방 참가에 따라 1씩 추가 (1 + 001 / 2 + 001 )
001 ~ 999까지 범위

![image](https://user-images.githubusercontent.com/80494367/123888120-bf6add80-d98d-11eb-82bf-4978d5eda441.png)

### 포톤    플레이어에게 포톤 입히기
자기 자신은 isMine 이 True
상대방은 false

모든 동기화는 photonView를 통해

Photon Transform에서  위치  각도  변경 체크를 통해 변화 가능


![image](https://user-images.githubusercontent.com/80494367/123888177-e1fcf680-d98d-11eb-9224-35f9532fc868.png)

OnConnectedToMaster
  플레이어 수 
  
  
  RPC
  
  ![image](https://user-images.githubusercontent.com/80494367/123889735-10300580-d991-11eb-8c6f-884587d5c283.png)

 ![image](https://user-images.githubusercontent.com/80494367/123890065-951b1f00-d991-11eb-9251-c6acf8f81892.png)
 
 isMine : 로컬 /  isMine 이외는 리모트
 
 같은 View Id를 가진 오브젝트 끼리  RPC 함수를 주고 받기 가능
 
 ![image](https://user-images.githubusercontent.com/80494367/123890443-2db19f00-d992-11eb-94d0-15703b583e35.png)

 
 ![image](https://user-images.githubusercontent.com/80494367/123890855-ec6dbf00-d992-11eb-8f90-e7f09ec11363.png)
 
 allViaServer : 모두가 같은 속도로 진행 되기위해  서버를 거쳐서
 
 ![image](https://user-images.githubusercontent.com/80494367/123891008-32c31e00-d993-11eb-902b-347bb1d27828.png)
 
 ![image](https://user-images.githubusercontent.com/80494367/123891369-c694ea00-d993-11eb-9853-c398bb66d7a0.png)
 
 ![image](https://user-images.githubusercontent.com/80494367/123891422-dc0a1400-d993-11eb-9d5b-4c12ddcda80a.png)

이벤트 보내기

![image](https://user-images.githubusercontent.com/80494367/123891656-35724300-d994-11eb-811a-70fab8feb999.png)

이벤트 받기
 View Id를 판별해서도 이벤트 받기 가능
 
 ![image](https://user-images.githubusercontent.com/80494367/123891842-7b2f0b80-d994-11eb-9e92-1ee050cc3257.png)
 
 onEnable / OnDisable 통해  이벤트 활성화 비활성화 가능
 
 이벤트가 너무 많아지면 무거워져 느려질 수 있음
 RPC와 달리  포톤뷰 안거쳐도 동작 가능
 
 ![image](https://user-images.githubusercontent.com/80494367/123892062-d95bee80-d994-11eb-9837-d2489dd4953f.png)

변수 동기화

![image](https://user-images.githubusercontent.com/80494367/123892337-5c7d4480-d995-11eb-9415-b2d3343a9697.png)

마스터 클라이언트만 보내지고   다른 것은 순서대로 RecieveNext받음


## 동적인 경우

![image](https://user-images.githubusercontent.com/80494367/123892561-ca297080-d995-11eb-9cfa-005d119bc905.png)

![image](https://user-images.githubusercontent.com/80494367/123892637-f218d400-d995-11eb-882b-7ee6a3d03aa2.png)

onPhoton SeializeView 는   서버 불안정 등으로 값의 변화가 중요한 데이터 관리를 위해 사용



실습해보기

![image](https://user-images.githubusercontent.com/80494367/123894132-97cd4280-d998-11eb-8484-45bf509b7116.png)

connectBtn 클릭 통해 접속

 
 ![image](https://user-images.githubusercontent.com/80494367/123912023-7d569180-d9b7-11eb-887a-d79f876d0c48.png)

![image](https://user-images.githubusercontent.com/80494367/123912107-93fce880-d9b7-11eb-9d1a-5bd11f0be40d.png)

![image](https://user-images.githubusercontent.com/80494367/123912154-a37c3180-d9b7-11eb-9ad5-90f7bc485d04.png)

![image](https://user-images.githubusercontent.com/80494367/123912208-b55dd480-d9b7-11eb-8f06-748d0c841ada.png)

![image](https://user-images.githubusercontent.com/80494367/123912274-cb6b9500-d9b7-11eb-8b5a-172efd415240.png)

![image](https://user-images.githubusercontent.com/80494367/123912328-dde5ce80-d9b7-11eb-96a7-3d420580d5e9.png)







  
