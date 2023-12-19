using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float stopDistance;
    [SerializeField] private float attackCooldown;

    private Transform player;



    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Play a death animation
            //Could spawn particles
            Destroy(gameObject);
        }
    }
    public bool canAttack()
    {
        if(player != null)
        {
            if(Time.time > attackCooldown && Vector2.Distance(player.position, transform.position) <= stopDistance)
            {
                attackCooldown = Time.time + attackCooldown;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Debug.Log("The player is dead or null");
        }
        return false;
    }
    public Transform getPlayer() { return player; }
    public int getHealth() { return health; }
    public int getDamage() { return damage; }
    public float getSpeed() { return speed; }
    public float getAttackCooldown() { return attackCooldown; }
    public float getStopDistance() { return stopDistance; }

}
