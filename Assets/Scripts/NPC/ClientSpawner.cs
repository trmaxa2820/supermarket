using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{
    [SerializeField] private Client _template;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private WaitingBuyZone _waitingBuyZone;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _timeToSpawnBonusCoin;
    [SerializeField] private int _countSpawnedPerBonusCoin;

    private float _timeAfterLastSpawn;
    private List<ClientInteractable> _clientInteractables;
    private int _countSpawnedClient;

    private void Awake()
    {
        _clientInteractables = new List<ClientInteractable>();
        ClientInteractable[] clientInteractables = FindObjectsOfType<ClientInteractable>();
        
        foreach (ClientInteractable clientInteractable in clientInteractables)
        {
            if (clientInteractable.TryGetComponent<CashBox>(out CashBox cashBox))
                continue;
            else if (clientInteractable.TryGetComponent<WaitingBuyZone>(out WaitingBuyZone waitingBuyZone))
                continue;
            else if (clientInteractable.TryGetComponent<ExitSupermarket>(out ExitSupermarket exitSupermarket))
                continue;
            else
                _clientInteractables.Add(clientInteractable);
        }
    }

    private void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if(_timeAfterLastSpawn >= _timeBetweenSpawn)
        {
            _timeAfterLastSpawn = 0;
            SpawnClient();
            _countSpawnedClient++;
        }
    }

    private void SpawnClient()
    {
        Client client = Instantiate(_template, transform, true);

        if(_countSpawnedClient % _countSpawnedPerBonusCoin == 0 && _countSpawnedClient != 0)
        {
            StartCoroutine(SpawnBonusCoin(client));
        }
        List<ClientInteractable> randomTargets = GetRandomTargets();
        client.InitializeCLient(randomTargets);
        client.AddTarget(_waitingBuyZone);
        client.NextTarget();
    }

    private IEnumerator SpawnBonusCoin(Client client)
    {
        yield return new WaitForSeconds(_timeToSpawnBonusCoin);

        Instantiate(_coinPrefab, client.transform.position, Quaternion.identity);
    }

    private List<ClientInteractable> GetRandomTargets()
    {
        List<ClientInteractable> clientInteractables = new List<ClientInteractable>();
        int startTarget = Random.Range(0, _clientInteractables.Count);
        clientInteractables.Add(_clientInteractables[startTarget]);
        //for(int i = startTarget; i < _clientInteractables.Count; i++)
        //{
        //     clientInteractables.Add(_clientInteractables[i]);
        //}

        return clientInteractables;

    }
}
