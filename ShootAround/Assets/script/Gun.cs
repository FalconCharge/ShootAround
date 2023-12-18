using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Transform shootPoint;

    [SerializeField] private GameObject bullet;
    
    void Start()
    {
        GameObject shootPointObject = GameObject.FindWithTag("ShootPoint");

        if (shootPointObject != null)
        {
            shootPoint = shootPointObject.transform;
        }
        else
        {
            Debug.LogError("ShootPoint not found in the scene. Make sure the tag is set correctly.");
        }
    }
    void Update()
    {
        Vector3 mousePosScreen = Input.mousePosition;

        // Convert the mouse position to a point in world space
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePosScreen.x, mousePosScreen.y, Camera.main.transform.position.z));

        // Calculate the direction from the object to the mouse position
        Vector3 direction = mousePosWorld - transform.position;

        // Calculate the angle between the object's forward direction and the direction to the mouse
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) -90f;

        // Rotate the object to face the mouse
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
    public void shoot()
    {
        Instantiate(bullet, shootPoint.position, transform.rotation);
    }
}
