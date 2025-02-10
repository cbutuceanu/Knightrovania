using System;
using System.Collections;
using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyBehavior : MonoBehaviour
{
    //the enemy will patrol these two set points
    [FormerlySerializedAs("start")] [SerializeField]
    private GameObject starting_Point;

    [SerializeField]
    private GameObject ending_Point;

    [SerializeField]
    private float travel_Time;
    
    [SerializeField]
    private float travelSpeed;
    
    private Rigidbody2D body;
    [SerializeField]
    private int health;
    [SerializeField]
    private int max_Health = 2;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private bool isDead;
<<<<<<< Updated upstream
=======

    [SerializeField]
    private int scoreValue;

    [SerializeField] private Vector2 v2start;
    [SerializeField] private Vector2 v2end;
    private bool isFacingRight = false;

    public static event Action<int> onKill;
>>>>>>> Stashed changes
    


    //start Couroutine for movement
    private void Start()
    {
        isDead = false;
<<<<<<< Updated upstream
        StartCoroutine(Patrol());
    }
=======
        v2start = starting_Point.transform.position;
        v2end = ending_Point.transform.position;

        body = gameObject.GetComponent<Rigidbody2D>();
        
        
    }

    private void FixedUpdate()
    {

        StartCoroutine(Patrol(v2start, v2end));
        
    }
    
    
>>>>>>> Stashed changes


    public void Damage(int dmg_Amount)
    {
        health = Mathf.Clamp((health - dmg_Amount), 0, 2);

        if (health == 0)
        {
            Death();
        }
    }
    
    private void Death(int value)
    {
        isDead = true;
        onKill?.Invoke(value);
        Destroy(gameObject);
        gameObject.SetActive(false);
    }

    
    
  
    IEnumerator Patrol(Vector2 start, Vector2 end)
    {
        
        while (!isDead)
        {
            
            yield return StartCoroutine(Movement(start, end));
            yield return StartCoroutine(Movement(end, start));
        }
    }
    
    //Lerps the movement of the enemies between two points
    // Could honestly make this a co-routine
    IEnumerator Movement(Vector2 start, Vector2 end)
    {
        float timer = 0;

<<<<<<< Updated upstream
        while (timer < travel_Time)
        {
            float temp = timer / travel_Time;
            gameObject.transform.position = Vector2.Lerp(start, end, temp);
            timer += Time.deltaTime * travelSpeed;
            yield return null;
=======
            while (timer < travel_Time)
            {
                float temp = timer / travel_Time;
                gameObject.transform.position = Vector2.Lerp(start, end, temp);
                timer += Time.deltaTime * travelSpeed;
                yield return StartCoroutine(Movement(v2end, v2start));;
            }
            
>>>>>>> Stashed changes
        }
        
        //flip the animation
    }

    
<<<<<<< Updated upstream
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            HealthController hc = other.gameObject.GetComponent<HealthController>();
            
            playerMovement.hitDuration = 2f;
            hc.TakeDamage(damage);
            // knock the player backwards
            
        }
    }

    private void Death()
    {
        isDead = true;
        Destroy(gameObject);
    }
    //Flips the animation
   
    
=======

 


>>>>>>> Stashed changes
    //I think that the dmg portion of the enemy interaction should be handled on the player side of the interaction 
    //
    
}
