using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    void Update()
    {
        //May need to change to rigiBody for collsions and stuff
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
