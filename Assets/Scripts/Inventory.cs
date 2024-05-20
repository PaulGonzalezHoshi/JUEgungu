using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] inventory = new Item[3];
    public Transform[] itemsTransforms = new Transform[3];
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private TextMeshProUGUI itemText;

    public bool IsInventoryFull => System.Array.Exists(inventory, item => item == null) == false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(ItemInteract item)
    {
        int index = System.Array.FindIndex(inventory, i => i == null);
        if (index != -1)
        {
            transform.gameObject.SetActive(false);            
            inventory[index] = item.item;
            itemsTransforms[index] = item.transform;
            item.transform.SetParent(transform);
            item.transform.localPosition = Vector3.zero;
            inventoryUI.UpdateInventoryUI();
        }
        else
        {
            itemText.SetText($"The inventory is full");
        }
    }

    #region UIMethods
    public void DropItem(int index, bool destroy)
    {
        if (inventory[index] == null && itemsTransforms[index] == null) return;

        inventory[index] = null;

        if (destroy)
        {
            Destroy(itemsTransforms[index].gameObject);
        }
        else
        {
            itemsTransforms[index].parent = null;
            itemsTransforms[index].gameObject.SetActive(true);
            itemsTransforms[index] = null;
        }
    }
    #endregion
}
