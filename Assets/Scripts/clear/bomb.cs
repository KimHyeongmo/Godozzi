using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject bomb_animation;

    private void Start()
    {
        StartCoroutine(Random_bomb());
    }

    IEnumerator Random_bomb()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.25f);

            Instantiate(bomb_animation, random_position(), Quaternion.identity);
        }
    }

    Vector3 random_position()
    {
        Vector3 originPosition = transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = GetComponent<BoxCollider2D>().bounds.size.x;
        float range_Y = GetComponent<BoxCollider2D>().bounds.size.y;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);
        Vector3 RandomPostion = new Vector3(range_X, range_Y, 0f);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
}
