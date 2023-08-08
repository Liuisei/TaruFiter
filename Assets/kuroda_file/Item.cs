using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] int _gunRate;
    [SerializeField] int _damageUp;
    [SerializeField] Color _color;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = _color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //GetComponent<Player>().PowerUp(_gunRate,_damageUp);
        }
    }
}
