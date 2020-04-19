using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyCustomer : MonoBehaviour
{
    // indicate which services the puppy wants
    public bool treatStand;
    public bool bath;
    public bool groomStation;
    public bool massage;

    // total money customer has spent
    public int balance;

    // used to randomly decide whether the puppy wants each treatment
    private int rand;

    public PuppyCustomer()
    {
      // to begin with the customer has spent $0
      balance = 0;

      // this will decide if the puppy will want each individual service
      rand = Random.Range(0,2);
      if(rand == 1) {
        treatStand = true;
      } else {
        treatStand = false;
      }

      // the same process is executed for each service
      rand = Random.Range(0,2);
      if(rand == 1) {
        bath = true;
      } else {
        bath = false;
      }

      rand = Random.Range(0,2);
      if(rand == 1) {
        groomStation = true;
      } else {
        groomStation = false;
      }

      rand = Random.Range(0,2);
      if(rand == 1) {
        massage = true;
      } else {
        massage = false;
      }
    }
}
