using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    
    private Transform player; // Transform gracza
    public float speed = 3f; // Prędkość poruszania się wroga

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        FindPlayer();
    }

    void Update()
    {
        if (player == null)
        {
            FindPlayer();
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        RotateTowardsPlayer(direction);
    }

    void FindPlayer()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void RotateTowardsPlayer(Vector2 direction)
    {
        // Oblicz kąt między wrogiem a graczem
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Ustaw rotację wroga
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    


}

