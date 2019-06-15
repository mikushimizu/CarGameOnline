using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarScript : MonoBehaviour
{
    private int checkCount;
    public int lapCount;
    // Start is called before the first frame update
    void Start()
    {
        checkCount = 0;
        lapCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("チェックポイント" + checkCount + "個目、" + lapCount + "週目です。");

       switch (other.gameObject.name)
        {
            case "CheckPoint1":
                if (checkCount == 0) checkCount++;
                break;
            case "CheckPoint2":
                if (checkCount == 1) checkCount++;
                break;
            case "CheckPoint3":
                if (checkCount == 2) checkCount++;
                break;
            case "StartGoalChecker":
                if (checkCount != 3){
                    return;
                }
                if (lapCount != 3)
                {
                    lapCount++;
                    checkCount = 0;
                    return;
                }
                Debug.Log("ゴール！");
                RaceManager.instance.isRacing = false;
                SceneManager.LoadScene("Result");
                break;
        }
    }
}
