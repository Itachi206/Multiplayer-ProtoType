using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    GameObject controller;    

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()    
    {
        int randomNumber = Random.Range(-10, 10);
        controller = PhotonNetwork.Instantiate("PlayerController", new Vector3(randomNumber, 0f, randomNumber), Quaternion.identity);
    }
}
