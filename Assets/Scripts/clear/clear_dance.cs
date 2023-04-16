using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear_dance : MonoBehaviour
{


    // Update is called once per frame
    void Start()
    {
        StartCoroutine(dance());
    }

    IEnumerator dance()
    {
        while (true)
        {
            GetComponent<SpriteRenderer>().flipX = GetComponent<SpriteRenderer>().flipX == true ? false : true;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
