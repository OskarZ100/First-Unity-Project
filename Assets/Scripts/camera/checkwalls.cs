using UnityEngine;

public class checkwalls : MonoBehaviour
{

    //public GameObject cameraCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            other.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("wall"))
        {
            other.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
