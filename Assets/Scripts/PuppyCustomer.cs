using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyCustomer : MonoBehaviour
{
    // a list representing what stations the puppy wants to visit
    // each integer will correspond to a specific station
    // a HashSet is used to ensure that there are no duplicate station requests
    public HashSet<int> stations = new HashSet<int>();

    // total money customer has spent
    public int balance;

    // an integer describing how many stations the puppy wants to visit
    private int stationsWanted;

    public PuppyCustomer()
    {
      // to begin with the customer has spent $0
      balance = 0;
    }

    void Start()
    {
      // randomly generate the number of stations the puppy wants to visit
      stationsWanted = Random.Range(1,3);

      // fill the set to represent what services they want randomly, no repeats
      while (stations.Count < stationsWanted)
      {
        stations.Add(Random.Range(1,4));
      }
    }
    
}
