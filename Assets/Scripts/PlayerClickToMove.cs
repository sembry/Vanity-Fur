using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickToMove : MonoBehaviour
{
    private Vector3 moveToPos;

    void Start() {
        moveToPos = transform.position;
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, moveToPos, 3f * Time.deltaTime);
    }

    // Setter function
    public void setPos(Vector3 pos) {
    	moveToPos = pos;
    }
}
