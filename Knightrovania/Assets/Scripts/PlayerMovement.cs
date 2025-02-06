using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;

    private float speed = 2f;

    public float jumpForce = 4f;

    private bool isFacingRight = true;
    public bool isGrounded;
    public Animator playerAnimator;

    private Vector3 jump;

    public LayerMask GroundLayer;

    public BoxCollider2D GroundCollider;

    [SerializeField] private Transform attackPoint;

    [SerializeField] private float attackRange = .5f;

    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private Rigidbody2D rb;
    //This signifies if the player in currently being knocked back
    [SerializeField] public bool isHit = false;

    //How far the player will be knocked back
    public float hitImpact;
    //How long the player is being knocked back 
    public float hitDuration;

    public float hitTimer;


    [SerializeField]
    private int flashes = 3;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        isGrounded = true;


    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        jump = new Vector3(0.0f, 2.0f, 0.0f);


        //Jumping 

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (rb.velocityY == 0)
            {
                rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            }

        }
        
        //Attacking

        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }

        Flip();


    }


    private void FixedUpdate()
    {
        if (hitDuration <= 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            
        }
        else
        {
            if (isFacingRight)
            {
                rb.velocity = new Vector2(-hitImpact, hitImpact);
                StartCoroutine(Iframes(hitDuration));
                hitDuration = 0f;
            }

            if (!isFacingRight)
            {
                rb.velocity = new Vector2(hitImpact, hitImpact);
                StartCoroutine(Iframes(hitDuration));
                hitDuration = 0f;
            }
        }



    }

    void Attack()
    {
        //play attack animation

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in enemies)
        {
            var temp = enemy.gameObject.GetComponent<EnemyBehavior>();
            temp.Damage(1);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
    
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

    IEnumerator Iframes(float duration)
    {
        float timer = duration / flashes;
        var temp = gameObject.GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(0, 7, true);
        for (int i = 0; i < flashes; i++)
        {
            temp.color = Color.red;
            yield return new WaitForSeconds(timer / 2);
            temp.color = Color.white;
            yield return new WaitForSeconds(timer / 2);
        }
        Physics2D.IgnoreLayerCollision(0, 7, false);

    }




}

