using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Handles menu at the end of level
public class EndLevel : MonoBehaviour
{
    public Button mainMenuButton;
    public Button nextLevelButton;
    public Text level;
    public Text endMoneyText;
    public Text targetMoneyText;

    private int endMoney;
    private int targetMoney;
    private int levelNumber;

    // Get variables and start the buttons
    void Start() {
        level.text = "Level " + levelNumber;
        endMoneyText.text = "Earnings: $" + endMoney;
        targetMoneyText.text = "Goal: $" + targetMoney;

        Button mainMenu = mainMenuButton.GetComponent<Button>();
        mainMenu.onClick.AddListener(MainMenuOnClick);

        Button levelButton = nextLevelButton.GetComponent<Button>();

        // Change next level button depending on if you completed the level or not
        if(endMoney < targetMoney) {
            levelButton.GetComponentInChildren<Text>().text = "Restart Level";
            levelButton.onClick.AddListener(RestartOnClick);
        }
        else {
            levelButton.GetComponentInChildren<Text>().text = "Next Level";
            levelButton.onClick.AddListener(NextLevelOnClick);
        }
    }

    // Setter functions
    public void setEndMoney(int end) {
        endMoney = end;
    }

    public void setTargetMoney(int target) {
        targetMoney = target;
    }

    public void setLevelNumber(int level) {
        levelNumber = level;
    }

    // Button functionalities
    void MainMenuOnClick() {
        SceneManager.LoadScene(0);
    }

    void RestartOnClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void NextLevelOnClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
