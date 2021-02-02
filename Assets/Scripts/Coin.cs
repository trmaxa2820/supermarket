using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Coin : MonoBehaviour,ISelectable
{
    [SerializeField] private float _rewardOnPickUp;
    [SerializeField] private float _timeToDestroy;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("CoinAnimation");
        Destroy(gameObject, _timeToDestroy);
    }

    public void OnSelected()
    {
        Player.Instance.AddMoney(_rewardOnPickUp);
        Destroy(gameObject);
    }

    public void OnDeselected()
    {
        
    }

}
