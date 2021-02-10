using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// This is a class is partially controlled by TerminalObject. Terminal Object tells it when to wake up and when to go back to sleep.
public class TerminalGUI : MonoBehaviour
{
    public delegate void GUIEvent();
    public static event GUIEvent OnGUIOpen;
    public static event GUIEvent OnGUIClose;

    private void Awake()
    {

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
