using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      GameObject kk = Instantiate(Resources.Load("Westie"), new Vector3(0, 0, 0), Quaternion.identity) as GameObject; 
      kk.tag = "Puppy";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
