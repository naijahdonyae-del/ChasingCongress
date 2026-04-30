using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SlideShowController : MonoBehaviour
{
    public Image displayer;
    public Sprite[] slides;
    private int currIndex = 0;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AdvanceSlides();
        }
    }

    private void AdvanceSlides()
    {
        currIndex++;
        if (currIndex < slides.Length)
        {
            displayer.sprite = slides[currIndex];
        }
        else
        {
            // Transition to next game scene when finished
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
    }
}