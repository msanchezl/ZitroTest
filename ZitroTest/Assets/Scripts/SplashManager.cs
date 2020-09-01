using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashManager : MonoBehaviour
{
    public float LoadTime;
    public Slider ProgresBar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FakeLoad());
    }

    IEnumerator FakeLoad()
    {
        float time = 0;

        while(time < LoadTime)
        {
            time += Time.deltaTime;
            ProgresBar.value = Mathf.Clamp01(time / LoadTime);
            yield return null;
        }

        SceneManager.LoadScene(1);
    }
}
