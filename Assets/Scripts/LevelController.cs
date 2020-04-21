using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Instantiates all the puppy customers
public class LevelController : MonoBehaviour
{
    public int secondsBetweenSpawn;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        secondsBetweenSpawn = 20;
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
      timer -= (Time.deltaTime) % 60;
      if(timer <= 0f)
      {
        int dog = Random.Range(1,3);
        switch(dog) {
          case 1: Instantiate(Resources.Load("SpottedPuppy"), new Vector3(4, -5, 0), Quaternion.identity); break;
          case 2: Instantiate(Resources.Load("Yorkie"), new Vector3(4, -5, 0), Quaternion.identity); break;
          case 3: Instantiate(Resources.Load("Aussie"), new Vector3(4, -5, 0), Quaternion.identity); break;
        }
        timer = (float)secondsBetweenSpawn;
      }
    }
}