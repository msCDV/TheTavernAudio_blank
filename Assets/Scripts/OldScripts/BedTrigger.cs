using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedTrigger : MonoBehaviour
{
    public EventReference DoorsEvent;

    private void OnTriggerEnter(Collider other)
    {
        FMODUnity.RuntimeManager.PlayOneShot(DoorsEvent, transform.position);

        FMOD.Studio.EventInstance bedSound = RuntimeManager.CreateInstance(DoorsEvent);
        bedSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        bedSound.start();
        bedSound.release();
    }
}
