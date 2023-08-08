using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageUICont : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreTMP;
    [SerializeField] TextMeshProUGUI _timeTMP;




    private void OnEnable()
    {
        if (StageManager.instance != null)
        {
            StageManager.instance.ScoreChanged += UpdateScoreText; // MoneyChangedイベントにUpdateMoneyTextメソッドを登録
            StageManager.instance.TimeChanged += UpdateTimeText;
            UpdateScoreText();

        }
        else
        {
            Invoke("OnEnable", 0.1f);
        }
   
    }

    private void OnDisable()
    {
        StageManager.instance.ScoreChanged -= UpdateScoreText; // MoneyChangedイベントにUpdateMoneyTextメソッドを登録
        StageManager.instance.TimeChanged -= UpdateTimeText;
    }



    public void UpdateScoreText()
    {
        _scoreTMP.SetText(StageManager.instance.GetScore().ToString());
    }

    public void UpdateTimeText()
    {
        _timeTMP.SetText(StageManager.instance.GetTime().ToString("F1"));

    }


}
