using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text timerText;
    public Text lapCountText;
    public Text countDownText;
    public CarScript car;
    // Start is called before the first frame update
    void Start()
    {
        countDownText.text = "";
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "Time:" + RaceManager.instance.timer.ToString("f2");
        lapCountText.text = "LapCount:" + car.lapCount.ToString();
    }

    IEnumerator CountDown() {
        countDownText.text = "3";
        yield return new WaitForSeconds(1.0f);

        countDownText.text = "2";
        yield return new WaitForSeconds(1.0f);

        countDownText.text = "1";
        yield return new WaitForSeconds(1.0f);

        countDownText.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        countDownText.text = "";
        RaceManager.instance.isRacing = true;
    }
}
