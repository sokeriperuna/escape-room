using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalObject : Interactable
{
    public TerminalGUI gui;

    protected override void PerformFunction()
    {
        gui.OpenMainPanel();
    }
}
