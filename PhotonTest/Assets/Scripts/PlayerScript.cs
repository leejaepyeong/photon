using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerScript : MonoBehaviourPun, IPunObservable
{
    public int value;   //클릭 갯수
    public int valuePerClick;
    public int clickUpgradeCost, clickUpgradeAdd;   //비용 및 횟수
    public int autoUpgradeCost, autoUpgradeAdd; //자동 증가 비용 및 횟 
    NetworkManager NM;
    PhotonView PV;

    

    void Start()
    {
        PV = photonView;
        NM = GameObject.FindWithTag("NetworkManager").GetComponent<NetworkManager>();
    }

    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(value);
        }
        else
        {
            value = (int)stream.ReceiveNext();
        }
    }

    void Update()
    {
        if (!PV.IsMine) return;
        // 자기자신이 아니면 함수 끝내기

        NM.ValueTxt.text = value.ToString();
    }
}
