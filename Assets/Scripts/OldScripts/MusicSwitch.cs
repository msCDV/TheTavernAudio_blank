using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicSwitch : MonoBehaviour, IInteractable
{
    public FMODUnity.StudioEventEmitter tavernEmitter;
    private bool musicIsPlaying = true;

    public void Interact()
    {
            Debug.Log("switch");
        //Music.setParameterByNameWithLabel("Switch_parts", "Part 2");
        if (gameObject.name == "Food_bottle4")
            tavernEmitter.SetParameter("Switch_parts", 0);
        else if (gameObject.name == "Food_bottle1")
            tavernEmitter.SetParameter("Switch_parts", 1);
        else if (gameObject.name == "Food_bottle3")
            tavernEmitter.SetParameter("Switch_parts", 2);
        else if (gameObject.name == "Food_bottle2")
        {
            tavernEmitter.SetParameter("Switch_parts", 3);
            musicIsPlaying = false;
            Debug.Log(musicIsPlaying);
        }
        //else if (gameObject.name == "Food_bottle6" && musicIsPlaying == false)
        else if (gameObject.name == "Food_bottle6")
        {
            Debug.Log("start");
            tavernEmitter.SetParameter("Switch_parts", 0);
            tavernEmitter.Play();
            musicIsPlaying = true;
        }
    }
}
