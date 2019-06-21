using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : Photon.PunBehaviour
{
    private GameObject carPrefab;
    private PhotonView myPhotonView;
    // Start is called before the first frame update
    void Start()
    {
        //this.myPhotonView = GetComponent<PhotonView>();
        /*if (myPhotonView.isMine)
        {*/
            //CameraをCarの子オブジェクトとする
            /*
            transform.parent = carPrefab.transform;
            */
            transform.position += new Vector3(0, 3, 5);
            
        /*}*/
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
