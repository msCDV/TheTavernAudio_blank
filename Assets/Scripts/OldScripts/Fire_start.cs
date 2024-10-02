using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Fire_start : MonoBehaviour, IInteractable
{
    public GameObject fireplace;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        fireplace.SetActive(false);

    }

    public void Interact()
    {
        Debug.Log("Interact");
        //Instantiate(fireplace, transform.position, transform.rotation);

        //fireplace.GetComponent<Renderer>(). = true;
        meshRenderer.enabled = true;

        fireplace.SetActive(true);

    }
}
