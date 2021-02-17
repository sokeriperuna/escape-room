using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DIALOGUE_TYPE
{
    DEFAULT,
    WIN,
    LOSE,
    ALERT,
    PLACEHOLDER
}

[System.Serializable]
public struct DialogueChoice
{
    public string content; // What does your choice contain?
    public string destinationID; // Eg, AABA
}

[System.Serializable]
public struct DialogueEvent
{
    public string ID;

    public DIALOGUE_TYPE type;

    public string prompt; // the prompting content of the dialogue choice;

    public DialogueChoice choiceA;
    public DialogueChoice choiceB;
}
