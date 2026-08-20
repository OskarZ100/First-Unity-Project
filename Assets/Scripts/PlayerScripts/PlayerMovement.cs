using System;
using System.Runtime.CompilerServices;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Movement var
    public float player_speed = 5f;


    //Grounded Script 
    [SerializeField] private PlayerJump playerjump; 
    [SerializeField] private Rigidbody rb; 
    [SerializeField] private GameObject skin;
    public float jumpForce = 16f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //JUMP LOGIC 
        if (Input.GetKeyDown(KeyCode.Space) && playerjump.isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.gameStarted)
        {
            if (GameManager.instance.isPaused)
            {
                GameManager.instance.isPaused = false;
            }
            else
            {
                GameManager.instance.isPaused = true;
            }
            GameManager.instance.Pause();
            return;
        }


        //Simple movement script using the Input namespace
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        transform.position += movement * player_speed * Time.deltaTime;


        //Will check if being moved at all
        //Then will use a quat value and point at the direction of movement using like built in func
        //added an offset because my model imported weird and all
        if (movement.magnitude > 0.1f)
        {
            skin.transform.rotation = Quaternion.LookRotation(movement) * Quaternion.Euler(-89.98f, 90, 0);
        }
        
        
    }
}
