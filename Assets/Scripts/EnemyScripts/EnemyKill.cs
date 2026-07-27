using UnityEngine;

public class EnemyKill : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.Death();
        }
    }
}
