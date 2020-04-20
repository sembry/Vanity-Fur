using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickToMove : MonoBehaviour
{
    private Vector3 moveToPos;
    private bool canMove = true;

    void Start() {
        moveToPos = transform.position;
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, moveToPos, 3f * Time.deltaTime);
    }

    // Getter & setter functions
    public void startMove(Vector3 pos) {
        if(canMove) {
    	   moveToPos = pos;
        }
    }

    public bool getMove() {
        return canMove;
    }

    public void setMove() {
        canMove ^= true;
    }
}
