using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 
    public float speed = 1.0f; 

    private Vector2 target;  
    
    public int damageAmount = 20; 

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            target = target == (Vector2)pointA.position ? (Vector2)pointB.position : pointA.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); 
            }
        }
    }
}