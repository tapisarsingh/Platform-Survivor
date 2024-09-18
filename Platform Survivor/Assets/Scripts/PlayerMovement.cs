using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    //    public AudioSource source;
    // public AudioClip jumping;
    public float runSpeed;

    float horizontalMove = 0f;
    [SerializeField] bool jump = false;
    bool crouch = false;
    // Update is called once per frame
    void Update()
    {
        //  speedMuliplier += 0.0005f;
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed ;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            // PlayCLip(jumping);
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            crouch = true;
        }
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            crouch = false;
        }
        if (transform.position.y < -2)
        {
            animator.SetBool("Falling", true);
        }
    }
    void PlayCLip(AudioClip clip)
    {
        //source.PlayOneShot(clip);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
