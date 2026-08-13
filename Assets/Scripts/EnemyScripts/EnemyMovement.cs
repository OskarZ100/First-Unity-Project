using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody rb;
    public float speed = 0.02f;
    public int enemyType;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        System.Random rand = new System.Random();
        enemyType = rand.Next(0, 3); 

        // 0 = Normal
        // 1 = jump
        // 2 = SPEED
        if(enemyType == 1)
        {
            StartCoroutine(Jump());

            InvokeRepeating("Jump", 2f, 5f);
        }else if(enemyType == 2)
        {
            Debug.Log("SPEED");

            StartCoroutine(Speed()); 
        }
        


        player = GameManager.instance.player;
    } 
    void Update()
    {
        
        //Using move towards
        transform.position = Vector3.MoveTowards(
            transform.position,  //the thing thats moving position 
            player.transform.position,  //what you want to move towards
            speed*Time.deltaTime    //how fast its moving 
        );
    }

    IEnumerator Jump()
    {
        while (true)
        {
            float oldSpeed = speed;
            yield return new WaitForSeconds(7f);
            rb.AddForce(Vector3.up * 20f, ForceMode.Impulse);
            speed *= 1.3f;
            yield return new WaitForSeconds(3f);
            speed = oldSpeed;
            
        }
    }

    IEnumerator Speed()
    {
        while(true){
            float oldSpeed = speed;
            yield return new WaitForSeconds(5f);
            speed *= 1.2f;
            yield return new WaitForSeconds(2f);
            speed = oldSpeed;
        }
    }
}
