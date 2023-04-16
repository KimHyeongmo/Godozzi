using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_management : MonoBehaviour
{
    public float clear_time;

    public static Score_management singleton = null;

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


}
