using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    public float CurrentMoney { get; private set; }

    public static Player Instance;
    public event UnityAction<float> OnMoneyChange;

    private void Awake()
    {
        Instance = this;
    }

    public void AddMoney(float money)
    {
        CurrentMoney += money;
        
        OnMoneyChange?.Invoke(CurrentMoney);
    }
    public void SpendMoney(float money)
    {
        CurrentMoney -= money;
        OnMoneyChange?.Invoke(CurrentMoney);
    }
}
