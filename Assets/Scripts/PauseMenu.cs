using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public Button playButton;
    public Button restartButton;
    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1;
      pausePanel.SetActive(false);
      //adding onClick functionality to menu buttons
      Button play = playButton.GetComponent<Button>();
      play.onClick.AddListener(PlayOnClick);

      Button restart = restartButton.GetComponent<Button>();
      restart.onClick.AddListener(RestartOnClick);

      Button mainMenu = mainMenuButton.GetComponent<Button>();
      mainMenu.onClick.AddListener(MenuOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
          // pause if game is running
          if(!pausePanel.activeInHierarchy)
          {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
          }
          // unpause if game is currently paused
          else
          {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
          }
        }
    }

    void PlayOnClick()
    {
      // check to ensure pause menu is shown
      if(pausePanel.activeInHierarchy)
      {
        // resume game
        Time.timeScale = 1;
        pausePanel.SetActive(false);
      }
    }

    void RestartOnClick()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void MenuOnClick()
    {
      SceneManager.LoadScene(0);
    }
}
