using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        RoomAmbient roomAmbient = FindObjectOfType<RoomAmbient>();
        roomAmbient.ambientActivated = true;
    }

    private void OnTriggerExit(Collider other)
    {
        RoomAmbient roomAmbient = FindObjectOfType<RoomAmbient>();
        roomAmbient.ambientActivated = false;
    }
}
