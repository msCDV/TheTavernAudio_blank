using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outside_foot_switch_new : MonoBehaviour
{
    private AudioSystem OutsideSnap;

    // Start is called before the first frame update
    void Start()
    {
        OutsideSnap = GetComponent<AudioSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OutsideSnap.OutsideSnap();
    }
}
