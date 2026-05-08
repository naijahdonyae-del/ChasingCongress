using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider loadingslider;

    public void LoadScene(int lvlIndex)
    {
        StartCoroutine(LoadSceneAsynchronously(lvlIndex));
    }

    IEnumerator LoadSceneAsynchronously(int lvlIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(lvlIndex);
        loadingscreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingslider.value = progress;
            yield return null;
        }
    }
}
