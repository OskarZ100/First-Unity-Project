using UnityEngine;
using TMPro;
using NUnit.Framework;
public class CoinDetector : MonoBehaviour
{
    public bool isUpgrade = false;
    [SerializeField] private Material original;
    [SerializeField] private Material upgrade;
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
            if (isUpgrade)
            {
                GameManager.instance.speedIncrease();
            }
            GameManager.instance.AddScore();
            
            
            float rand_z = Random.Range(-14,22);
            float rand_x = Random.Range(-15,10);
            Vector3 new_position = new Vector3(rand_x, 0.66f, rand_z);
            transform.position = new_position;
            resetStatus();

        }
    }

    private void resetStatus()
    {   
        Renderer renderer = GetComponent<Renderer>();
        System.Random rand = new System.Random();
        int randomInt = rand.Next(2, 5); 
        if(randomInt == 4)
        {
            isUpgrade = true;
            Debug.Log("UPGRADEEE");
            renderer.material = upgrade;
        }
        else
        {   
            renderer.material = original;
            isUpgrade = false;
        }
    }
}
