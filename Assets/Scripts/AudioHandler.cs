using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource sfxAudio;

    public AudioClip accept;
    public AudioClip exit;
    public AudioClip atPC;
    public AudioClip win;
    public AudioClip lose;

    bool locked;

    private void Awake()
    {
        TerminalGUI.OnGUIOpen += OnGUIEnter;

    }

    private void Start()
    {
        locked = false;
    }

    private void OnDestroy()
    {
        TerminalGUI.OnGUIOpen -= OnGUIEnter;
    }

    public void PlaySound(string id)
    {
        if (locked)
            return;

        switch (id)
        {
            default:
                Debug.LogError("'" + id + "' is an invalid ID!");
                break;

            case "accept":
                sfxAudio.clip = accept;
                break;

            case "exit":
                sfxAudio.clip = exit;
                break;
            case "atpc":
                sfxAudio.clip = atPC;
                break;
            case "win":
                sfxAudio.clip = win;
                break;

            case "lose":
                sfxAudio.clip = lose;
                break;

        }
        sfxAudio.Play();
    }

    private void OnGUIEnter()
    {
        PlaySound("atpc");
    }

    private void OnWin()
    {
        Debug.Log("Win");
        PlaySound("win");
        locked = true;
    }

    private void OnLose()
    {
        Debug.Log("Lose");
        PlaySound("lose");
        locked = true;
    }
}
