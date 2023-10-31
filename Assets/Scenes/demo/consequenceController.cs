using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consequenceController : MonoBehaviour
{
    //This script controls the behavior of the specific consequences
    //therefore it is unique to the level in which they occur

    [Header("Name of event(s) that can occur:")]
    public string levelEvent1;
    public string levelEvent2;

    consequenceTracker cons;
    int index1;
    int index2;

    //controls dialogue order
    bool done;
    dialogueNPC intro1_1; //read as intro 1 of npc 1
    dialogueNPC intro2_1;
    dialogueNPC intro1_2;
    dialogueNPC intro2_2;

    [Header("Game Event Object")]
    public GameObject cube;
    float timeUntilCube = 10f;
    float currentTime = 0f;

    void Start()
    {
        cons = GameObject.Find("Actions Overlay").GetComponent<consequenceTracker>();
        index1 = cons.findEventIndex(levelEvent1);
        index2 = cons.findEventIndex(levelEvent2);

        done = false;
        intro1_1 = GameObject.Find("intro1").GetComponent<dialogueNPC>();
        intro2_1 = GameObject.Find("intro2").GetComponent<dialogueNPC>();
        intro1_2 = GameObject.Find("intro_first").GetComponent<dialogueNPC>();
        intro2_2 = GameObject.Find("intro_second").GetComponent<dialogueNPC>();
    }

    void spokeFirstToNPC1()
    {
        //prepare consequence specific dialogue
        if (!done)
        {
            intro1_2.startTrigger = false;
            intro2_2.startTrigger = true;
            done = true;
        }

        //prepare world affecting consequence
        currentTime += Time.deltaTime;
        if (currentTime >= timeUntilCube)
        {
            Instantiate(cube, new Vector3(0, 10, 0), Quaternion.identity);
            cons.eventStatus[index1] = false;
        }
    }

    void spokeFirstToNPC2()
    {
        //prepare consequence specific dialogue
        if (!done)
        {
            intro1_1.startTrigger = false;
            intro2_1.startTrigger = true;
            done = true;
        }
        cons.eventStatus[index2] = false;
    }

    void Update()
    {
        if (index1 > -1)
        {
            if (cons.eventStatus[index1])
            {
                spokeFirstToNPC1();
            }
        }
        
        if (index2 > -1)
        {
            if (cons.eventStatus[index2])
            {
                spokeFirstToNPC2();
            }
        }
    }
}
