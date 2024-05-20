using UnityEngine;

public class Player : MonoBehaviour, IPlayerMovementControler, IHideable, IDataPlayer
{
    #region Variables

    #region MovementVariables

    [Header("Movement")]
    [SerializeField] private MovementController movementController;
    public bool IsCroushed { get; set; } = false;

    #endregion

    #region StaminaVariables

    [Header("Stamina")]
    [SerializeField] private StaminaManager staminaManager;
    public bool CanRun { get; set; } = true;

    #endregion

    #region HideVariables
    public bool IsHidden { get; set; }
    #endregion

    public bool IsBlocked { get; set; }
    #endregion

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    private void HandleInputs()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            movementController.Crouch();
        }

        if (Input.GetKey(KeyCode.LeftShift) && !IsCroushed && CanRun)
        {
            movementController.Move(true);
            staminaManager.ConsumeStamina();
        }
        else
        {
            movementController.Move(false);
            staminaManager.RechargeStamina();
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetForward()
    {
        return transform.forward;
    }
}
