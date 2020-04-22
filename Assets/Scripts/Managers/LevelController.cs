using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Instantiates all the puppy customers
public class LevelController : MonoBehaviour
{
    private int secondsBetweenSpawn = 9;
    private int maxDogs = 0;
    private int count = 0;
    private int numberOfDogs;
    private float timer;
    private bool done = false;
    private bool started = false;

    private GameObject puppyParent;
    private GameObject puppy;

    // Start is called before the first frame update
    void Start()
    {
        timer = 2;

        // get which dogs you can spawn
        switch(GetComponent<SwitchLevels>().currentLevel) {
            case 1: numberOfDogs = 1; maxDogs = 6; break;
            case 2: numberOfDogs = 1; maxDogs = 7; break;
            case 3: numberOfDogs = 2; maxDogs = 9; break;
            case 4: numberOfDogs = 2; maxDogs = 10; break;
            case 5: numberOfDogs = 3; maxDogs = 12; break;
        }

        // Find the folder under which puppies should be stored
        puppyParent = GameObject.Find("Puppies");
    }

    // Update is called once per frame
    void Update() {
        if(!done && started) {
            timer -= (Time.deltaTime) % 60;
            if(timer <= 0f && count < maxDogs) {
                int dog = Random.Range(1, numberOfDogs + 1);
                switch(dog) {
                    case 1: puppy = (GameObject)Instantiate(Resources.Load("Puppies/Aussie"), new Vector3(4, -5, 0), Quaternion.identity); break;
                    case 2: puppy = (GameObject)Instantiate(Resources.Load("Puppies/SpottedPuppy"), new Vector3(4, -5, 0), Quaternion.identity); break;
                    case 3: puppy = (GameObject)Instantiate(Resources.Load("Puppies/Yorkie"), new Vector3(4, -5, 0), Quaternion.identity); break;
                }
                puppy.transform.SetParent(puppyParent.transform, true);
                timer = (float)secondsBetweenSpawn;
                count++;
            }
        }
    }

    public void startSpawn() {
        started = true;
    }

    public void stopCreating() {
        done = true;
    }
}