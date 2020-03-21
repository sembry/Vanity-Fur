using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyDragAndDrop : MonoBehaviour
{
    bool canMove;
    bool dragging;
    Collider2D collider;
    Vector2 origPos;
    bool collided;
    Collision2D obj;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        canMove = false;
        dragging = false;
        origPos = this.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
        obj = collision;
    }

    void OnCollisionExit2D()
    {
        collided = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
            if (canMove)
            {
                dragging = true;
            }
        }
        if (dragging)
        {
            this.transform.position = mousePos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            origPos = this.transform.position;
            collided = false;
            canMove = false;
            dragging = false;
        }
    }
}
