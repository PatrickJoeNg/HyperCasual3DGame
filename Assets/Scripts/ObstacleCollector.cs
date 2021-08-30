using UnityEngine;

public class ObstacleCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {           
            Debug.Log($"{other.name} has hit collector.");
            Destroy(other);      
    }
}
