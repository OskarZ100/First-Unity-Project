using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject jumper;
    [SerializeField] private GameObject speeder;
    [SerializeField] private GameObject speeder_body;
    private Rigidbody rb;
    public float speed = 0.2f;
    public int enemyType;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        System.Random rand = new System.Random();
        enemyType = 2; 
        //rand.Next(0, 3)
        // 0 = Normal
        // 1 = jump
        // 2 = SPEED
        if(enemyType == 1)
        {
            StartCoroutine(Jump());
            GetComponent<MeshRenderer>().enabled = false;
            jumper.SetActive(true);
            StartCoroutine(Jump());
        }else if(enemyType == 2)
        {
            Debug.Log("SPEED");
            GetComponent<MeshRenderer>().enabled = false;
            speeder.SetActive(true);
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
            jumper.transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
            yield return new WaitForSeconds(1f);
            rb.AddForce(Vector3.up * 20f, ForceMode.Impulse);
            jumper.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
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
            speeder_body.GetComponent<Renderer>().material.color = Color.red; 
            speed *= 2.2f;
            yield return new WaitForSeconds(1.5f);
            speeder_body.GetComponent<Renderer>().material.color = Color.white;
            speed = oldSpeed;
        }
    }
}
