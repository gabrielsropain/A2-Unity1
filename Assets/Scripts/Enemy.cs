using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float speed = 3f;
    Transform player;
    GameManager game;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        game = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void TakeDamage()
    {
        game.EnemyDied();
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable target = collision.gameObject.GetComponent<IDamageable>();
            target.TakeDamage();
        }
    }
}
