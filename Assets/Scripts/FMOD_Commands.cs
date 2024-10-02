using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FMOD_Commands : MonoBehaviour
{
    #region EVENT EMITTER
    // EVENT EMITTER
    public FMODUnity.StudioEventEmitter tavernEmitter; // œcie¿ka do event emittera na scenie
    #endregion

    #region EVENT
    // EVENT
    FMOD.Studio.EventInstance FootstepsSound; // klasa eventu / snapshotu
    public EventReference footstepsEvent; // œcie¿ka dostêpu do eventu / snapshotu

    private void Footsteps()
    {
        // jednorazowe odtworzenie
        FMODUnity.RuntimeManager.PlayOneShot(footstepsEvent); // stworzenie klasy snapshotu ze œcie¿k¹ do wybranego snapshotu i jednorazowe odtworzenie

        // podstawowe zarz¹dzanie eventem
        FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent); // podanie klasie eventu œcie¿ki do wybranego eventu / snapshotu
        FootstepsSound.setParameterByNameWithLabel("Footsteps_surface", "Stone"); // zmiana wartoœci parametru zadeklarowanego lub wykorzystanego w evencie
        FootstepsSound.start(); // odtworzenie eventu
        FootstepsSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); // STOP bez fadeout
        FootstepsSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // STOP z fadeout
        FootstepsSound.release(); // zwolnienie pamiêci

        // zarz¹dzanie eventem z przypiêciem emittera do gameObjectu 
        FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent);
        FootstepsSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform)); // !!!!11! przypiêcie emittera eventu do gameObjectu !!!11!!
        FootstepsSound.setParameterByNameWithLabel("Footsteps_surface", "Stone");
        FootstepsSound.start();
        FootstepsSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        FootstepsSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        FootstepsSound.release();
    }
    #endregion

    #region SNAPSHOT
    // SNAPSHOT
    FMOD.Studio.EventInstance HealthSnap; // klasa eventu / snapshotu
    public EventReference healthSnapshot; // œcie¿ka dostêpu do eventu / snapshotu

    private void StartSnapshot()
    {
        if (tavernEmitter != null && tavernEmitter.IsPlaying()) // sprawdzenie czy event emitter istnieje na scenie i czy jest aktywny
        {
            HealthSnap = FMODUnity.RuntimeManager.CreateInstance(healthSnapshot); // podanie klasie snapshotu œcie¿ki do wybranego eventu / snapshotu
            HealthSnap.start(); // w³¹czenie snapshotu
        }
        else if (tavernEmitter != null && tavernEmitter.IsPlaying())
        {
            HealthSnap.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); // STOP bez fadeout
            HealthSnap.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // STOP z fadeout
            HealthSnap.release(); // zwolnienie pamiêci
        }
    }
    #endregion

    #region VCA
    // VCA
    FMOD.Studio.VCA GlobalVCA; // klasa VCA

    private void VCA()
    {
        GlobalVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Mute"); // podanie klasie VCA œcie¿ki do wybranego eventu / snapshotu
        GlobalVCA.setVolume(DecibelToLinear(0)); // ustawienie maksymalnej g³oœnoœci z przeliczeniem na decybele [dB]
        GlobalVCA.setVolume(DecibelToLinear(-100)); // obni¿enie g³oœnoœci z przeliczeniem na decybele [dB]
    }

    private float DecibelToLinear(float dB) // dodatkowa funkacja spoza FMOD przeliczaj¹ca zwyk³e wartoœci liczbowe na decyble [dB]
    {
        float linear = Mathf.Pow(10.0f, dB / 20f);
        return linear;
    }
    #endregion

    #region EVENT / EMITTER Z MUZYK¥
    // EVENT / EMITTER Z MUZYK¥
    FMOD.Studio.EventInstance Music; // klasa eventu / snapshotu
    public FMODUnity.StudioEventEmitter tavernEmitter_Music; // œcie¿ka do event emittera na scenie

    private void MusicSwtich()
    {
        // EVENT
        FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent); // podanie klasie eventu œcie¿ki do wybranego eventu / snapshotu
        Music.setParameterByNameWithLabel("Switch_parts", "Part 2"); // zmiana wartoœci parametrów typu labeled dla eventów
        Music.start(); // odtworzenie eventu
        Music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); // STOP bez fadeout
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // STOP z fadeout
        Music.release(); // zwolnienie pamiêci


        // EMITTER
        tavernEmitter_Music.SetParameter("Switch_parts", 0); // zmiana wartoœci parametrów typu labeled dla event emitterów
        tavernEmitter_Music.Play(); // w³¹czenie odtwarzania na emitterze
        tavernEmitter_Music.Stop(); // wy³¹czenie odtwarzania na emitterze
    }
    #endregion
}
