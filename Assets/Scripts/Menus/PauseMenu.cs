using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Handles behavior for the pause menu
public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public Button playButton;
    public Button restartButton;
    public Button mainMenuButton;
    public AudioSource backgroundAudio;

    void Start() {
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

    void Update() {
        if(Input.GetKeyDown(KeyCode.P)) {
            // Pause if game is running
            if(!pausePanel.activeInHierarchy) {
                pauseGame();
            }
            // Unpause if game is currently paused
            else {
                playGame();
            }
        }
    }

    void pauseGame() {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        backgroundAudio.mute = true;
    }

    void playGame() {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        backgroundAudio.mute = false;
    }

    void PlayOnClick() {
        // Check to ensure pause menu is shown
        if(pausePanel.activeInHierarchy) {
            // Resume game
            playGame();
        }
    }

    void RestartOnClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void MenuOnClick() {
        SceneManager.LoadScene(0);
    }
}
