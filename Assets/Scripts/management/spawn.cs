using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("godozzi").transform.position = transform.position;
    }
}
