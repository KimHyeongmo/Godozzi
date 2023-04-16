using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloon : MonoBehaviour
{
    Animator ballon_bomb;

    float power = 240;

    private void Awake()
    {
        ballon_bomb = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = collision.contacts[0].normal * -1;
        if (collision.transform.tag == "Player")
        {
            ballon_bomb.SetBool("isBoom", true);
            collision.rigidbody.AddForce(direction * power, ForceMode2D.Impulse);
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    public void after_bomb()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }


}
