using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject prefabExplotion;
    public AudioSource sfxManger;

    public int bulletSpeed;
    Transform _ComponentTransform;
    void Awake()
    {
        _ComponentTransform = GetComponent<Transform>();
    }
    void Update()
    {
        _ComponentTransform.position = new Vector2(_ComponentTransform.position.x, _ComponentTransform.position.y + bulletSpeed * Time.deltaTime);
        if (_ComponentTransform.position.y > 5.5)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyShip")
        {
            //No se porque no funciona el sfx
            sfxManger.Play();
            //
            Instantiate(prefabExplotion, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
