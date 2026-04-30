using UnityEngine;
using UnityEngine.SceneManagement;
public class Trigger : MonoBehaviour
{
    public Timer timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "SampleScene")
        {
            timer.enabled = true;
        }
        else if(sceneName == "TitleScreen")
        {
            timer.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
