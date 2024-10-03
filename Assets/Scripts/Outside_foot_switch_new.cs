using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outside_foot_switch_new : MonoBehaviour
{
    private AudioSystem audioSystem;

    // Start is called before the first frame update
    void Start()
    {
        audioSystem = GetComponent<AudioSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        audioSystem.OutsideSnap();
    }
}
