using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] int currHealth;
    [SerializeField] int maxHealth;


    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Should clean up this take damage thing dont need to check if alive
    public void takeDamage(int damage)
    {
        currHealth -= damage;
        
        if(currHealth <= 0) {
            Debug.Log("The Player has died");
            Destroy(gameObject);
            FindObjectOfType<GameManager>().loadGameOver();
        }
    }
}
