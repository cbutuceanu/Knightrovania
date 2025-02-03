using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //the enemy will patrol these two set points
    [SerializeField]
    private GameObject spawnpoint;
    
    [SerializeField]
    private GameObject endpoint;

    [SerializeField] 
    private float lerpTime;

    [SerializeField]
    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Probably should be removed unless anything specific needs to be done with the enemy doing something on spawn
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //Lerps the movement of the enemies between two points
    // Could honestly make this a co-routine
    void Movement()
    {
        lerpTime = 0;

        while (lerpTime < 1)
        {
            this.transform.position = Vector3.Lerp(spawnpoint.transform.position, endpoint.transform.position, lerpTime);
            lerpTime += Time.deltaTime * speed;
            //when this loop is broken then you should flip the animation
            //Flip
        }
        //Needs to also take account of what direction the enemy is facing then flip
      
        
    }

    //Flips the animation
    void Flip()
    {
        //
    }
    
    //I think that the dmg portion of the enemy interaction should be handled on the player side of the interaction 
    //
    
}
