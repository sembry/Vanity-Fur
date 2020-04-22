using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // Start is called before the first frame update
    void Start() {
        level.text = "Level " + levelNumber;
        endMoneyText.text = "Earnings: $" + endMoney;
        targetMoneyText.text = "Goal: $" + targetMoney;

        Button mainMenu = mainMenuButton.GetComponent<Button>();
        mainMenu.onClick.AddListener(MainMenuOnClick);

        Button levelButton = nextLevelButton.GetComponent<Button>();
        // change next level button depending on if you completed the level or not
        if(endMoney < targetMoney) {
            levelButton.GetComponentInChildren<Text>().text = "Restart Level";
            levelButton.onClick.AddListener(RestartOnClick);
        }
        else {
            levelButton.GetComponentInChildren<Text>().text = "Next Level";
            levelButton.onClick.AddListener(NextLevelOnClick);
        }
    }

    // setters for private variables
    public void setEndMoney(int end) {
        endMoney = end;
    }

    public void setTargetMoney(int target) {
        targetMoney = target;
    }

    public void setLevelNumber(int level) {
        levelNumber = level;
    }

    // button functionalities
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
