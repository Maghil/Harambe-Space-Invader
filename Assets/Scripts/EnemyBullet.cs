using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform bullet;
    public float speed = 0.04f;    //good speed for enemy
    public int direction = 2;   //specify the direction to shoot 1->up 2->down 3-> downRight 4->downLeft

    private Vector3 dir;


    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
        switch (direction)
        {
            case 1: dir = Vector3.up; break;
            case 2: dir = Vector3.down; break;
            case 3: dir = new Vector3(1, -1, 0); break;
            case 4: dir = new Vector3(-1, -1, 0); break;
            default: Debug.LogError("bullet direction unspecified"); break;
        }
    }

    private void FixedUpdate()
    {
        bullet.position += dir * speed;
        if (bullet.position.y >= 5 || bullet.position.y <= -5 || bullet.position.x > 3 || bullet.position.x < -3)     //destroy if it crosses the game screen
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("base"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("harambe"))
        {
            Destroy(gameObject);
            FindObjectOfType<LevelManager>().ReduceHealth();
        }
    }
}
