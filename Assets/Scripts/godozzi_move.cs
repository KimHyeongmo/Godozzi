using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godozzi_move : MonoBehaviour
{

    Rigidbody2D player_rigid;
    public bool player_jumping = true;
    float player_jump_power = 160;
    Vector2 player_jump_direction = new Vector2(0,1);

    Animator player_animation;
    Transform player_transformation;

    Transform player_parent;
    bool slime = false;
    //bool player_landing_out = false;

    bool sound_check = true;

    SpriteRenderer godozzi_sprite;

    // Start is called before the first frame update
    void Start()
    {
        godozzi_sprite = GetComponent<SpriteRenderer>();
        player_rigid = GetComponent<Rigidbody2D>();
        player_animation = GetComponent<Animator>();
        player_transformation = GetComponent<Transform>();
        Time.timeScale = 2f;
    }

    public float test = 0;
    float circle_radius = 7f;

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, new Vector3(0, test, 0));
        if (false == Physics2D.OverlapCircle(transform.position, circle_radius, LayerMask.GetMask("touch")))
        {
            sound_check = true;
            player_jumping = true;
            player_animation.SetBool("isSliding", false);
            GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        see_direction();
        //velocity_check();
        player_jump();
    }

    void velocity_check()
    {
        if(player_rigid.velocity.magnitude >= 15f && player_animation.GetBool("isSliding") == true)
        {
            player_animation.SetBool("isSliding", false);
            GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            
        }
        else if(player_rigid.velocity.magnitude < 0.5f && player_jumping == false && player_animation.GetBool("isSliding") == false)
        {
            player_animation.SetBool("isSliding", true);
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    void see_direction()
    {
        if(player_rigid.velocity.x < -0.1f)
        {
            godozzi_sprite.flipX = false;
        }
        else if (player_rigid.velocity.x > 0.1f)
        {
            godozzi_sprite.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (sound_check)
        {
            GameObject.Find("land_char").GetComponent<sound_effect>().play_sound();
            sound_check = false;
        }

        player_jumping = false;
        if(collision.transform.name == "loop")
        {
            player_animation.SetBool("isSliding", false);
            GetComponent<CircleCollider2D>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            return;
        }
        player_bounce_animation(collision);

    }


    void OnCollisionStay2D(Collision2D collision)
    {
        player_jump_direction = collision.contacts[0].normal;
        
        player_landing(collision);
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //player_landing_out = false;
        //player_jumping = true;
        //player_animation.SetBool("isBouncing", false);
    }

    void player_bounce_animation_finished()
    {
        player_animation.SetBool("isBouncing", false);
    }

    void player_bounce_animation(Collision2D collision)
    {
        float Dot = Vector2.Dot(collision.contacts[0].normal, new Vector2(0, 1));
        float angle = Mathf.Acos(Dot) * Mathf.Rad2Deg;
        player_animation.SetBool("isBouncing", true);
        
        if (angle > 45)
            return;

            if (collision.contacts[0].normal.x <= 0)
            {
                player_transformation.rotation = Quaternion.Euler(0, 0, angle);
            }
            else
            {
                player_transformation.rotation = Quaternion.Euler(0, 0, -1 * angle); //시계방향 마이너스 각도 회전 법선 벡터의 x가 플러스일 때
            }

        player_animation.SetBool("isSliding", true);
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = false;

        player_animation.SetBool("isBouncing", true);
    }

    void player_jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (slime == true)
            {

                player_transformation.SetParent(player_parent);
                player_rigid.isKinematic = false;
                slime = false;
                player_jumping = true;
                //player_landing_out = true;
                player_rigid.AddForce(player_jump_direction * player_jump_power, ForceMode2D.Impulse);

                return;
            }
            if (player_jumping == false)
            {
                GameObject.Find("jump_char").GetComponent<sound_effect>().play_sound();
                player_jumping = true;
                player_rigid.AddForce(player_jump_direction * player_jump_power, ForceMode2D.Impulse);

                player_animation.SetBool("isSliding", false);
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }
    
    void player_landing(Collision2D collision)
    {
        float Dot = Vector2.Dot(collision.contacts[0].normal, new Vector2(0, 1));
        float angle = Mathf.Acos(Dot) * Mathf.Rad2Deg;

        switch (collision.gameObject.tag)
        {
            case "platform_normal":
                player_rigid.velocity *= 0.95f;
                break;

            case "platform_ice":
                player_rigid.velocity *= 1.001f;
                break;
                /*
            case "platform_slime":
                platform_slime(collision);
                break;
                */
            case "platform_jump":
                
                player_jumping = true;
                if (angle > 45)
                {
                    return;
                }
                player_rigid.velocity = player_jump_direction * player_jump_power;
                return;
            case "platform_belt_left":
                if (angle > 45)
                {
                    return;
                }
                Vector2 direction_belt = collision.contacts[0].normal;
                direction_belt = new Vector2(direction_belt.y * -1, direction_belt.x); //좌측 벨트스크롤
                player_rigid.AddForce(direction_belt * 30, ForceMode2D.Force); //belt에 곱해지는 값은 벨트 속도
                return;

            default:
                //reset position //stage마다 값을 저장해서 오류발생 시 불러오도록
                break;
        }
        //player_jumping = false;
        //마찰 표준 //얼음에선 1.0 //끈적이에선 0이지만 닿는 순간 0으로 변경 후 속도의 변화가 감지되면(힘이 적용되면. magnitude)1.0으로 변경 //점프발판의 경우 player_jump와 동일한 현상 발생
        //각각의 발판은 tag로 구분됨. platform_normal(platform_normal, platform_90, platform_rotation, platform_moving), platform_ice, platform_slime, platform_jump
    }
    /*
    void platform_slime(Collision2D collision)
    {
        if (player_jumping == false && player_landing_out == false)
        {
            player_parent = player_transformation.parent;
            player_transformation.SetParent(collision.transform.parent);
            player_rigid.isKinematic = true;
            player_rigid.velocity = new Vector2(0, 0);
            slime = true;
        }
    }
    */
}
