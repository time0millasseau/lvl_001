using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;
    public float wallJumpForce = 12f;
    public float airSpeed = 5f;
    public float lowJumpMultiplier = 3f;
    public int lastWallSide = 0; //-1 gauche, 1 droite 
    public float wallSlideSpeed = 2f;

    public PlayerDetection Detection;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Detection = GetComponent<PlayerDetection>();
    }

    public void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && Detection.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("Le joueur saute !");
            Detection.isGrounded = false;

        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            // Petit saut si Z rel�ch�
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
        }
    }
    public void HandleWallJump()
    {
        if (Input.GetButtonDown("Jump") && Detection.isTouchingWall)
        {
            int wallSide = Detection.wallSide; // -1 ou 1 selon le mur 

            if (wallSide != lastWallSide)
            {

                rb.velocity = new Vector2(airSpeed, wallJumpForce);
                lastWallSide = wallSide;
                Debug.Log("Le joueur walljump !");
                Detection.isGrounded = false;
                Detection.isTouchingWall = false;
            }

        }
    }

    public void WallSlide()
    {
        if (Detection.isTouchingWall && !Detection.isGrounded && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        }
    }
}
