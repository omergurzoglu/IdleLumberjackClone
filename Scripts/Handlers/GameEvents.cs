using System;
using UnityEngine;


public  class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public event Action EnableShopUI;

    public void OpenShopUI()
    {
        EnableShopUI?.Invoke();
    }

    public event Action DisableShopUI;

    public void CloseShopUI()
    {
        DisableShopUI?.Invoke();
    }
    
    public event Action IncrementWoodScore;
    public void UpdateWoodScore()
    {
        IncrementWoodScore?.Invoke();
    }
    
    public event Action<int> IncrementMoneyScore;

    public void MoneyScorePlus(int money)
    {
        IncrementMoneyScore?.Invoke(money);

    }
    public event Action<int> DecrementMoneyScore;

    public void MoneyScoreMinus(int money)
    {
        DecrementMoneyScore?.Invoke(money);
    }

    public event Action OnDropArea;
    public void EnterDropArea()
    {
        OnDropArea?.Invoke();
    }
    public event Action OffDropArea;
    public void ExitDropArea()
    {
        OffDropArea?.Invoke();
    }

    public event Action ReduceTreeHealth;

    public void ReduceTreeHP()
    {
        ReduceTreeHealth?.Invoke();
    }



}
