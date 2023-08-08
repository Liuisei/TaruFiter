
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1;
    [SerializeField] float _gunRate = 0.5f;
    float _rateTimer;
    Rigidbody2D _rb;
    int _bulletDamage = 5;
    [SerializeField] GameObject _deadPrefub;
    [SerializeField] GameObject _bulletPrefub;
    public int BulletDamage { get { return _bulletDamage; } }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_rateTimer);
        _rateTimer += Time.deltaTime;
        float _hori = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector3(_hori*_moveSpeed, 0);
        if (Input.GetButtonDown("Fire1") || Input.GetKey(KeyCode.Space))
        {
            if(_rateTimer > _gunRate)
            {
                Instantiate(_bulletPrefub).transform.position = this.transform.position;
                _rateTimer = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Enemy"))
        {
            if(_deadPrefub)
            {
                Instantiate(_deadPrefub).transform.position = this.transform.position;
            }
            Destroy(this.gameObject, 1f);
        }
    }
}
