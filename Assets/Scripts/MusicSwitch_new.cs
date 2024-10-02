using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicSwitch_new : MonoBehaviour, IInteractable
{
    private AudioSystem audioSystem;
    private StudioEventEmitter eventEmitter;

    private void Start()
    {
        GameObject audioManager = GameObject.Find("Player");
        audioSystem = audioManager.GetComponent<AudioSystem>();
    }

    public void Interact()
    {
        if (audioSystem.isMusicPlaying)
        // StudioEventEmitter.instance.getParameterValue(stringName, out value1, out finalValue);
        {
            switch (gameObject.name)
            {
                case "Food_bottle4":
                    audioSystem.TavernMusic.SetParameter("Switch_parts", 0);
                    Debug.Log("Switching Music");
                    break;
                case "Food_bottle1":
                    audioSystem.TavernMusic.SetParameter("Switch_parts", 1);
                    Debug.Log("Switching Music");
                    break;
                case "Food_bottle3":
                    audioSystem.TavernMusic.SetParameter("Switch_parts", 2);
                    Debug.Log("Switching Music");
                    break;
                case "Food_bottle2":
                    audioSystem.TavernMusic.SetParameter("Switch_parts", 3);
                    audioSystem.isMusicPlaying = false;
                    Debug.Log(audioSystem.isMusicPlaying);
                    break;
            }
           /* Debug.Log("Switching music");
            if (gameObject.name == "Food_bottle4")
                audioSystem.TavernMusic.SetParameter("Switch_parts", 0);
            else if (gameObject.name == "Food_bottle1")
                audioSystem.TavernMusic.SetParameter("Switch_parts", 1);
            else if (gameObject.name == "Food_bottle3")
                audioSystem.TavernMusic.SetParameter("Switch_parts", 2);
            else if (gameObject.name == "Food_bottle2")
            {
                audioSystem.TavernMusic.SetParameter("Switch_parts", 3);
                audioSystem.isMusicPlaying = false;
                Debug.Log(audioSystem.isMusicPlaying);
            } */
        }
        else
        {
            Debug.Log("start");
            audioSystem.TavernMusic.SetParameter("Switch_parts", 0);
            audioSystem.TavernMusic.Play();
            audioSystem.isMusicPlaying = true;
        }
    }
}