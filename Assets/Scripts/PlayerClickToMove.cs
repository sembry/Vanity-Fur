using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles movement for the player
public class PlayerClickToMove : MonoBehaviour
{
    private Vector3 moveToPos;
    private bool canMove = true;
    private GameObject machine;

    void Start() {
        moveToPos = transform.position;
    }

    // Move towards new location
    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, moveToPos, 3f * Time.deltaTime);
    }

    // When move starts, update variables
    public void startMove(Vector3 pos, GameObject machine_) {
        moveToPos = pos;
        machine = machine_;
    }

    // Getter & setter functions
    public bool getMove() {
        return canMove;
    }

    public void setMove() {
        canMove ^= true;
    }

    public GameObject getMachine() {
        return machine;
    }
}
