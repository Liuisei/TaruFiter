
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1;
    [SerializeField] float _gunRate = 0.5f;
    float _rateTimer;
    Rigidbody2D _rb;
    [SerializeField] GameObject _deadPrefub;
    [SerializeField] GameObject _bulletPrefub;
    [SerializeField] GameObject _gameOverText;
    bool _gameOver = false;
    public bool GameOver { get { return _gameOver; } }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _gameOverText.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _rateTimer += Time.deltaTime;
        float _hori = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector3(_hori*_moveSpeed, 0);
        if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space))
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
            
            Destroy(this.gameObject);
            _gameOverText.GetComponent<Text>().enabled = true;
        }
    }
}
