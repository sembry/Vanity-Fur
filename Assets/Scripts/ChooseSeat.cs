using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Static class to keep track of seats
public class ChooseSeat : MonoBehaviour
{
    private static bool seat1 = true;
    private static bool seat2 = true;
    private static bool seat3 = true;

    // Check if seat is taken
    public static int checkSeat() {
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

    // Free up the seat
    public static void leaveSeat(int i) {
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
