using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;

    private float speed = 4f;

    private float jumpingPower = 16f;

    private bool isFacingRight = true;



    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask groundLayer;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        }


        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }


        Flip();



    }


    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }


    private bool IsGrounded()
    {

        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);


    }

    private void Flip()
    {

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {

            isFacingRight = !isFacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;

        }


    }



}
