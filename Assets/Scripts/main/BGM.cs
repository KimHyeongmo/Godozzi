using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{

    public static BGM singleton = null;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    bool isplaying1 = false;
    bool isplaying2 = false;

    // Update is called once per frame
    void Update()
    {
        if((SceneManager.GetActiveScene().name == "title" || SceneManager.GetActiveScene().name == "select_stage"))
        {
            if(isplaying1 == false)
            {
                isplaying2 = false;
                isplaying1 = true;

                //±‚¡∏≤® ≤Ù±‚
                GameObject.Find("gameplaying").GetComponent<AudioSource>().Stop();

                //Ω««‡
                GameObject.Find("gamewaiting").GetComponent<AudioSource>().Play();
            }
        }
        else if ((SceneManager.GetActiveScene().name == "SampleScene"))
        {
            if (isplaying2 == false)
            {
                isplaying1 = false;
                isplaying2 = true;
                //±‚¡∏≤® ≤Ù±‚
                GameObject.Find("gamewaiting").GetComponent<AudioSource>().Stop();
                //Ω««‡
                GameObject.Find("gameplaying").GetComponent<AudioSource>().Play();
            }
        }
        else if (SceneManager.GetActiveScene().name == "clear")
        {
            //±‚¡∏≤® ≤Ù±‚
            GameObject.Find("gamewaiting").GetComponent<AudioSource>().Stop();
            GameObject.Find("gameplaying").GetComponent<AudioSource>().Stop();
            isplaying1 = false;
            isplaying2 = false;
        }
    }
}
