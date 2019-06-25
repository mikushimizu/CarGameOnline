using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class PhotonManager : Photon.PunBehaviour
{
    void Start()
    {
        // Photonに接続する(引数でゲームのバージョンを指定できる)
        PhotonNetwork.ConnectUsingSettings(null);
    }

    // ロビーに入ると呼ばれる
    void OnJoinedLobby()
    {
        Debug.Log("ロビーに入りました。");

        // ルームに入室する
        PhotonNetwork.JoinRandomRoom();
    }

    // ルームに入室すると呼ばれる
    void OnJoinedRoom()
    {
        Debug.Log("ルームへ入室しました。");
        //CarPrefabを生成する
        transform.rotation = Quaternion.Euler(0, 180, 0); //Carの向きが逆になってになってしまう問題を解決
        if (PhotonNetwork.countOfPlayers < 2)
        { 
            transform.position = new Vector3(66, 0, 0);
            PhotonNetwork.Instantiate("CarPrefab", transform.position, transform.rotation, 0);
        }
        if (PhotonNetwork.countOfPlayers == 2)
        {
            transform.position = new Vector3(60, 0, 7); //生成位置
            PhotonNetwork.Instantiate("CarPrefab", transform.position, transform.rotation, 0);
        }
        if (PhotonNetwork.countOfPlayers == 3)
        {
            Vector3 spawnPosition = new Vector3(54, 0, 14); //生成位置
            PhotonNetwork.Instantiate("CarPrefab", spawnPosition, Quaternion.identity, 0);
        }
    }

    // ルームの入室に失敗すると呼ばれる
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("ルームの入室に失敗しました。");

        // ルームがないと入室に失敗するため、その時は自分で作る
        // 引数でルーム名を指定できる
        PhotonNetwork.CreateRoom("myRoomName");
    }

}
