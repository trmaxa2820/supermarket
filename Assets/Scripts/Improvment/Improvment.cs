using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Improvment : MonoBehaviour, ISelectable
{
    [SerializeField] private int _maxLvlImprovment;
    [SerializeField] private float _improvmentPrice;
    [SerializeField] private float _improvmentPriceModifierPerLvl;
    [SerializeField] [Range(1.1f, 10f)] private float _improvmentModifier;
    [SerializeField] private Canvas _canvasUI;

    private int _currentLvlImprovment = 1;
    private float _currentPriceImprovment;

    public event UnityAction WasImproved;

    private void Start()
    {
        SetImprovmentPrice();
    }

    public void TryImprovment()
    {

        if (Player.Instance.CurrentMoney < _currentPriceImprovment)
            return;

        Player.Instance.SpendMoney(_currentPriceImprovment);
        _currentLvlImprovment++;
        SetImprovmentPrice();
        WasImproved?.Invoke();
    }

    public float GetImprovmentModifier()
    {
        float improvmentModifier = _currentLvlImprovment == 1 ? 1 : _currentLvlImprovment * _improvmentModifier;

        return improvmentModifier;
    }

    private void SetImprovmentPrice()
    {
        _currentPriceImprovment = _currentLvlImprovment * _improvmentPriceModifierPerLvl * _improvmentPrice;
    }

    public void OnSelected()
    {
        _canvasUI.gameObject.SetActive(true);
    }

    public void OnDeselected()
    {
        _canvasUI.gameObject.SetActive(false);
    }

}
