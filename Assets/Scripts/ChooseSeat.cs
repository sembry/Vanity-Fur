using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSeat : MonoBehaviour
{
    private bool seat1 = true;
    private bool seat2 = true;
    private bool seat3 = true;

    public int checkSeat() {
    	if(seat1) {
    		seat1 = false;
    		return 1;
    	}
    	else if(seat2) {
    		seat2 = false;
    		return 2;
    	}
    	else if(seat3) {
    		seat3 = false;
    		return 3;
    	}
    	return -1;
    }

    public void leaveSeat(int i) {
    	if(i == 1) {
    		seat1 = true;
    	}
    	else if(i == 2) {
    		seat2 = true;
    	}
    	else if(i == 3) {
    		seat3 = true;
    	}
    }
}
