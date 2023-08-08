using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]float _bulletSpeed = 5;
    int _bulletDamage = 0;
    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(Vector2.up * _bulletSpeed);
        _player = GameObject.Find("Player");
        _bulletDamage = StageManager.instance.GetScore();
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Enemy"))
        {
            collision.GetComponent<EnemyController>().damege(_bulletDamage);
        }
    }
}
