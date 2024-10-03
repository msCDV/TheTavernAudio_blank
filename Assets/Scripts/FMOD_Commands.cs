using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMOD_Commands : MonoBehaviour
{
    #region EVENT EMITTER
    // EVENT EMITTER
    public FMODUnity.StudioEventEmitter tavernEmitter; // œcie¿ka do event emittera na scenie // ENG - path to event emitter on stage
    #endregion

    #region EVENT
    // EVENT
    FMOD.Studio.EventInstance FootstepsSound; // klasa eventu / snapshotu // ENG - event / snapshot class
    public EventReference footstepsEvent; // œcie¿ka dostêpu do eventu / snapshotu // ENG - path to the event / snapshot

    private void Footsteps()
    {
        // jednorazowe odtworzenie // ENG - oneshot
        FMODUnity.RuntimeManager.PlayOneShot(footstepsEvent); // stworzenie klasy snapshotu ze œcie¿k¹ do wybranego snapshotu i jednorazowe odtworzenie
                                                              // ENG - Create a snapshot class with the path to the selected snapshot and play it once
        // podstawowe zarz¹dzanie eventem
        // ENG - basic event management
        FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent); // podanie klasie eventu œcie¿ki do wybranego eventu / snapshotu
                                                                                  // ENG - giving the event class the path to the selected event / snapshot
        FootstepsSound.setParameterByNameWithLabel("Footsteps_surface", "Stone"); // zmiana wartoœci parametru zadeklarowanego lub wykorzystanego w evencie
                                                                                  // ENG - changing the value of a parameter declared or used in an event
        FootstepsSound.start(); // odtworzenie eventu // ENG - event playback
        FootstepsSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); // STOP bez fadeout // ENG - stop without fading out
        FootstepsSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // STOP z fadeout // ENG - stop with fading out
        FootstepsSound.release(); // zwolnienie pamiêci // ENG - memory release

        // zarz¹dzanie eventem z przypiêciem emittera do gameObjectu 
        // ENG - Event management with pinning the emitter to the gameObject
        FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent);
        FootstepsSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform)); // !!!!11! przypiêcie emittera eventu do gameObjectu !!!11!!
                                                                                                     // ENG - !!!!11! pinning the event emitter to the gameObject !!!11!!
        FootstepsSound.setParameterByNameWithLabel("Footsteps_surface", "Stone");
        FootstepsSound.start();
        FootstepsSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        FootstepsSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        FootstepsSound.release();
    }
    #endregion

    #region SNAPSHOT
    // SNAPSHOT
    FMOD.Studio.EventInstance HealthSnap; // klasa eventu / snapshotu // ENG - event / snapshot class
    public EventReference healthSnapshot; // œcie¿ka dostêpu do eventu / snapshotu // ENG - path to the event / snapshot

    private void StartSnapshot()
    {
        if (tavernEmitter != null && tavernEmitter.IsPlaying()) // sprawdzenie czy event emitter istnieje na scenie i czy jest aktywny
                                                                // ENG - checking if the event emitter exists on the scene and if it is active
        {
            HealthSnap = FMODUnity.RuntimeManager.CreateInstance(healthSnapshot); // podanie klasie snapshotu œcie¿ki do wybranego eventu / snapshotu
                                                                                  // ENG - giving the snapshot class the path to the selected event / snapshot
            HealthSnap.start(); // w³¹czenie snapshotu // ENG - snapshot activation
        }
        else if (tavernEmitter != null && tavernEmitter.IsPlaying())
        {
            HealthSnap.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); // STOP bez fadeout // ENG - stop without fading out
            HealthSnap.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // STOP z fadeout // ENG - stop with fading out
            HealthSnap.release(); // zwolnienie pamiêci // ENG - memory release
        }
    }
    #endregion

    #region VCA
    // VCA
    FMOD.Studio.VCA GlobalVCA; // klasa VCA // ENG - VCA's class

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
                                                                                  // ENG - giving the event class the path to the selected event / snapshot
        Music.setParameterByNameWithLabel("Switch_parts", "Part 2"); // zmiana wartoœci parametrów typu labeled dla eventów
                                                                     // ENG - changing labeled parameter values for events
        Music.start(); // odtworzenie eventu // ENG - event playback
        Music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); // STOP bez fadeout // ENG - stop without fading out
        Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // STOP z fadeout // ENG - stop with fading out
        Music.release(); // zwolnienie pamiêci


        // EMITTER
        tavernEmitter_Music.SetParameter("Switch_parts", 0); // zmiana wartoœci parametrów typu labeled dla event emitterów
                                                             // ENG - changing labeled parameter values for event emitters
        tavernEmitter_Music.Play(); // w³¹czenie odtwarzania na emitterze // ENG - enableing playback on the emitter
        tavernEmitter_Music.Stop(); // wy³¹czenie odtwarzania na emitterze // ENG - disabling playback on the emitter
    }
    #endregion
}
