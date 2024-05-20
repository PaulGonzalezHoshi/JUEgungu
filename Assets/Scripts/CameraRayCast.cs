using UnityEngine;

public class CameraRayCast : MonoBehaviour, ICameraRayCast
{
    [SerializeField] private GameObject helperPoint;
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Player player;
    [SerializeField] private float minDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Actions();
    }

    private void Actions()
    {
        RaycastHit hit;
        if (GetGOHitted(out hit) && !inventoryUI.inventoryUIGO.activeInHierarchy)
        {
            IInteractable interactable = hit.transform.GetComponent<IInteractable>();

            if (interactable != null)
            {
                helperPoint.transform.localScale = Vector3.one * 0.09f;
                if (Input.GetKeyDown(KeyCode.F)) interactable.Interact();
                return;
            }
        }

        helperPoint.transform.localScale = Vector3.one * 0.03f;
    }

    public bool GetGOHitted(out RaycastHit hit)
    {
        return Physics.Raycast(transform.position, transform.forward, out hit, minDistance);
    }
}
