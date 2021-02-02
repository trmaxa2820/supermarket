using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaitingBuyZone : ClientInteractable
{
    [SerializeField] private List<CashBox> _cashBoxes;
    [SerializeField] private ExitSupermarket _supermarketExit;

    private Queue<Client> _clients;
    private Queue<CashBox> _freeCashBoxes;

    public ExitSupermarket ExitSupermarket => _supermarketExit;

    private void OnEnable()
    {
        foreach (CashBox cashBox in _cashBoxes)
            cashBox.CashBoxBecameFree += AddFreeCashBox;
    }

    private void OnDisable()
    {
        foreach (CashBox cashBox in _cashBoxes)
            cashBox.CashBoxBecameFree -= AddFreeCashBox;
    }

    private void Awake()
    {
        _clients = new Queue<Client>();
        _freeCashBoxes = new Queue<CashBox>();

        foreach (CashBox cashBox in _cashBoxes)
        {
            _freeCashBoxes.Enqueue(cashBox);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Client>(out Client client))
        {
            if(client.Target == this)
            {
                _clients.Enqueue(client);
            }
        }
    }

    private void Update()
    {
        if (_clients.Count == 0 || _freeCashBoxes.Count == 0)
            return;

        Client client = _clients.Dequeue();
        Interact(client);
    }

    private void AddFreeCashBox(CashBox cashBox)
    {
        _freeCashBoxes.Enqueue(cashBox);
    }

    public override void Interact(Client client)
    {
        CashBox freeCashBox = _freeCashBoxes.Dequeue();
        client.AddTarget(freeCashBox);
        client.AddTarget(_supermarketExit);
        client.NextTarget();
    }
}
