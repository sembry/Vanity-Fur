using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Instantiates all the puppy customers
public class LevelController : MonoBehaviour
{
    public int secondsBetweenSpawn;
    private float timer;
    private int numberOfDogs;
    private GameObject puppyParent;
    private GameObject puppy;

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
        Debug.Log(numberOfDogs);

        // Find the folder under which puppies should be stored
        puppyParent = GameObject.Find("Puppies");
    }

    // Update is called once per frame
    void Update() {
        timer -= (Time.deltaTime) % 60;
        if(timer <= 0f) {
            int dog = Random.Range(1, numberOfDogs + 1);
            switch(dog) {
                case 1: puppy = (GameObject)Instantiate(Resources.Load("Puppies/Aussie"), new Vector3(4, -5, 0), Quaternion.identity); break;
                case 2: puppy = (GameObject)Instantiate(Resources.Load("Puppies/SpottedPuppy"), new Vector3(4, -5, 0), Quaternion.identity); break;
                case 3: puppy = (GameObject)Instantiate(Resources.Load("Puppies/Yorkie"), new Vector3(4, -5, 0), Quaternion.identity); break;
            }
            puppy.transform.SetParent(puppyParent.transform, true);
            timer = (float)secondsBetweenSpawn;
        }
    }
}