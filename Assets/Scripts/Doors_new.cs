using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Doors_new : MonoBehaviour, IInteractable
{
    private AudioSystem audioSystem;

    public float rotationSpeed = 90f; // Degrees per second
    bool doorsOpened = true;
    bool isRotating = false;

    private void Start()
    {
        audioSystem = FindObjectOfType<AudioSystem>();
    }

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

    void DoorsInteract()
    {
        if (doorsOpened == true)
        {
            StartCoroutine(CloseOverTime());
            audioSystem.doorsName = gameObject.name;
            audioSystem.PlayDoorSound();
            doorsOpened = false;
            if(audioSystem.roomsAmbientActivated)
                audioSystem.RoomsSnap();
        }
        else
        {
            StartCoroutine(OpenOverTime());
            audioSystem.doorsName = gameObject.name;
            audioSystem.PlayDoorSound();
            doorsOpened = true;
            if (audioSystem.roomsAmbientActivated)
                audioSystem.RoomsSnap();
        }
    }
}



