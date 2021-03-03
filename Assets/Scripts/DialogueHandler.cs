using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{

    public TerminalGUI terminalGUI;
    public AudioHandler audioHandler;

    [SerializeField]
    public DialogueEvent[] dialogueEvents; // All of our essential dialogue info is found in here!

    private DialogueEvent currentDialogueEvent;

    private void Start()
    {
        DisplayNewDialogue("0"); // Display starting dialogue
    }

    void DisplayNewDialogue(string newID)
    {
        foreach (DialogueEvent e in dialogueEvents)
        {
            if (e.ID == newID)
            {
                currentDialogueEvent = e;
                break;
            }
        }

        if (currentDialogueEvent.type == DIALOGUE_TYPE.WIN)
            audioHandler.PlaySound("win");
        else if (currentDialogueEvent.type == DIALOGUE_TYPE.LOSE)
            audioHandler.PlaySound("lose");


        terminalGUI.DisplayDialogueEvent(currentDialogueEvent);
    }


    public void Choice(char id)
    {
        //Debug.Log(id);
        string newEvent;
        switch(id)
        {
            case 'A':

                newEvent = currentDialogueEvent.choiceA.destinationID;
                break;

            case 'B':
                newEvent = currentDialogueEvent.choiceB.destinationID;
                break;

            default:
                Debug.LogError("INCORRECT DIALOGUE ID");
                newEvent = currentDialogueEvent.ID;
                break;
        }

        DisplayNewDialogue(newEvent);
    }


}
