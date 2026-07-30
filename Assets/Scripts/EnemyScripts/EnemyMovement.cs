using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    public float speed = 0.02f;

    void Start()
    {
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
}
