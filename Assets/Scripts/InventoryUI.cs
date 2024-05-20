using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUIGO;
    private GameObject itemShowing;
    private int itemShowingIndex;
    [SerializeField] private Transform itemPose;
    [SerializeField] private Inventory itemsInventory;
    [SerializeField] private Sprite imageEmpty;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private Image[] imageSlots;
    [SerializeField] private Button[] imageButtonSlots;
    [SerializeField] private Button[] dropButtonSlots;
    [SerializeField] private Button[] useButtonSlots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    private void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {            
            inventoryUIGO.SetActive(!inventoryUIGO.activeInHierarchy);
        }
    }

    public void UpdateInventoryUI()
    {
        Item[] items = itemsInventory.inventory;

        for (int i = 0; i < items.Length; i++)
        {
            int index = i;

            if (items[index] == null)
            {
                DeactivateButton(index);
            }
            else
            {
                ActivateButton(items, index);
            }
        }
    }

    private void ActivateButton(Item[] items, int index)
    {
        imageSlots[index].sprite = items[index].sprite;
        dropButtonSlots[index].interactable = true;
        useButtonSlots[index].interactable = true;
        imageButtonSlots[index].interactable = true;
        imageButtonSlots[index].onClick.AddListener(() => ChangeItemInformation(items[index], index));
        dropButtonSlots[index].onClick.AddListener(() => DeleteFromUI(index));
        useButtonSlots[index].onClick.AddListener(() => SelectButtonBehaviour(index));
    }

    private void DeactivateButton(int index)
    {
        imageSlots[index].sprite = imageEmpty;
        dropButtonSlots[index].interactable = false;
        useButtonSlots[index].interactable = false;
        imageButtonSlots[index].interactable = false;
        dropButtonSlots[index].onClick.RemoveAllListeners();
        useButtonSlots[index].onClick.RemoveAllListeners();
    }

    private void ChangeItemInformation(Item item, int itemIndex)
    {
        if(itemShowing != null) Destroy(itemShowing);

        itemShowingIndex = itemIndex;
        itemName.SetText(item.itemName);
        itemDescription.SetText(item.description);
        itemShowing = Instantiate(item.prefab, itemPose.position + item.offsetPosition, Quaternion.Euler(item.rotation), itemPose);
        itemShowing.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void SelectButtonBehaviour(int itemIndex)
    {
        if (!itemsInventory.itemsTransforms[itemIndex].GetComponent<IActionItem>().Action()) return;

        itemsInventory.DropItem(itemIndex, true);
        UpdateInventoryUI();
    }

    private void DeleteFromUI(int itemIndex)
    {
        if (itemShowingIndex == itemIndex) CleanItemInformation();

        itemsInventory.DropItem(itemIndex, false);
        UpdateInventoryUI();
    }

    private void CleanItemInformation()
    {
        itemShowingIndex = 0;
        itemName.SetText("");
        itemDescription.SetText("");
        Destroy(itemShowing);
    }
}
