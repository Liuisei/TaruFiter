using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance = null;

    int _score = 99;
    float _time = 0;

    public event Action ScoreChanged;//デリゲートをイベントとして定義
    public event Action TimeChanged;//デリゲートをイベントとして定義



    private void Start()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        TimeCount();
    }

    /// <summary>     Time         </summary>///

    public void TimeCount()
    {
        _time += Time.deltaTime;
        TimeChanged?.Invoke();
    }
    /// <summary>     SCORE         </summary>///

    public void AddScore(int value)
    {
        _score += value;
        ScoreChanged?.Invoke();
    }

    /// <summary>     PlayerDie SceneMove         </summary>///

    public void PlayerDie()
    {
        Invoke("DieSceneMove", 1);
    }
    private void DieSceneMove()
    {
        GameManager.instance.SceneMove(0);
    }



    /// <summary>     GET         </summary>///
   

    public int GetScore()
    {
        return _score;
    }
    public float GetTime()
    {
        return _time;
    }

}
