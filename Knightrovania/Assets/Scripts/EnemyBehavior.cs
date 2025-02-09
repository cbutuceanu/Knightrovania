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
    
    private CircleCollider2D body;
    [SerializeField]
    private int health;
    [SerializeField]
    private int max_Health = 2;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private bool isDead;

    [SerializeField]
    private int scoreValue;

    public static event Action<int> onKill;
    


    //start Couroutine for movement
    private void Start()
    {
        isDead = false;
        if (!isDead)
        {
            StartCoroutine(Patrol());
        }
    }
    


    public void Damage(int dmg_Amount)
    {
        health = Mathf.Clamp((health - dmg_Amount), 0, 2);

        if (health == 0)
        {
            Death(scoreValue);
        }
    }

    IEnumerator Patrol()
    {
        var start = starting_Point.transform.position;
        var end = ending_Point.transform.position;
        
        while (!isDead)
        {
            yield return StartCoroutine(Movement(start, end));
            yield return StartCoroutine(Movement(end, start));
        }
    }
    
    //Lerps the movement of the enemies between two points
    // Could honestly make this a co-routine
    IEnumerator Movement(Vector3 start, Vector3 end)
    {
        if (!isDead)
        {
            float timer = 0;

            while (timer < travel_Time)
            {
                float temp = timer / travel_Time;
                gameObject.transform.position = Vector2.Lerp(start, end, temp);
                timer += Time.deltaTime * travelSpeed;
                yield return null;
            }
        
            //flip the animation
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
       
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!isDead)
        {
            if (other.gameObject.CompareTag("Knightro"))
            {
                PlayerMovement playerMovement = GameObject.FindAnyObjectByType<PlayerMovement>();
                HealthController hc = other.gameObject.GetComponent<HealthController>();
            
                playerMovement.hitDuration = 2f;
                hc.TakeDamage(damage);
                // knock the player backwards
            
            }
        }
    }

    private void Death(int value)
    {
        isDead = true;
        onKill?.Invoke(value);
        Destroy(this.gameObject);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }


    //I think that the dmg portion of the enemy interaction should be handled on the player side of the interaction 
    //
    
}
