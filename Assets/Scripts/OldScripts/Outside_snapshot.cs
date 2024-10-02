using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Outside_snapshot : MonoBehaviour
{
    public bool snapshotActivated = false;
    public FMOD.Studio.EventInstance Outside;
    
    public EventReference outsideSnapshot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Outside");
            if (snapshotActivated == false)
            {
                Outside = FMODUnity.RuntimeManager.CreateInstance(outsideSnapshot);
                Outside.start();
                snapshotActivated = !snapshotActivated;
            }
            else
            {
                Outside.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                Outside.release();
                snapshotActivated = !snapshotActivated;
            }
        }
    }
}
