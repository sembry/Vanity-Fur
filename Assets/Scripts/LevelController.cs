using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int secondsBetweenSpawn;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        secondsBetweenSpawn = 8;
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
      timer -= (Time.deltaTime) % 60;
      if(timer <= 0f)
      {
        Instantiate(Resources.Load("Westie"), new Vector3(4, -5, 0), Quaternion.identity);
        timer = (float)secondsBetweenSpawn;
      }
    }
}
