using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        resultText.text = "Time:" + RaceManager.instance.timer.ToString("f2");      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("PvP");
        }
    }
}
