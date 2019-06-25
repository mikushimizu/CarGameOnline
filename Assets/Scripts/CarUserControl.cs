using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;
using Photon;

public class CarUserControl : Photon.PunBehaviour
{
    private PhotonView myPhotonView;
    private CarController m_Car;
    float h; //horizontal
    float v; //Vertical

    private void Awake()
    {
        this.myPhotonView = GetComponent<PhotonView>();
        m_Car = GetComponent<CarController>();

        if (myPhotonView.isMine) //Carが自分の車である場合
        {
            GameObject camPrefab = (GameObject)Resources.Load("CameraPrefab"); //ResourcesフォルダからCameraPrefabをとってくる
            Vector3 RelativePosition = new Vector3(0, 3, 5);
            GameObject cam = Instantiate(camPrefab, transform.position + RelativePosition, transform.rotation); //CameraPrefabを生成する
            cam.transform.parent = gameObject.transform; //Cameraの親オブジェクトはCarとする
            //この時点でCameraの相対座標は(0,0,0)になっているので、CameraScriptで位置を調整する
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