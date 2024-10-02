using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class Health : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter tavernEmitter;
    private bool health = false;

    FMOD.Studio.EventInstance HealthSnap;

    public EventReference healthSnapshot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (tavernEmitter != null && tavernEmitter.IsPlaying() && !health)
            {
                HealthSnap = FMODUnity.RuntimeManager.CreateInstance(healthSnapshot);
                HealthSnap.start();
                health = !health;
            }
            else if (tavernEmitter != null && tavernEmitter.IsPlaying() && health)
            {
                HealthSnap.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                HealthSnap.release();
                health = !health;
            }
            else
            {
                Debug.LogWarning("Emitter is not assigned or the event is not playing.");
            }
        }
    }
}