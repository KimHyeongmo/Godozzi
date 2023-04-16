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
            yield return null; //���� �̰� �ȽἭ �� ��ƴ�� ���ְ� ��� ���ұ���
            //�������� �����⵵ ���� ���� instantiate�� �����ؼ� ���� ������ ������ �� �� �ε尡 �Ϸ�Ǹ� �״�� ������� ��Ȳ�� �߻��߾���.
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
        int level = find_stage_number(stage_name) - 1; //frefab �迭
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
        return 1; //error�� stage1���� ����

        //stage�̸� �迭���� stage�κ��� ����, �ű⼭ ���� �迭 �������� ���� ������ �ٲٴ� ����� ����
    }

}
