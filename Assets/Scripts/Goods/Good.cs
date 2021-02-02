using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Good", menuName = "Goods", order = 51)]
public class Good : ScriptableObject
{
    [SerializeField] private float _basePrice;
    [SerializeField] private string _label;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _template;

    public float Price => _basePrice;
    public string Label => _label;
    public Sprite Icon => _icon;
    public GameObject Template => _template;
    public string Description => _description;
}
