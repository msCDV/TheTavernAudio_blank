using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms_new : MonoBehaviour
{
    private AudioSystem audioSystem;

    private void Start()
    {
        audioSystem = FindObjectOfType<AudioSystem>();
    }

    private void OnTriggerStay(Collider other)
    {
        audioSystem.RoomsAmbientON();
    }

    private void OnTriggerExit(Collider other)
    {
        audioSystem.RoomsAmbientOFF();
    }
}
