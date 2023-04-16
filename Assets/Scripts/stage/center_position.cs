using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class center_position : MonoBehaviour
{
    GameObject center;
    GameObject godozzi;

    private void Awake()
    {
        center = GameObject.Find("center");
        godozzi = GameObject.Find("godozzi");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = center.transform.position - godozzi.transform.position;
        direction = direction.normalized;
        float angle = Mathf.Acos(direction.y) * Mathf.Rad2Deg;
        angle = direction.x < 0 ? angle : angle * -1; //각도가 +일 때 시계반대방향으로 회전하므로
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
