using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueNPC : MonoBehaviour
{
    //many of these vars are public to reduce dev time in scripts
    [Header("Speech Attributes")]
    public float speechTime;
    public float waitTime;

    [Header("Next Dialogue")]
    public dialogueNPC who;
    public dialogueNPC what;
    public dialogueNPC when;
    public dialogueNPC where;
    public dialogueNPC why;
    public dialogueNPC waited;

    [Header("Dialogue Status")]
    public bool current;
    public bool startTrigger;

    [Header("Will this trigger an event? If so what's the name?")]
    public bool consequence;
    public string consName;
    consequenceTracker cons;

    [Header("Player Attribute (no need to set)")]
    public Transform player;

    TextMeshProUGUI text;
    float currentTime = 0f;
    bool wait = false;
    int consIndex;


    void OnTriggerEnter()
    {
        //if first dialogue node then trigger on player proximity to NPC
        if (startTrigger)
        {
            current = true;
        }
    }

    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f); //start with invisible text
        cons = GameObject.Find("Actions Overlay").GetComponent<consequenceTracker>();
        player = GameObject.Find("FirstPersonController").transform;
        if (!startTrigger)
        {
            current = false;
        }
    }

    void Update()
    {
        if (current == true)
        {
            //activate speech
            if (!wait)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, 1f); //visible
                transform.rotation = player.transform.rotation; //oriented

                if (consequence)
                {
                    consIndex = cons.findEventIndex(consName);
                    consequence = false;

                    //if no typo
                    if (consIndex > -1){ cons.eventStatus[consIndex] = true; }
                }
            }

            //react to user questions
            if (Input.GetKeyDown("1")) //who
            {
                if (who != null) { who.current = true; }
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
                current = false;

                cons.Save();
            }
            else if (Input.GetKeyDown("2")) //what
            {
                if (what != null) { what.current = true; }
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
                current = false;

                cons.Save();
            }
            else if (Input.GetKeyDown("3")) //when
            {
                if (when != null) { when.current = true; }
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
                current = false;

                cons.Save();
            }
            else if (Input.GetKeyDown("4")) //where
            {
                if (where != null) { where.current = true; }
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
                current = false;

                cons.Save();
            }
            else if (Input.GetKeyDown("5")) //why
            {
                if (why != null) { why.current = true; }
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
                current = false;

                cons.Save();
            }

            //hide text mimicing end of speech and move on if waiting too long
            if (currentTime >= speechTime)
            {
                if (!wait)
                {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
                    wait = true;
                    speechTime = waitTime; //set wait time for a response
                    currentTime = 0f;
                }
                else
                {
                    if (waited != null) { waited.current = true; }
                }
            }
            currentTime += Time.deltaTime;
        }
    }

}
