
using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    public static int _moneyScore;
    private TextMeshProUGUI _moneyScoreUI;

    private void Awake()
    {
        _moneyScoreUI = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameEvents.instance.IncrementMoneyScore += AddMoney;
        GameEvents.instance.DecrementMoneyScore += SubtractMoney;
    }

    private void OnDisable()
    {
        GameEvents.instance.IncrementMoneyScore -= AddMoney;
        GameEvents.instance.DecrementMoneyScore -= SubtractMoney;
        
    }

    private void AddMoney(int money)
    {
        _moneyScore += money;
        _moneyScoreUI.text = _moneyScore.ToString();
        transform.DORewind ();
        transform.DOPunchScale (new Vector3 (1, 1, 1), .25f);
    }

    private void SubtractMoney(int money)
    {
        _moneyScore -= money;
        _moneyScoreUI.text = _moneyScore.ToString();
        transform.DORewind ();
        transform.DOPunchScale (new Vector3 (1, 1, 1), .25f);
    }
}
