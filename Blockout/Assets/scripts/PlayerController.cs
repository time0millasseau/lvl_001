using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement movement; // ici j'appelle les autres scripts et leur donne un nom raccourci
    public PlayerJump jump;
    public PlayerDash dash;
    public PlayerDetection detection;



    // Update is called once per frame
    void Update()
    {
        movement.HandleMovement();// ici j'appelle les fonctions qui viennent de mes autres scripts 
        jump.HandleJump();
        jump.HandleWallJump();
        jump.WallSlide();
        detection.HandleGroundCheck();
        detection.HandleWallCheck();
        detection.HandleCeilingCheck();
        dash.HandleDash();


    }
}
