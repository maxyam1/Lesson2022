using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] int damage = 10;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null) 
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
