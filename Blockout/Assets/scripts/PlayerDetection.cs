using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public LayerMask platformLayer;  // Layer pour les plateformes (sols, murs, plafonds)

    public bool isGrounded;
    public bool isTouchingWall;
    public bool isTouchingCeiling;

    public int wallSide = 0;

    // Positions des checkeurs
    public Transform groundCheck;
    public Transform wallCheckLeft;
    public Transform wallCheckRight;
    public Transform ceilingCheck;  // Position du check du plafond

    public float groundCheckRadius = 0.2f;
    public float wallCheckDistance = 0.5f;
    public float ceilingCheckRadius = 0.2f; // Rayon pour vérifier le plafond

    public PlayerJump Jump;

    void Update()
    {
        HandleGroundCheck();
        HandleWallCheck();
        HandleCeilingCheck();
    }

    // Vérification du sol
    public void HandleGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, platformLayer);

        if (isGrounded)
        {
            Debug.Log("Le joueur est au sol.");
            Jump.lastWallSide = 0;

        }
    }

    // Vérification des murs
    public void HandleWallCheck()
    {
        bool wallLeft = Physics2D.Raycast(wallCheckLeft.position, Vector2.left, wallCheckDistance, platformLayer);
        bool wallRight = Physics2D.Raycast(wallCheckRight.position, Vector2.right, wallCheckDistance, platformLayer);

        isTouchingWall = wallLeft || wallRight;

        // Déterminer de quel côté se trouve le mur
        if (wallLeft)
        {
            wallSide = -1; // mur à gauche
        }
        else if (wallRight)
        {
            wallSide = 1; // mur à droite
        }
        else
        {
            wallSide = 0; // aucun mur
        }

        if (isTouchingWall)
        {
            Debug.Log("Le joueur touche le mur côté : " + wallSide);
        }
    }

    // Vérification du plafond (au-dessus du joueur)
    public void HandleCeilingCheck()
    {
        // Utilisation de OverlapCircle pour vérifier directement au-dessus du joueur
        isTouchingCeiling = Physics2D.OverlapCircle(ceilingCheck.position, ceilingCheckRadius, platformLayer);

        // Pour déboguer et afficher le rayon de détection du plafond dans l'éditeur
        if (isTouchingCeiling)
        {
            Debug.Log("Le joueur touche un plafond !");
        }
    }

    // Affichage pour déboguer les zones de détection
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);  // Sol

        Gizmos.color = Color.green;
        Gizmos.DrawRay(wallCheckLeft.position, Vector2.left * wallCheckDistance);  // Mur gauche
        Gizmos.DrawRay(wallCheckRight.position, Vector2.right * wallCheckDistance); // Mur droit

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(ceilingCheck.position, ceilingCheckRadius);  // Plafond
    }
}
