using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_start : MonoBehaviour
{

    public void ClickStartButton()
    {
        SceneManager.LoadScene("select_stage");
    }

    public void ClickExitButton()
    {

        //UnityEditor.EditorApplication.isPlaying = false; //�����Ϳ�

        Application.Quit(); //�����

    }
}
