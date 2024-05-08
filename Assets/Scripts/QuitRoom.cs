using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class QuitRoom : MonoBehaviourPunCallbacks

{
   

    #region Photon Callbacks
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(2);
    }

    #endregion


    #region Public Methods
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    #endregion
}
