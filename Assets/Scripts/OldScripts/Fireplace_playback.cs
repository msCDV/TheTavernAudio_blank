using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace_playback : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter fireplaceEmitter;

    private void OnTriggerStay(Collider other)
    {
        fireplaceEmitter.SetParameter("Fire", 0);
    }

    private void OnTriggerExit(Collider other)
    {
        fireplaceEmitter.SetParameter("Fire", 1);
    }
}
