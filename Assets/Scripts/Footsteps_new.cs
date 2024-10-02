using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Footsteps_new : MonoBehaviour
{
    private AudioSystem Footsteps;

    private float lastFootstepTime = 0f;
    
    private void Start()
    {
        Footsteps = FindObjectOfType<AudioSystem>();
        //Footsteps.distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Update()
    {
        Jump();
    }
    void FixedUpdate()
    {
        Walking();
        Running();
    }

    // FOOSTEPS WALKING FUNCTION
    private void Walking()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (Footsteps.IsGrounded() && Time.time - lastFootstepTime > 0.5f)
            {
                lastFootstepTime = Time.time;
                Footsteps.PlayFootsteps();
            }
        }
    }

    // FOOSTEPS RUNNING FUNCTION
    private void Running()
    {
        if ((Input.GetKey(KeyCode.LeftShift) && Input.GetAxisRaw("Horizontal") != 0) || (Input.GetKey(KeyCode.LeftShift) && Input.GetAxisRaw("Vertical") != 0))
        {
            if (Footsteps.IsGrounded() && Time.time - lastFootstepTime > 0.25f)
            {
                lastFootstepTime = Time.time;
                Footsteps.PlayFootsteps();
            }
        }
    }

    // PLAY JUMPING SOUND
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Footsteps.IsGrounded());
            Footsteps.PlayJump();
        }
    }

    // PLAY LANDING SOUND
    private void OnCollisionEnter(Collision col)
    {
        if (Footsteps.IsGrounded() && Footsteps.isGrounded == false)
        {
            Footsteps.PlayLanding();
        }
    }    
}
