using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int bulletDamage;
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    void Update()
    {
        //May need to change to rigiBody for collsions and stuff
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDamage(bulletDamage);
            }

            // Instantiate a particle effect for bullet explosion
            Destroy(gameObject);
        }
    }
}
