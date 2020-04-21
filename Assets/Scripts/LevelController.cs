using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Instantiates all the puppy customers
public class LevelController : MonoBehaviour
{
    public int secondsBetweenSpawn;
    private float timer;
    private int numberOfDogs;

    // Start is called before the first frame update
    void Start()
    {
        secondsBetweenSpawn = 10;
        timer = 2;

        // get which dogs you can spawn
        switch(GetComponent<SwitchLevels>().currentLevel) {
            case 1: numberOfDogs = 1; break;
            case 2: numberOfDogs = 1; break;
            case 3: numberOfDogs = 2; break;
            case 4: numberOfDogs = 2; break;
            case 5: numberOfDogs = 3; break;
        }
    }

    // Update is called once per frame
    void Update() {
        timer -= (Time.deltaTime) % 60;
        if(timer <= 0f) {
            int dog = Random.Range(1, numberOfDogs);
            switch(dog) {
                case 1: Instantiate(Resources.Load("Aussie"), new Vector3(4, -5, 0), Quaternion.identity); break;
                case 2: Instantiate(Resources.Load("SpottedPuppy"), new Vector3(4, -5, 0), Quaternion.identity); break;
                case 3: Instantiate(Resources.Load("Yorkie"), new Vector3(4, -5, 0), Quaternion.identity); break;
            }
            timer = (float)secondsBetweenSpawn;
        }
    }
}