using UnityEngine;

public class ItemInteract : MonoBehaviour, IInteractable
{
    [SerializeField] Inventory inventory;
    public Item item;

    public void Interact()
    {
        inventory.AddItem(this);
    }
}
