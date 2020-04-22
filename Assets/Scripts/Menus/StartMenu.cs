using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public Text levelText;
    public Text featuresText;
    public Text moneyGoalText;
    public Button playButton;

    private int levelNumber;
    private string newFeatures = "What's new in this level?";

    // Start is called before the first frame update
    void Start()
    {
      levelNumber = GetComponent<SwitchLevels>().getCurrentLevel();
      levelText.text = "Level " + levelNumber;

      // Choose text about new features depending on which level
      switch(levelNumber) {
        case 1:
          newFeatures = "Welcome to your basic spa! It comes equipped with a bath, haircut station, massage table, and a cash register.";
          break;
        case 2:
          newFeatures = "A treat station has been built into the spa! Use this station to increase your customers' happiness.";
          break;
        case 3:
          newFeatures = "A second bath station has been built in the spa! You will meet some new Spotted Puppy customers, who may be a little less patient than you are used to.";
          break;
        case 4:
          newFeatures = "A second haircut station has been built in the spa! You have also bought new shows and now can move 1.5x faster.";
          break;
        case 5:
          newFeatures = "A second massage station has been build in the spa! Watch out for some bew Yorkie customers, who are the most unpredictable of the customers you will encounter.";
          break;
      }

      // Set text to display
      featuresText.text = newFeatures;

      moneyGoalText.text = "Money Goal: " + GetComponent<SwitchLevels>().getGoal();

      Button play = playButton.GetComponent<Button>();
      play.onClick.AddListener(playButtonOnClick);
    }

    void playButtonOnClick()
    {
      // Start level timer and begin spawning puppies
      GetComponent<SwitchLevels>().startTimer();
      GetComponent<LevelController>().startSpawn();
    }
}
