using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Handles menu at the end of level
public class LastPanel : MonoBehaviour
{
    public Button mainMenuButton;

    // Start the buttons
    void Start() {
        Button mainMenu = mainMenuButton.GetComponent<Button>();
        mainMenu.onClick.AddListener(MainMenuOnClick);
    }

    // Button functionality
    void MainMenuOnClick() {
        SceneManager.LoadScene(0);
    }
}
