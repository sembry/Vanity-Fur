using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickToMove : MonoBehaviour
{

    float speed = 1.5f;
    Vector2 target;
    bool clicked;
    bool clicked2;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        clicked = false;
    }

    void OnMouseDown() {
        clicked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && clicked2)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clicked2 = false;
        }
        if(clicked) {
          clicked = false;
          clicked2 = true;
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
