using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    Button botton;

    // Start is called before the first frame update

    private void Awake()
    {
        botton = GetComponent<Button>();
    }
    void Start()
    {
        botton.onClick.AddListener(GameObject.Find("stage_management2").GetComponent<Stage_management2>().selection);
    }
}
