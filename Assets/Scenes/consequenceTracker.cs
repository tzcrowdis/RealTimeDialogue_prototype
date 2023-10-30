using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class consequenceTracker : MonoBehaviour
{
    //up to designer to keep vars consistent
    [Header("Input Events")]
    public int numEvents;
    public string[] eventNames;
    public bool[] eventStatus;

    [Header("Designate Event File Location")]
    public string path;
    //NOTE: ASSUMES ORDER OF EVENT NAMES ALIGNS WITH EVENT STATUS

    //read game event status' from file
    void Start()
    {
        Save();
        //catch array mismatch
        if (eventNames.Length != eventStatus.Length) 
        { 
            Debug.Log("Event names and status arrays are of different lengths."); 
        }
        
        string[] line;
        StreamReader reader = new StreamReader(path);
        for (int i = 0; i < numEvents; i++)
        {
            line = reader.ReadLine().Split('=');
            eventStatus[i] = bool.Parse(line[1]);
        }
        reader.Close();
    }

    //write current state of game events status' to file
    public void Save()
    {
        StreamWriter writer = new StreamWriter(path, false);
        for (int i = 0; i < numEvents; i++)
        {
            writer.WriteLine("{0}={1}", eventNames[i], eventStatus[i]);
        }
        writer.Close();
    }

    //returns the index of the event given its name
    //index is -1 if not found
    public int findEventIndex(string name)
    {
        int consIndex = -1;
        for (int i = 0; i < numEvents; i++)
        {
            if (name.Equals(eventNames[i])) { consIndex = i; }
        }

        //notify if typo
        if (consIndex == -1) { Debug.LogFormat("Consequence name, {0}, not found.", name); }

        return consIndex;
    }
}
