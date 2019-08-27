using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    public bool isPaused = false;
    public HeroScript hero;
    public GameObject pauseMenu;

    //Pause & unpause gameplay
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                isPaused = false;
                hero.acceptInput = true;
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                Debug.Log("Paused is " + isPaused);
            } else {
                isPaused = true;
                hero.acceptInput = false;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                Debug.Log("Paused is " + isPaused);
            }
            
        }    
    }

    //Reload scene
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Restarted");
    }
}
