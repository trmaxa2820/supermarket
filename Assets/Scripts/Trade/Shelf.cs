using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Improvment))]
public class Shelf : ClientInteractable
{
    [SerializeField] private Good _good;
    [SerializeField] private float _timeToSell;
    [SerializeField] private List<Transform> _goodsPositions;

    private Improvment _shelfImprovment;
    private float _currentPriceGood;

    public float TimeToSell => _timeToSell;

    private void OnEnable()
    {
        _shelfImprovment.WasImproved += ChangePrice;    
    }

    private void OnDisable()
    {
        _shelfImprovment.WasImproved -= ChangePrice;
    }

    private void Awake()
    {
        _shelfImprovment = GetComponent<Improvment>();
        InstantiateGoodsOnShelf();
        ChangePrice();
    }

    private IEnumerator SellGood(Client client)
    {
        yield return new WaitForSeconds(_timeToSell);

        client.AddGood(_currentPriceGood);
        client.NextTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Client>(out Client client))
        {
            if (client.Target != this)
                return;

            Interact(client);
        }
    }

    private void ChangePrice()
    {
        _currentPriceGood = _good.Price * _shelfImprovment.GetImprovmentModifier();
    }

    private void InstantiateGoodsOnShelf()
    {
        foreach(Transform transform in _goodsPositions)
        {
            Instantiate(_good.Template, transform);
        }
    }

    public override void Interact(Client client)
    {
        client.StartAction(_timeToSell);
        StartCoroutine(SellGood(client));
    }
}
