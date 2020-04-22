using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps track of the player's money throughout the level
public class PlayerMoney : MonoBehaviour
{
    private int balance = 0;

    public void addMoney(int amt) {
    	balance += amt;
    	GetComponent<HUD>().receiveCash(balance);
    }

    public int getBalance() {
      return balance;
    }
}
