using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class UIManager : MonoBehaviour
{

    public GameObject playerName;

    // Start is called before the first frame update
    void Start()
    {
        playerName.GetComponent<TextMeshPro>().text = PhotonNetwork.NickName;
    }
}
