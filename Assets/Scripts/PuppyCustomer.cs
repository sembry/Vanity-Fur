using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps track of money and services desired
public class PuppyCustomer : MonoBehaviour
{
    private HashSet<int> stations = new HashSet<int>();
    private int balance;
    private int stationsWanted;
    private Vector3 exitPos = new Vector3(11f, 0f, 0);
    private bool paid = false;

    public PuppyCustomer() {
        balance = 0;
    }

    void Start() {
        // Generate stations desired
        stationsWanted = Random.Range(1,3);
        while (stations.Count < stationsWanted) {
            stations.Add(Random.Range(1,4));
        }
    }

    public string nextStation() {
        if(stations.Count > 0) {
            foreach(int i in stations) {
                switch(i) {
                    case 1: return "Bath";
                    case 2: return "Haircut";
                    case 3: return "Massage";
                }
            }
        }
        return "Cash";
    }

    public void removeStation(int i) {
        stations.Remove(i);
    }

    // Prevent puppy from leaving and set flag variable
    public void done(GameObject cm) {
        GetComponent<PuppyDragAndDrop>().setMove();
        paid = true;
        cm.GetComponent<ClickManager>().cashFree();
    }

    // Leave the scene and destroy self
    void Update() {
        if(paid) {
            if(transform.position.x < exitPos.x) {
                transform.position = Vector2.MoveTowards(transform.position, exitPos, 3f * Time.deltaTime);
            }
            else {
                Destroy(gameObject);
            }
        }
    }
}