using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class consequenceManager : MonoBehaviour
{
    //up to designer to keep vars consistent
    public int numEvents;
    public string[] eventNames;
    public bool[] eventStatus;
    //NOTE: ASSUMES ORDER OF EVENT NAMES ALIGNS WITH EVENT STATUS

    //read game event status' from file
    void Start()
    {
        //catch array mismatch
        if (eventNames.Length != eventStatus.Length) 
        { 
            Debug.Log("Event names and status arrays are of different lengths."); 
        }
        
        string[] line;
        string path = "Assets/Scenes/gameEvents.txt";
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
        string path = "Assets/Scenes/gameEvents.txt";
        StreamWriter writer = new StreamWriter(path, true);
        for (int i = 0; i < numEvents; i++)
        {
            writer.WriteLine("{0}={1}", eventNames, eventStatus);
        }
        writer.Close();
    }
}
