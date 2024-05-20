using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUIGO;
    [SerializeField] private Player player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private CameraController playerCamera;
    [SerializeField] private Flashlight flashlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CursorHandler(); 
    }

    private void CursorHandler()
    {
        if(inventoryUIGO.activeInHierarchy) { 
            Cursor.lockState = CursorLockMode.None;
            player.IsBlocked = true;
            playerCamera.IsBlocked = true;
            flashlight.IsBlocked = true;
            playerAnimator.SetBool("RunBool", false);
            playerAnimator.SetFloat("MoveForward", 0);
            playerAnimator.SetFloat("MoveRight", 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            player.IsBlocked = false;
            playerCamera.IsBlocked = false;
            flashlight.IsBlocked = false;
        }
    }
}
