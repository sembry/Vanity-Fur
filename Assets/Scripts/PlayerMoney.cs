﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    private int balance = 0;

    public void addMoney(int amt) {
    	balance += amt;
    }

    public int getBalance() {
      return balance;
    }
}