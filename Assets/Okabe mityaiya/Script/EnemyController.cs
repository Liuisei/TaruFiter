using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]Å@int _hp;

   public void SetHp(int value)
    {
        _hp = value;
    }

    private void Update()
    {
        if (_hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void damege(int n)
    {
        _hp -= n;
    }
}
