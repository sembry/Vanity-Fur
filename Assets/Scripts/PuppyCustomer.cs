using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Keeps track of money and services desired
public class PuppyCustomer : MonoBehaviour
{
    private HashSet<int> stations = new HashSet<int>();
    private Vector3 exitPos = new Vector3(10.3f, -3.77f, 0);

    private int balance = 0;
    private int stationsWanted;
    private int happiness;
    private float timer = 0f;
    private string station = "";

    private bool paid = false;
    private bool leave = false;
    private bool pause = true;

    private GameObject cm;
    private GameObject thought;
 
    void Start() {
        cm = GameObject.Find("ClickManager");
        // Generate stations desired
        stationsWanted = Random.Range(1,3);
        while (stations.Count < stationsWanted) {
            stations.Add(Random.Range(1,4));
        }
        // Generate happiness based on dog
        switch(gameObject.name) {
            case "Westie(Clone)": happiness = 15; break;
        }
    }

    // Leave the scene and destroy self
    void Update() {
        // Every second, subtract a happiness
        if(!pause) {
            timer += (Time.deltaTime)%60;
            if(timer >= 1) {
                happiness--;
                timer = 0f;
            }
        }
        // Leave after paying or if angry
        if(happiness <= 0 || paid) {
            if(!leave) {
                Destroy(thought);
                GetComponent<PuppyDragAndDrop>().setMove();
                if(GetComponent<PuppyDragAndDrop>().getMachine()) {
                    Debug.Log(GetComponent<PuppyDragAndDrop>().getMachine().name);
                    cm.GetComponent<ClickManager>().freeMachine(GetComponent<PuppyDragAndDrop>().getMachine().name);
                }
                else {
                    Debug.Log(GetComponent<PuppyDragAndDrop>().getSeat());
                    ChooseSeat.leaveSeat(GetComponent<PuppyDragAndDrop>().getSeat());
                }
                leave = true;
            }
            if(transform.position.x < exitPos.x) {
                transform.position = Vector2.MoveTowards(transform.position, exitPos, 3f * Time.deltaTime);
            }
            else {
                Destroy(gameObject);
            }
        }
    }

    // When being worked, stop happiness degradation
    public void pauseHappiness() {
        pause ^= true;
    }

    // Used if sent to treat station
    public void addHappiness() {
        happiness += 10;
    }

    // Return the next station desired
    public string getStation() {
        if(stations.Count > 0) {
            foreach(int i in stations) {
                switch(i) {
                    case 1: station = "Bath"; return "Bath";
                    case 2: station = "Haircut"; return "Haircut";
                    case 3: station = "Massage"; return "Massage";
                }
            }
        }
        station = "Cash"; return "Cash";
    }

    public void instantiateThought() {
        thought = (GameObject)Instantiate(Resources.Load(station + " Thought"), new Vector3(transform.position.x, 
            transform.position.y + 1, 0), Quaternion.identity);
        GetComponent<PuppyDragAndDrop>().setThought(thought);
    }

    public void destroyThought() {
        if(thought) Destroy(thought);
    }

    // Add happiness and cash upon finishing a station
    public void removeStation(int i) {
        happiness += 5;
        pause = false;
        stations.Remove(i);
        switch(i) {
            case 1: balance += 10; break;
            case 2: balance += 7; break;
            case 3: balance += 15; break;
        }
        getStation();
        instantiateThought();
    }

    // Prevent puppy from being picked up and set flag variable
    public void setPaid() {
        paid = true;
    }

    // Getter & setter functions
    public int getBalance() {
        return balance;
    }
}