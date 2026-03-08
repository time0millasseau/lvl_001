using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private bool canDash = true;
    public bool isDashing;
    private float dashingPower = 15f;
    private float dashingTime = 0.15f;
    private float dashingCooldown = 1f;


    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    
public IEnumerator Dash()
{
    canDash = false;
    isDashing = true;

    float originalGravity = rb.gravityScale;
    rb.gravityScale = 0f;

    float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Vertical");

    Vector2 dashDirection = new Vector2(horizontal, vertical);

    if (dashDirection == Vector2.zero)
        dashDirection = new Vector2(transform.localScale.x, 0);

    dashDirection.Normalize();

    tr.emitting = true;

    float elapsedTime = 0f;

    while (elapsedTime < dashingTime)
    {
        rb.velocity = dashDirection * dashingPower;
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    tr.emitting = false;

    rb.gravityScale = originalGravity;
    isDashing = false;

    yield return new WaitForSeconds(dashingCooldown);
    canDash = true;
}
}
