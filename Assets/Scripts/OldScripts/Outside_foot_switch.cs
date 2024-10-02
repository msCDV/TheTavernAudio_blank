using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outside_foot_switch : MonoBehaviour
{
    private float distToGround;

    private bool snapshotActivated = false;
    public FMOD.Studio.EventInstance Outside;
    public EventReference outsideSnapshot;

    // Start is called before the first frame update
    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OutsideSnap();
    }

    private void OutsideSnap()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, distToGround + 0.5f))
        {
            if (hit.collider.CompareTag("Outside") && snapshotActivated == false)
            {
                // mechanika snapshotu
                Outside = FMODUnity.RuntimeManager.CreateInstance(outsideSnapshot);
                Outside.start();
                snapshotActivated = !snapshotActivated;
                Debug.Log(snapshotActivated);
            }
            else if ((hit.collider.CompareTag("Inside_stone") || hit.collider.CompareTag("Inside_wood")) && snapshotActivated == true)
            {
                // mechanika snapshotu
                Outside.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                Outside.release();
                snapshotActivated = !snapshotActivated;
                Debug.Log(snapshotActivated);
            }
        }
    }
}
