using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
          // pause if game is running
          if(Time.timeScale ==1 )
          {
            Time.timeScale = 0;
          }
          // unpause if game is currently paused
          else if (Time.timeScale == 0)
          {
            Time.timeScale = 1;
          }
        }
    }
}
