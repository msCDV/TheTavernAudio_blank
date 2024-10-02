using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class VCA : MonoBehaviour
{
    FMOD.Studio.VCA GlobalVCA;
    FMOD.Studio.VCA MusicVCA;
    FMOD.Studio.VCA TavernVCA;
    FMOD.Studio.VCA OutsideVCA;

    private bool muteActive = true;
    private bool musicMuteActive = false;
    private bool tavernMuteActive = false;
    private bool outsideMuteActive = false;

    private void Start()
    {
        GlobalVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Mute");
        MusicVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Music");
        TavernVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Tavern_amb");
        OutsideVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Outside_amb");

        GlobalVCA.setVolume(DecibelToLinear(-100));
    }

    void Update()
    {
        GlobalMute();
        MusicMute();
        TavernMute();
        OutsideMute();
    }

    private void GlobalMute()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (muteActive)
            {
                GlobalVCA.setVolume(DecibelToLinear(0));
                muteActive = !muteActive;
            }
            else
            {
                GlobalVCA.setVolume(DecibelToLinear(-100));
                muteActive = !muteActive;
            }
        }
    }

    private void MusicMute()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!musicMuteActive)
            {
                MusicVCA.setVolume(DecibelToLinear(-100));
                musicMuteActive = !musicMuteActive;
            }
            else
            {
                MusicVCA.setVolume(DecibelToLinear(0));
                musicMuteActive = !musicMuteActive;
            }
        }
    }

    private void TavernMute()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (!tavernMuteActive)
            {
                TavernVCA.setVolume(DecibelToLinear(-100));
                tavernMuteActive = !tavernMuteActive;
            }
            else
            {
                TavernVCA.setVolume(DecibelToLinear(0));
                tavernMuteActive = !tavernMuteActive;
            }
        }
    }
    private void OutsideMute()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (outsideMuteActive)
            {
                OutsideVCA.setVolume(DecibelToLinear(-100));
                outsideMuteActive = !outsideMuteActive;
            }
            else
            {
                OutsideVCA.setVolume(DecibelToLinear(0));
                outsideMuteActive = !outsideMuteActive;
            }
        }
    }

    private float DecibelToLinear(float dB)         
    {                                               
        float linear = Mathf.Pow(10.0f, dB / 20f);
        return linear;
    }
}
