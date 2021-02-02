using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CashBox : ClientInteractable
{
    [SerializeField] private float _timeToApplyClient;

    public event UnityAction<CashBox> CashBoxBecameFree;

    public bool CashBoxFree { get; private set; } = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Client>(out Client client))
        {
            if(client.Target == this)
            {
                Interact(client);
            }
        }    
    }

    public override void Interact(Client client)
    {
        client.StartAction(_timeToApplyClient);
        StartCoroutine(ApplyClient(client));
    }

    private IEnumerator ApplyClient(Client client)
    {
        yield return new WaitForSeconds(_timeToApplyClient);

        Player.Instance.AddMoney(client.BuyGoods());
        client.NextTarget();
        CashBoxFree = true;
        CashBoxBecameFree?.Invoke(this);
    }

    public void TakeCashRegistr()
    {
        CashBoxFree = false;
    }
}
