using UnityEngine;

public class LookPlayerAt : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        target = GameManager.instance.player.transform;
    }
    void LateUpdate()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0; 
        Quaternion targetRotation = Quaternion.LookRotation(direction.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
    }
}
