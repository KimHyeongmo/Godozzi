using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class goal_position : MonoBehaviour
{
    GameObject goal;
    GameObject godozzi;

    public Text Distance;

    private void Awake()
    {
        goal = GameObject.Find("goal");
        godozzi = GameObject.Find("godozzi");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = goal.transform.position - godozzi.transform.position;

        int distance = (int)direction.magnitude;
        Distance.text = (distance/10) + "m";

        direction = direction.normalized;
        float angle = Mathf.Acos(direction.y) * Mathf.Rad2Deg;
        angle = direction.x < 0 ? angle : angle * -1; //각도가 +일 때 시계반대방향으로 회전하므로
        transform.rotation = Quaternion.Euler(0,0,angle);
        
    }
}
