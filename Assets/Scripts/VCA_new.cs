using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class VCA_new : MonoBehaviour
{
    private AudioSystem audioSystem;

    private void Start()
    {
        audioSystem = GetComponent<AudioSystem>();
    }

    void Update()
    {
        audioSystem.ToggleMute(KeyCode.U, ref audioSystem.muteActive, audioSystem.GlobalVCA);
        audioSystem.ToggleMute(KeyCode.I, ref audioSystem.musicMuteActive, audioSystem.MusicVCA);
        audioSystem.ToggleMute(KeyCode.O, ref audioSystem.tavernMuteActive, audioSystem.TavernVCA);
        audioSystem.ToggleMute(KeyCode.P, ref audioSystem.outsideMuteActive, audioSystem.OutsideVCA);
    }    
}
