using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class VCA_new : MonoBehaviour
{
    private AudioSystem Mute;

    private void Start()
    {
        Mute = GetComponent<AudioSystem>();
    }

    void Update()
    {
        Mute.ToggleMute(KeyCode.U, ref Mute.muteActive, Mute.GlobalVCA);
        Mute.ToggleMute(KeyCode.I, ref Mute.musicMuteActive, Mute.MusicVCA);
        Mute.ToggleMute(KeyCode.O, ref Mute.tavernMuteActive, Mute.TavernVCA);
        Mute.ToggleMute(KeyCode.P, ref Mute.outsideMuteActive, Mute.OutsideVCA);
    }    
}
