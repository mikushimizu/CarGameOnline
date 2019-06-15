using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    public static RaceManager instance;
    public float timer;
    public bool isRacing;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        isRacing = false;
    }

    void Update()
    {
        if(isRacing == true)
        {
            timer += Time.deltaTime;

        }

    }
}
