using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteRenderer;
    public PlayerDash dash;
    // Start is called before the first frame update

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>(); // on appelle ces components pour la suite
        dash = GetComponent<PlayerDash>();
    }

    public void HandleMovement()
    {
        if (dash.isDashing)
        {
            return;
        }
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move < 0) // si le joueur va vers la gauche
        {
            Debug.Log("le joueur se déplace vers la gauche");
            SpriteRenderer.flipX = true; // retourner le sprite 
        }
        else if (move > 0)
        {
            Debug.Log("le joueur se d�place vers la droite");
            SpriteRenderer.flipX = false; // sprite dans le bon sens 
        }
    }
    
}
