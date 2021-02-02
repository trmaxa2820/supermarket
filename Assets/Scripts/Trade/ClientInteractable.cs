using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClientInteractable: MonoBehaviour
{
    [SerializeField] public Transform _interacteblePlace;

    public Vector3 InteractablePlace => _interacteblePlace.position;
    public abstract void Interact(Client client);
}
