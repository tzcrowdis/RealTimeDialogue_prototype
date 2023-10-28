 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueNPC : MonoBehaviour
{
    //many of these vars are public to reduce dev time in scripts
    public float speechTime;
    public float waitTime;

    public dialogueNPC who;
    public dialogueNPC what;
    public dialogueNPC when;
    public dialogueNPC where;
    public dialogueNPC why;
    public dialogueNPC waited;

    public bool current;
    public bool startTrigger;

    public bool initialTestVar;
    public bool finalTestVar;

    public bool consequence;
    public string consName;
    consequenceManager cons;
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
        cons = GameObject.Find("Actions Overlay").GetComponent<consequenceManager>();
        player = GameObject.Find("Main Camera").transform;
        if (!startTrigger)
        {
            current = false;
        }
        if (initialTestVar)
        {
            current = true;
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
                    for (int i = 0; i < cons.numEvents; i++)
                    {
                        if (consName.Equals(cons.eventNames[i])) { consIndex = i; }
                    }
                    consequence = false;

                    //notify if typo
                    if (consIndex != default(int)){ cons.eventStatus[consIndex] = true; } 
                    else{ Debug.LogFormat("Consequence name, {0}, not found.", consName); }
                }
            }

            //react to user questions
            if (Input.GetKeyDown("1")) //who
            {
                who.current = true;
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
                current = false;

                cons.Save();
            }
            else if (Input.GetKeyDown("2")) //what
            {
                what.current = true;
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
                current = false;

                cons.Save();
            }
            else if (Input.GetKeyDown("3")) //when
            {
                when.current = true;
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
                current = false;

                cons.Save();
            }
            else if (Input.GetKeyDown("4")) //where
            {
                where.current = true;
                text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
                current = false;

                cons.Save();
            }
            else if (Input.GetKeyDown("5")) //why
            {
                why.current = true;
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
                    waited.current = true;
                }
            }
            currentTime += Time.deltaTime;
        }
    }

}
