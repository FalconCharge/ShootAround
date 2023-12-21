using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BasicEnemy : Enemy
{
    [SerializeField] float attackSpeed;


    private bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(getPlayer() != null)
        {
            move();
            if(canAttack() && !isAttacking)
            {
                if(getPlayer() != null)
                {
                    StartCoroutine(Attack());
                }
                
            }

            IEnumerator Attack()
            {
                isAttacking = true;
                try
                {
                    
                    Transform playerTransform = getPlayer();
          
                    PlayerInteractions playerInteractions = playerTransform.GetComponent<PlayerInteractions>();
                    if(playerInteractions != null)
                    {
                        playerInteractions.takeDamage(getDamage());
                    }

                    Vector2 orgPos = transform.position;
                    Vector2 targetPos = playerTransform.position;

                    float percent = 0;

                    while (percent < 1)
                    {
                        percent += Time.deltaTime * attackSpeed;
                        float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
                        transform.position = Vector2.Lerp(orgPos, targetPos, formula);
                        yield return null;
                    } 
                    
                    
                }
                finally
                {
                    isAttacking = false; // Reset the flag even if the coroutine is interrupted
                }

            }
        
        }
        else
        {
            Debug.Log("The player object is null");
        }
    }
    public void move()
    {
        if(Vector2.Distance(transform.position, getPlayer().position) >= getStopDistance())
        {
            transform.position =  Vector2.MoveTowards(transform.position, getPlayer().position, getSpeed() * Time.deltaTime);
        }
        
    }
}
