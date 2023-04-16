using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class center_rotate : MonoBehaviour
{
    Vector3 past_position = new Vector3(0, 0, 0);
    Vector3 current_position = new Vector3(0, 0, 0);
    Vector3 center_position;


    Rigidbody2D center_rigid;

    // Start is called before the first frame update
    void Awake()
    {
        center_rigid = GetComponent<Rigidbody2D>();
        center_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //rotate_center_keyboard();
        //rotate_center_mouse();
        //rotate_x_mouse();
    }

    private void FixedUpdate()
    {
        //rotate_x_mouse2();
        //rotate_x_mouse();
        //rotate_x_mouse_rigidbody();
    }

    void rotate_x_mouse_rigidbody()
    {
        Vector3 mouseposition_raw = Input.mousePosition;
        current_position = mouseposition_raw;

        float position_change;
        position_change = past_position.x - current_position.x;

        if (Input.GetMouseButton(0))
        {
            position_change = past_position.x - current_position.x;
            if (Mathf.Abs(position_change) < 30)
            {

                center_rigid.angularVelocity = position_change;
            }
            else
            {
                center_rigid.angularVelocity = position_change < 0 ? -30 : 30;
            }

        }
        past_position = current_position;
        /*
        Vector3 mouseposition_raw = Input.mousePosition;
        current_position = mouseposition_raw;

        float position_change;
        position_change = past_position.x - current_position.x;

        center_rigid.rotation = center_rigid.rotation * Quaternion.Euler(0f, 0f, 0f);


        if (Input.GetMouseButton(0))
        {
            center_rigid.rotation += position_change;
        }

        past_position = current_position;
        */
    }

    void rotate_x_mouse()
    {
        Vector3 mouseposition_raw = Input.mousePosition;
        current_position = mouseposition_raw;

        float position_change;

        if (Input.GetMouseButton(0))
        {
            position_change = past_position.x - current_position.x;
            if (Mathf.Abs(position_change) < 12)
            {
                
                transform.Rotate(new Vector3(0, 0, position_change / 12));
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, (position_change < 0 ? -12 : 12) / 12));
            }

        }


        past_position = current_position;
    }


    void rotate_x_mouse2()
    {
        Vector3 mouseposition_raw = Input.mousePosition;
        current_position = mouseposition_raw;

        float position_change;

        if (Input.GetMouseButton(0))
        {
            position_change = past_position.x - current_position.x;

            StartCoroutine(Rotate(position_change));

        }


        past_position = current_position;
    }

    IEnumerator Rotate(float a)
    {
        if (a > 8)
            a = 8;
        else if (a < -8)
            a = -8;

        //a /= 512;

        if (a >= 0)
        {
            for (int i = 0; i < 4 * a; i++)
            {
                transform.Rotate(new Vector3(0, 0, 0.01f));
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            for (int i = 0; i < 4 * -1 * a; i++)
            {
                transform.Rotate(new Vector3(0, 0, -0.01f));
                yield return new WaitForSeconds(0.01f);
            }
        }
        yield break;
    }

    void rotate_center_keyboard()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, -0.3f));

        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, 0.3f));
        }
    }


    void rotate_center_mouse()
    {
        Vector3 mouseposition_raw = Input.mousePosition;
        mouseposition_raw.z = 0 - Camera.main.transform.position.z;
        Vector3 mouseposition_to_objectposition = Camera.main.ScreenToWorldPoint(mouseposition_raw);
        current_position = mouseposition_to_objectposition - center_position;

        //Debug.Log(past_position);
        //Debug.Log(current_position);

        if(Input.GetMouseButton(0))
        {
            if (past_position == current_position)
            { }
            else
            {
                float rotation_angle = (Mathf.Atan2(current_position.y, current_position.x) - Mathf.Atan2(past_position.y, past_position.x)) * Mathf.Rad2Deg;

                if (Mathf.Abs(rotation_angle) < 8)
                {
                    for (int i = 0; i < 32; i++)
                    {
                        transform.Rotate(new Vector3(0, 0, rotation_angle/32));
                        Debug.Log(transform.rotation);
                    }
                }
            }
        }

        past_position = current_position;
    }
}
