using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSupermarket : ClientInteractable
{
    public override void Interact(Client client)
    {
        Destroy(client.gameObject);
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
}
