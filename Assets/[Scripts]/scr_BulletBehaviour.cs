using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BulletBehaviour : MonoBehaviour
{

    [Header("Bullet Movement")]
    [Range(0.0f, 1.0f)]
    public float speedValue;
    public scr_BulletManager bulletManager;
    public scr_Bounds bulletBounds;
    public scr_BulletDirection direction;

    private Vector3 bulletVelocity;

    private void Start()
    {
        bulletManager = GameObject.FindObjectOfType<scr_BulletManager>();

        switch (direction)
        {
            case scr_BulletDirection.UP:
                bulletVelocity = new Vector3(0f, speedValue, 0f);
                break;
            case scr_BulletDirection.RIGHT:
                bulletVelocity = new Vector3(speedValue, 0f, 0f);
                break;
            case scr_BulletDirection.DOWN:
                bulletVelocity = new Vector3(0f, -speedValue, 0f);
                break;
            case scr_BulletDirection.LEFT:
                bulletVelocity = new Vector3(-speedValue, 0f, 0f);
                break;
        }
    }


    void FixedUpdate()
    {

        Move();
        CheckBounds();
    }

    public void Move()
    {


        transform.position += bulletVelocity;
    }

    public void CheckBounds()
    {
        // checks bottom bounds
        if (transform.position.y < bulletBounds.min)
        {
            bulletManager.ReturnBullet(gameObject);
        }

        //check top bounds
        if (transform.position.y > bulletBounds.max)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }
}
