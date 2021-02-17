using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// This is a class is partially controlled by TerminalObject. Terminal Object tells it when to wake up and when to go back to sleep.
public class TerminalGUI : MonoBehaviour
{
    public delegate void GUIEvent();
    public static event GUIEvent OnGUIOpen;
    public static event GUIEvent OnGUIClose;

    public TMP_Text content;
    public TMP_Text leftChoice;
    public TMP_Text rightChoice;

    public DialogueHandler dialogueHandler;

    public void DisplayDialogueEvent(DialogueEvent dialogueEvent)
    {
        content.text = dialogueEvent.prompt;
        
        // maybe randomize order of choices?
        leftChoice.text  = dialogueEvent.choiceA.content;
        rightChoice.text = dialogueEvent.choiceB.content;
    }

    public void OnDialogueChoice(string s)
    {
        dialogueHandler.Choice(s[0]);
    }

    public void OpenMainPanel()
    {
        this.gameObject.SetActive(true);
        if (OnGUIOpen != null)
            OnGUIOpen();
    }

    public void CloseMainPanel()
    {
        if (OnGUIClose != null)
            OnGUIClose();
        this.gameObject.SetActive(false);
    }

}
