using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_rigid : MonoBehaviour
{
    Vector3 parent_transform;
    Transform platform_transform;
    Rigidbody2D platform_rigid;

    Vector3 past_position = new Vector3(0, 0, 0);
    Vector3 current_position = new Vector3(0, 0, 0);

    float position_change;

    float radius;


    // Start is called before the first frame update
    void Awake()
    {
        parent_transform = transform.parent.position;
        platform_transform = GetComponent<Transform>();
        platform_rigid = GetComponent<Rigidbody2D>();
        radius = (parent_transform - platform_transform.position).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        //test3();
    }

    void FixedUpdate()
    {
        //test4();
        test2();
        //test5();
    }

    void test5()
    {
        Vector3 mouseposition_raw = Input.mousePosition;
        current_position = mouseposition_raw;

        if (Input.GetMouseButton(0))
        {
            position_change = past_position.x - current_position.x;
            position_change /= 512;
            Debug.Log("hi");
        }

        if (Mathf.Abs(position_change) >= 0.1)
        {
            Debug.Log("hi2");
            float rad = Mathf.Deg2Rad * position_change;
            float x = radius * Mathf.Sin(rad);
            float y = radius * Mathf.Cos(rad);

            platform_rigid.MovePosition(transform.position + new Vector3(x, y));
            platform_rigid.MoveRotation(Quaternion.Euler(0, 0, position_change * -1));
        }

        past_position = current_position;
    }

    void test4()
    {
        Vector3 mouseposition_raw = Input.mousePosition;
        current_position = mouseposition_raw;

        if (Input.GetMouseButton(0))
        {
            Vector2 gravity_sub = (parent_transform - platform_transform.position);
            Vector2 direction = new Vector2(-1 * gravity_sub.y, gravity_sub.x).normalized;
            platform_rigid.velocity = direction * 10 * (past_position.x - current_position.x);
        }

        past_position = current_position;
        
    }

    void test3()
    {
        Vector3 mouseposition_raw = Input.mousePosition;
        current_position = mouseposition_raw;

        if (Input.GetMouseButton(0))
        {
            position_change = past_position.x - current_position.x;
            position_change /= 1024;
            position_change = Mathf.PI / 2 - position_change;
        }

        past_position = current_position;
    }

    void test2()
    {
        Vector3 mouseposition_raw = Input.mousePosition;
        current_position = mouseposition_raw;

        if (Input.GetMouseButton(0))
        {
            position_change = past_position.x - current_position.x;

            position_change *= -1;

            if (Mathf.Abs(position_change) < 40)
            {


            }
            else
            {
                position_change = position_change < 0 ? -40 : 40;
            }
            position_change /= 4096; //stage별로 조정 //4096 default //작을수록 확확꺾임
            position_change = Mathf.PI / 2 - position_change;

            if (Mathf.Abs(position_change) >= 0.1)
            {
                

                Vector2 gravity_sub = (parent_transform - platform_transform.position);

                Vector2 direction = new Vector2((Mathf.Cos(position_change) * gravity_sub.x - Mathf.Sin(position_change) * gravity_sub.y), (Mathf.Sin(position_change) * gravity_sub.x + Mathf.Cos(position_change) * gravity_sub.y)).normalized;
                direction = direction * gravity_sub.magnitude * Mathf.Cos(position_change) * 2;
                Vector2 moving = platform_transform.position;
                platform_rigid.MovePosition(moving + direction);
                transform.Rotate(new Vector3(0, 0, 2 * (Mathf.PI / 2 - position_change)*(-180/Mathf.PI)));
                //Debug.Log(position_change);
                //platform_rigid.MoveRotation(Quaternion.Euler(0,0,(Mathf.PI / 2 - position_change) * (180/Mathf.PI)));
            }
        }

        past_position = current_position;

    }

    void test()
    {
        Vector2 gravity_sub = (parent_transform - platform_transform.position).normalized;
        Vector2 direction = new Vector2(-1 * gravity_sub.y, gravity_sub.x).normalized;
        float radius = gravity_sub.magnitude;
        platform_rigid.velocity = direction * 30;
        Debug.Log(platform_rigid.velocity);
    }
}
