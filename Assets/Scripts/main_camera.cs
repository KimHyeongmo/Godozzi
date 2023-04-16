using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_camera : MonoBehaviour
{
    public GameObject player;

    Transform camera_transform;

    void Awake()
    {
        camera_transform = GetComponent<Transform>();
    }


    void LateUpdate()
    {
        Vector3 move_camera = new Vector3(player.transform.position.x, player.transform.position.y + 2, camera_transform.position.z);
        camera_transform.position = move_camera;
    }
}
