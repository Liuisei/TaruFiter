using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_enemyPrefab = null;
    [SerializeField,Range(0.1f,1f)] float m_interval = 0.25f;
    float m_timer;

    private void Update()
    {
        m_timer += Time.deltaTime;
        if(m_timer > m_interval)
        {
            m_timer = 0;
            GameObject newenemy = Instantiate(m_enemyPrefab,this.gameObject.transform.position,m_enemyPrefab.transform.rotation);
            EnemyController newenecon = newenemy.GetComponent<EnemyController>();
            newenecon.SetHp(1*(int)StageManager.instance.GetTime()); 
        }
    }
}
