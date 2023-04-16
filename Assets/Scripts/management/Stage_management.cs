using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage_management : MonoBehaviour
{

    public Image Fade_panel;
    

    public GameObject[] prefab;

    public GameObject current_level;

    public float clear_time;

    public static Stage_management singleton = null;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void goal_fading()
    {
        StartCoroutine(goal_fading_coroutine());
    }

    IEnumerator goal_fading_coroutine()
    {
        float time = 0f;
        float Fade_time = 1f;
        Color alpha = Fade_panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / Fade_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Fade_panel.color = alpha;
            yield return null;
        }
        yield return null;

        
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("clear");
        


        while (!(asyncOperation.isDone))
        {
            yield return null;
        }

        yield return null;

        time = 0f;
        Fade_time = 1f;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / Fade_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Fade_panel.color = alpha;
            yield return null;
        }
        yield return null;


    }

    IEnumerator fading_coroutine(int level)
    {
        Fade_panel.gameObject.SetActive(true);
        float time = 0f;
        float Fade_time = 1f;
        Color alpha = Fade_panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / Fade_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Fade_panel.color = alpha;
            yield return null;
        }
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("SampleScene");

        while(!(asyncOperation.isDone))
        {
            yield return null; //내가 이걸 안써서 뭘 할틈을 안주고 계속 돌았구나
            //이전에는 끝나기도 전에 밑의 instantiate를 실행해서 이전 씬에서 생성한 후 씬 로드가 완료되면 그대로 사라지는 상황이 발생했었음.
        }

        start_game(level);

        yield return null;

        time = 0f;
        Fade_time = 1f;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / Fade_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Fade_panel.color = alpha;
            yield return null;
        }
        yield return null;

    }


    void start_game(int level)
    {
        current_level = Instantiate(prefab[level]);
    }

    public void SelectStage(string stage_name)
    {
        int level = find_stage_number(stage_name) - 1; //frefab 배열
        if(level == -1)
        {
            return;
        }
        StartCoroutine(fading_coroutine(level));
    }

    int find_stage_number(string stage_name)
    {
        switch(stage_name)
        {
            case "stage1":
                return 1;
            case "stage2":
                return 2;
            case "stage3":
                return 3;
            case "stage4":
                return 4;
            case "stage5":
                return 5;
        }
        return 1; //error시 stage1으로 보냄

        //stage이름 배열에서 stage부분을 빼고, 거기서 부터 배열 끝까지의 값을 정수로 바꾸는 방법도 있음
    }

}
