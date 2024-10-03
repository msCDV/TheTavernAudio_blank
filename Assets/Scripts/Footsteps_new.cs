using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Footsteps_new : MonoBehaviour
{
    private AudioSystem audioSystem;

    private float lastFootstepTime = 0f;
    
    private void Start()
    {
        audioSystem = FindObjectOfType<AudioSystem>();
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
            if (audioSystem.IsGrounded() && Time.time - lastFootstepTime > 0.5f)
            {
                lastFootstepTime = Time.time;
                audioSystem.PlayFootsteps();
            }
        }
    }

    // FOOSTEPS RUNNING FUNCTION
    private void Running()
    {
        if ((Input.GetKey(KeyCode.LeftShift) && Input.GetAxisRaw("Horizontal") != 0) || (Input.GetKey(KeyCode.LeftShift) && Input.GetAxisRaw("Vertical") != 0))
        {
            if (audioSystem.IsGrounded() && Time.time - lastFootstepTime > 0.25f)
            {
                lastFootstepTime = Time.time;
                audioSystem.PlayFootsteps();
            }
        }
    }

    // PLAY JUMPING SOUND
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(audioSystem.IsGrounded());
            audioSystem.PlayJump();
        }
    }

    // PLAY LANDING SOUND
    private void OnCollisionEnter(Collision col)
    {
        if (audioSystem.IsGrounded() && audioSystem.isGrounded == false)
        {
            audioSystem.PlayLanding();
        }
    }    
}
