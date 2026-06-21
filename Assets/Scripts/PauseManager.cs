using UnityEngine;
using UnityEngine.UI;

class PauseManager : MonoBehaviour
{
    [SerializeField] private Image pauseMenu;
    
    public void OnPauseButtonPressed()
    {
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }

    public void OnResumeButtonPressed()
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
    }

    public void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}