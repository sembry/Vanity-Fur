using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerEntrance : MonoBehaviour
{

    float movementSpeed = 1;

    // Start is called before the first frame update
    void Start()
  	{
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 0)
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime, Space.World);
        }
        else {
          Destroy(this);
        }
    }
}
