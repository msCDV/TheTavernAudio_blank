using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class Health_new : MonoBehaviour
{
    private AudioSystem audioSystem;

    private void Start()
    {
        audioSystem = GetComponent<AudioSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            audioSystem.HealthSnap();
        }
    }
}