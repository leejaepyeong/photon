using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [Header("DisconnectPanel")]
    public GameObject DisconnectPanel;
    public InputField NicknameInput;

    [Header("RoomPanel")]
    public GameObject RoomPanel;
    public Text ValueTxt, PlayersTxt, ClickUpgradeTxt, AutoUpgradeTxt;
    public Button ClickUpgradeBtn, AutoUpgradeBtn;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(540,960,false);

    }

    public void Connect()
    {
        PhotonNetwork.LocalPlayer.NickName = NicknameInput.text;
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        ShowPanel(DisconnectPanel);
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 5}, null);   //  방에 참가
        // 플레이어 수 / 방이름
    }

    // Room에 입a
    public override void OnJoinedRoom()
    {
        ShowPanel(RoomPanel);
        PhotonNetwork.Instantiate("Player",Vector3.zero, Quaternion.identity);
        // Player라는 이름을 가진 포톤 뷰 를  방에 입
    }

    void ShowPanel(GameObject CurPanel)
    {
        DisconnectPanel.SetActive(false);
        RoomPanel.SetActive(false);
        CurPanel.SetActive(true);
    }

    // 자기자신 찾기
    PlayerScript FindPlayer()
    {
        foreach(GameObject Player in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (Player.GetPhotonView().IsMine) return Player.GetComponent<PlayerScript>();
        }

        return null;
    }

    public void Click()
    {
        PlayerScript Player = FindPlayer();
        Player.value += Player.valuePerClick;  // 클릭 값 만큼 증가
        
    }

    public void ClickUpgrade()
    {
        PlayerScript Player = FindPlayer();

        if(Player.value >= Player.clickUpgradeCost)
        {
            Player.value -= Player.clickUpgradeCost;

            Player.valuePerClick += Player.clickUpgradeAdd;

            Player.clickUpgradeCost += 5;

            ClickUpgradeTxt.text = "비용 : " + Player.clickUpgradeCost + "\n+" + Player.clickUpgradeAdd + "/클릭";
        }
    }

    public void AutoUpgrade()
    {
        PlayerScript Player = FindPlayer();

        if (Player.value >= Player.autoUpgradeCost)
        {
            Player.value -= Player.autoUpgradeCost;

            Player.valuePerClick += Player.autoUpgradeAdd;

            Player.autoUpgradeCost += 5000;

            AutoUpgradeTxt.text = "비용 : " + Player.autoUpgradeCost + "\n+" + Player.autoUpgradeAdd + "/초";
        }
    }



    // player들 정보 가져오기
    void ShowPlayers()
    {
        string playersTxt = "";

        foreach(GameObject Player in GameObject.FindGameObjectsWithTag("Player"))
        {
            playersTxt = Player.GetPhotonView().Owner.NickName + " / " + Player.GetComponent<PlayerScript>().value.ToString() + "\n";
        }

        PlayersTxt.text = playersTxt;
    }

    void EnableUpgrade()
    {
        PlayerScript Player = FindPlayer();

        ClickUpgradeBtn.interactable = (Player.value >= Player.clickUpgradeCost);
        AutoUpgradeBtn.interactable = (Player.value >= Player.autoUpgradeCost);
    }

    // Update is called once per frame
    void Update()
    {
        // 포톤 인룸 상태 아니면 종료
        if (!PhotonNetwork.InRoom) return;

        ShowPlayers();
        EnableUpgrade();
    }
}
