using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ClientUI))]
public class Client : MonoBehaviour, IShowingText
{
    private float _purchaseAmount = 0;
    private NavMeshAgent _navMeshAgent;
    private Queue<ClientInteractable> _targets;

    public ClientInteractable Target { get; private set; }
    private ClientUI _clientUI;

    public event UnityAction<string> OnShowingText;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.enabled = true;
        _targets = new Queue<ClientInteractable>();
        _clientUI = GetComponent<ClientUI>();
    }

    public void AddGood(float priceGood)
    {
        _purchaseAmount += priceGood;
    }

    public float BuyGoods()
    {
        float purchaseAmount = _purchaseAmount;
        _purchaseAmount = 0;
        OnShowingText?.Invoke(purchaseAmount.ToString());

        return purchaseAmount;
    }

    public void InitializeCLient(List<ClientInteractable> clientInteractables)
    {
        foreach(ClientInteractable clientInteractable in clientInteractables)
        {
            _targets.Enqueue(clientInteractable);
        }
    }

    public void AddTarget(ClientInteractable clientInteractable)
    {
        _targets.Enqueue(clientInteractable);
    }

    public void NextTarget()
    {
        if (_targets.Count == 0)
            return;

        ClientInteractable target = _targets.Dequeue();
        Target = target;
        _navMeshAgent.SetDestination(target.InteractablePlace);
    }

    public void StartAction(float timeToAction)
    {
        _clientUI.ViewProgress(timeToAction);
    }
}