using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms_new : MonoBehaviour
{
    private AudioSystem audioSystem;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        audioSystem = player.GetComponent<AudioSystem>();
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
