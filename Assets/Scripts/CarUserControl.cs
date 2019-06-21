using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

public class CarUserControl : Photon.PunBehaviour
{
    private PhotonView myPhotonView;
    private CarController m_Car;
    float h; //horizontal
    float v; //Vertical

    private void Start()
    {
        this.myPhotonView = GetComponent<PhotonView>();
        m_Car = GetComponent<CarController>();
        /*
        PhotonNetwork.Instantiate("CameraPrefab", transform.position, transform.rotation, 0);
        */
        if (myPhotonView.isMine) //Carが自分の車である場合
        {
            Debug.Log("できてる");
            GameObject camObj = (GameObject)Resources.Load("CameraPrefab");
            //Carを親として、CameraPrefabを生成する。
            //Cameraの相対座標は(0,0,0)になっているので、CameraScriptで位置を調整する
            //GameObject cam = PhotonNetwork.Instantiate("CameraPrefab", transform.position, transform.rotation, 0);
            GameObject cam = Instantiate(camObj, transform.position, transform.rotation);
            Debug.Log(cam.transform.parent);
            cam.transform.parent = gameObject.transform;
            Debug.Log(cam.transform.parent.ToString());
        }
    }
    private void FixedUpdate()
    {
        
        if (myPhotonView.isMine)
        {
            if (RaceManager.instance.isRacing == true)
            {
                h = CrossPlatformInputManager.GetAxis("Horizontal");
                v = CrossPlatformInputManager.GetAxis("Vertical");
            }
            
            m_Car.Move(h, v, v, 0f);
        }
    }
}