using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_animation : MonoBehaviour
{
    void after_bomb()
    {
        Destroy(gameObject);
    }
}
