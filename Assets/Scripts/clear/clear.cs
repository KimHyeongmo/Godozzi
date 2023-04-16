using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class clear : MonoBehaviour
{
    float clear_time;

    public TextMeshProUGUI time_object;
    
    // Start is called before the first frame update
    void Awake()
    {
        clear_time = GameObject.Find("stage_management").GetComponent<Stage_management>().clear_time;
    }

    // Update is called once per frame
    void Start()
    {
        time_object.text = System.Math.Round(clear_time) + "√ ";
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("select_stage");
        }
    }
}
