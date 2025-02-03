using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;

    private float speed = 4f;

    private float jumpForce = 4.6f;

    private bool isFacingRight = true;

    private Vector3 jump;





    [SerializeField] private Rigidbody2D rb;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();



    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        jump = new Vector3(0.0f, 2.0f, 0.0f);




        //Jumping mechanism 



        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);


        }

        Flip();


    }


    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }


    //Grounded Mechanic








    //flip player around if moving opposite direction
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
