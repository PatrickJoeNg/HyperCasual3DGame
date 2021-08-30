using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    //General parameters
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] int losePoints = 5;
    [SerializeField] int obstaclePoints = 10;

    private void Update()
    {
        transform.Translate(-Vector3.forward * moveSpeed*Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance.gamePoints <= 0)
                GameManager.instance.gamePoints = 0;

            GameManager.instance.gamePoints -= losePoints;
            
            Debug.Log($"{collision.gameObject.name} has touched.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collector"))
        {
            GameManager.instance.gamePoints += obstaclePoints;
        }
    }
}
