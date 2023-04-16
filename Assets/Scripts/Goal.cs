using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement; //¿”Ω√

public class Goal : MonoBehaviour
{
    float timer = 0;
    public Text timer_object;

    float end_time;

    bool load = true;

    // Update is called once per frame
    void Update()
    {
        timer += (Time.deltaTime/2);
        timer_object.text = System.Math.Round(timer) + "√ ";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "godozzi" && load)
        {
            end_time = timer;

            GameObject managing = GameObject.Find("stage_management");
            managing.GetComponent<Stage_management>().clear_time = end_time;
            managing.GetComponent<Stage_management>().goal_fading();

            load = false;

        }
    }


}
