using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles puppy variables and the initiation of a new puppy
public class PuppyCustomer : MonoBehaviour
{
    public HashSet<int> stations = new HashSet<int>();
    public int balance;
    private int stationsWanted;

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
}
