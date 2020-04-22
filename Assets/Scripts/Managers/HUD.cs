using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Displays cash and time on the HUD
public class HUD : MonoBehaviour
{
	private int goal;
    public Text levelDisplay;
    public Text cashDisplay;
    public Text timeDisplay;

    // Initialize the three variables
    void Start() {
    	levelDisplay.text = "Level: " + GetComponent<SwitchLevels>().getCurrentLevel().ToString();
    	timeDisplay.text = "Time: 0 secs";

        // Decides the money goal
    	switch(GetComponent<SwitchLevels>().getCurrentLevel()) {
            case 1: goal = 25; break;
            case 2: goal = 45; break;
            case 3: goal = 80; break;
            case 4: goal = 120; break;
            case 5: goal = 160; break;
        }
        
    	cashDisplay.text = "Cash: $0/$" + goal.ToString();
    }
    
    // Update the time
    public void receiveTime(int secs) {
    	timeDisplay.text = "Time: " + secs.ToString() + " secs";
    }

    // Update the cash
    public void receiveCash(int cash) {
    	cashDisplay.text = "Cash: $" + cash.ToString() + "/$"+ goal.ToString();
    }
}
