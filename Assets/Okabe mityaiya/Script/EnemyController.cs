using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]Å@int _hp;

    float _maxHp;

    private void Start()
    {
        Destroy(gameObject,5);
        _maxHp = _hp;
    }

    public void SetHp(int value)
    {
        _hp = value;
    }

    private void Update()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.Lerp(Color.red, Color.white, _hp/_maxHp); 
        if (_hp <= 0)
        {
            StageManager.instance.AddScore(10);
            Debug.Log("aa");
            Destroy(this.gameObject);
        }
    }
    public void damege(int n)
    {
        _hp -= n;
    }
}
