using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    
	private int money = 0;

	// Setter function
	public void addMoney(int amt) {
		money += amt;
	}
}