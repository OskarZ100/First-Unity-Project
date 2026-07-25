using UnityEngine;
using TMPro;

public class CoinDetector : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddScore();
            float rand_z = Random.Range(-14,22);
            float rand_x = Random.Range(-15,10);
            Vector3 new_position = new Vector3(rand_x, 0.66f, rand_z);
            transform.position = new_position;


        }
    }
}
