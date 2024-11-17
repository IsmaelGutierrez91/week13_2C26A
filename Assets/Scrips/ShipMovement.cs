using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    float horizontal;
    float vertical;
    public int shipSpeed;

    Rigidbody2D _ComponentRigidbody2d;

    public AudioSource sfxManager;
    public GameObject prefabBullet;
    void Awake()
    {
        _ComponentRigidbody2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Fire1") == true)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        sfxManager.Play();
        Instantiate(prefabBullet, transform.position,transform.rotation);
    }
    void FixedUpdate()
    {
        _ComponentRigidbody2d.velocity = new Vector2(horizontal*shipSpeed, vertical*shipSpeed);
    }
}
