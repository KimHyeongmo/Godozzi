using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stop : MonoBehaviour
{
    bool ispause = false;

    public GameObject Stop_UI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(ispause == false)
            {
                StopGame();
            }
            else if(ispause == true)
            {
                ResumeGame();
            }
        }
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        ispause = true;
        OpenUI();
    }

    public void ResumeGame()
    {
        Time.timeScale = 2;
        ispause = false;
        CloseUI();
    }

    void OpenUI()
    {
        Stop_UI.SetActive(true);
    }

    void CloseUI()
    {
        Stop_UI.SetActive(false);
    }

    public void StageExit()
    {
        Time.timeScale = 2;
        ispause = false;
        CloseUI();
        SceneManager.LoadScene("select_stage");
    }

}
