using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Stage_management2 : MonoBehaviour
{
    GameObject main_management;

    private void Awake()
    {
        main_management = GameObject.Find("stage_management");
    }

    public void selection()
    {
        string stage_name = EventSystem.current.currentSelectedGameObject.name;
        main_management.GetComponent<Stage_management>().SelectStage(stage_name);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            back();
        }
    }

    public void back()
    {
        SceneManager.LoadScene("title");
    }
}
