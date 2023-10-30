using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class consequenceController : MonoBehaviour
{
    //This script controls the behavior of the specific consequences
    //therefore it is unique to the level in which they occur

    [Header("Name of event(s) that can occur:")]
    public string levelEvent1;

    consequenceTracker cons;
    int index;

    [Header("Game Event Object")]
    public GameObject cube;

    void Start()
    {
        cons = GameObject.Find("Actions Overlay").GetComponent<consequenceTracker>();
        index = cons.findEventIndex(levelEvent1);
    }

    void spokeFirstToNPC1()
    {
        Instantiate(cube, new Vector3 (0, 10, 0), Quaternion.identity);
        cons.eventStatus[index] = false;
    }

    void Update()
    {
        if (index > -1)
        {
            if (cons.eventStatus[index])
            {
                spokeFirstToNPC1();
            }
        }
    }
}
