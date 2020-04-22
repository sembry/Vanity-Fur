using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Keeps track of money and services desired
public class PuppyCustomer : MonoBehaviour
{
    private HashSet<int> stations = new HashSet<int>();
    private Vector3 exitPos = new Vector3(10.3f, -3.77f, 0);

    private int balance = 0;
    private int stationsWanted;
    private int happiness = 100;
    private int count;
    private float timer = 0f;
    private string station = "";

    private bool paid = false;
    private bool leave = false;
    private bool pause = true;

    private GameObject cm;
    private GameObject thought;
    private GameObject attributeParent;
    private GameObject slider;
    private GameObject canvas;
    private GameObject cloud;
    private GameObject anger;

    public AudioClip soundFile;
 
    void Start() {
        // Find GameObjects
        cm = GameObject.Find("ClickManager");
        attributeParent = GameObject.Find("Effects");
        // Generate stations desired
        stationsWanted = Random.Range(1,4);
        while (stations.Count < stationsWanted) {
            stations.Add(Random.Range(1,4));
        }
        // Generate happiness based on dog
        switch(gameObject.name) {
            case "Aussie(Clone)": count = 4; break;
            case "SpottedPuppy(Clone)": count = 7; break;
            case "Yorkie(Clone)": count = 10; break;
        }
        GetComponent<AudioSource>().PlayOneShot(soundFile, 0.5f);
    }

    // Leave the scene and destroy self
    void Update() {
        // Every second, subtract a happiness
        if(!pause) {
            timer += (Time.deltaTime)%60;
            if(timer >= 1) {
                happiness -= count;
                changeHappinessBar(happiness);
                timer = 0f;
            }
        }
        // Leave after paying or if angry
        if(happiness <= 0 || paid) {
            if(!leave) {
                // Destroy the thought and slider, prevent movement, instantiate the anger thought, 
                // and mark the machine/seat as untaken
                Destroy(thought);
                Destroy(slider);
                GetComponent<PuppyDragAndDrop>().setMove();
                if(GetComponent<PuppyDragAndDrop>().getMachine()) {
                    cm.GetComponent<ClickManager>().freeMachine(GetComponent<PuppyDragAndDrop>().getMachine().name);
                }
                else {
                    ChooseSeat.leaveSeat(GetComponent<PuppyDragAndDrop>().getSeat());
                }
                if(happiness <= 0) {
                    instantiateAnger();
                }
                leave = true;
            }
            // Move towards exit and then destroy self and anger bubble
            if(transform.position.x < exitPos.x) {
                transform.position = Vector2.MoveTowards(transform.position, exitPos, 3f * Time.deltaTime);
                if(anger) {
                    anger.transform.position = Vector2.MoveTowards(anger.transform.position, new Vector3(exitPos.x, 
                        exitPos.y + 1, 0), 3f * Time.deltaTime);
                }
            }
            else {
                Destroy(anger);
                Destroy(gameObject);
            }
        }
    }

    // Used if service delivered
    public void changeHappinessBar(int health) {
        if(slider) {
            slider.GetComponent<Slider>().value = health;
        }
    }

    // Used when service is being delivered or when entering the scene
    public void pauseHappiness() {
        pause ^= true;
    }

    // Used if sent to treat station
    public void addHappiness() {
        happiness += 40;
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

    // Add happiness and cash upon finishing a station, and then get a new station and instantiate a thought
    public void removeStation(int i) {
        happiness += 25;
        pause = false;
        float multiplier = 0;
        switch(gameObject.name) {
            case "Aussie(Clone)": multiplier = 1; break;
            case "SpottedPuppy(Clone)": multiplier = 1.25f; break;
            case "Yorkie(Clone)": multiplier = 1.5f; break;
        }
        switch(i) {
            case 1: balance += (int) (7 * multiplier); break;
            case 2: balance += (int) (11 * multiplier); break;
            case 3: balance += (int) (17 * multiplier); break;
        }
        stations.Remove(i);
        getStation();
        instantiateThought();
    }

    // Prevent puppy from being picked up and set flag variable
    public void setPaid() {
        paid = true;
        GameObject.Find("LevelController").GetComponent<PlayerMoney>().addMoney(balance * 
            (1 + (happiness/100)));
    }

    // Instantiates a new thought based on station desired
    public void instantiateThought() {
        thought = (GameObject)Instantiate(Resources.Load("Attributes/" + station + " Thought"), new Vector3(transform.position.x, 
            transform.position.y + 1, 0), Quaternion.identity);
        thought.transform.SetParent(attributeParent.transform, true);
        GetComponent<PuppyDragAndDrop>().setThought(thought);
    }

    // Destroys current thought
    public void destroyThought() {
        if(thought) Destroy(thought);
    }

    // Instantiates the happiness bar
    public void instantiateBar() {
        canvas = GameObject.Find("Happiness Bars");
        slider = (GameObject)Instantiate(Resources.Load("Attributes/Happiness"), transform.position, Quaternion.identity);
        slider.transform.SetParent(canvas.transform, true);
        slider.transform.position = transform.position + new Vector3(0f, -0.72f, 0);
        GetComponent<PuppyDragAndDrop>().setSlider(slider);
    }

    // Instantiates the work done visual
    public void instantiateCloud() {
        cloud = (GameObject)Instantiate(Resources.Load("Attributes/WorkingCloud"), new Vector3(transform.position.x, 
            transform.position.y, 0), Quaternion.identity);
        cloud.transform.SetParent(attributeParent.transform, true);
    }

    // Destroys the work done visual
    public void destroyCloud() {
        Destroy(cloud);
    }

    // Instantiates the anger thought
    public void instantiateAnger() {
        anger = (GameObject)Instantiate(Resources.Load("Attributes/Angry"), new Vector3(transform.position.x, 
            transform.position.y + 1, 0), Quaternion.identity);
        anger.transform.SetParent(attributeParent.transform, true);
    }

    // Getter function
    public bool puppyLeaving() {
        return (happiness <= 0);
    }
}