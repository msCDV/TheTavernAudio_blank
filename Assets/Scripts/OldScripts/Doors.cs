using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Doors : MonoBehaviour, IInteractable
{
    public float rotationSpeed = 90f; // Degrees per second
    bool doorsOpened = true;
    bool isRotating = false;

    ////////////////// FMOD Section ///////////////////

    // Door's sample //
    FMOD.Studio.EventInstance DoorsSound;
    public EventReference DoorsEvent;
    
    // Room's Snapshot //
    FMOD.Studio.EventInstance InsideRoom;
    public EventReference insideRoomSnap;

    ////////////////// FMOD Section End ///////////////////

    public void Interact()
    {
        if (!isRotating)
        {
            DoorsInteract();
        }
    }

    IEnumerator CloseOverTime()
    {
        isRotating = true;
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 65, 0) * startRotation; // Rotating around Y-axis by 90 degrees

        while (elapsedTime < 1f) // Rotate over 1 second
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime * rotationSpeed / 90f; // Normalizing to 90 degrees rotation
            yield return null;
        }

        // Ensure the rotation is exactly what we want at the end
        transform.rotation = targetRotation;
        isRotating = false;
    }

    IEnumerator OpenOverTime()
    {
        isRotating = true;
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, -65, 0) * startRotation; // Rotating around Y-axis by 90 degrees

        while (elapsedTime < 1f) // Rotate over 1 second
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime * rotationSpeed / 90f; // Normalizing to 90 degrees rotation
            yield return null;
        }

        // Ensure the rotation is exactly what we want at the end
        transform.rotation = targetRotation;
        isRotating = false;
    }

    void PlaySound()
    {
        if (doorsOpened == true)
        {            
            DoorsSound = FMODUnity.RuntimeManager.CreateInstance(DoorsEvent);
            DoorsSound.setParameterByNameWithLabel("Doors", "Close");
            DoorsSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
            DoorsSound.start();
            //FMODUnity.RuntimeManager.PlayOneShot(DoorsEvent);
        }
        else
        {
            DoorsSound.setParameterByNameWithLabel("Doors", "Open");
            DoorsSound.start();
            DoorsSound.release();
        }
    }

    void RoomsSnap()
    {
        RoomAmbient roomAmbient = FindObjectOfType<RoomAmbient>();

        if (roomAmbient.ambientActivated == true && doorsOpened == false)
        {
            Debug.Log("im in!");
            InsideRoom = FMODUnity.RuntimeManager.CreateInstance(insideRoomSnap);
            InsideRoom.start();
        }
        else
        {
            if (roomAmbient.ambientActivated == true && doorsOpened == true)
            {
                Debug.Log("it works");
                InsideRoom.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                InsideRoom.release();
            }
        }
    }

    void DoorsInteract()
    {
        if (doorsOpened == true)
        {
            StartCoroutine(CloseOverTime());
            PlaySound();
            doorsOpened = false;
            RoomsSnap();
        }
        else
        {
            StartCoroutine(OpenOverTime());
            PlaySound();
            doorsOpened = true;
            RoomsSnap();
        }
    }
}



