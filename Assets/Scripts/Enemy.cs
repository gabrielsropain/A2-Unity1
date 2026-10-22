using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float speed = 3f;
    Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
