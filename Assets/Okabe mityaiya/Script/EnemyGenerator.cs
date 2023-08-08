using System.Collections;
using System.Collections.Generic;
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
            Instantiate(m_enemyPrefab,this.gameObject.transform.position,m_enemyPrefab.transform.rotation);
        }
    }
}
