using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private float stamina;
    [SerializeField] private float timeForRechargeStamina;
    [SerializeField] private float staminaRechargeMultiplier;
    [SerializeField] private Image staminaImage;
    private float maxStamina;
    private float maxTimeForRechargeStamina;
    private IPlayerMovementControler iPlayerMovementControler;
    #endregion

    #region Methods

    void Start()
    {
        iPlayerMovementControler = GetComponent<IPlayerMovementControler>();
        maxStamina = stamina;
        maxTimeForRechargeStamina = timeForRechargeStamina;
    }

    public void ConsumeStamina()
    {
        stamina -= Time.deltaTime;
        maxTimeForRechargeStamina = Time.time + timeForRechargeStamina;
        UpdateStaminaImage();
        if(stamina < 0) iPlayerMovementControler.CanRun = false;
    }

    public void RechargeStamina()
    {
        if(Time.time > maxTimeForRechargeStamina && stamina < maxStamina)
        {
            stamina += Time.deltaTime * staminaRechargeMultiplier;
            stamina = Mathf.Clamp(stamina, 0, maxStamina);
            iPlayerMovementControler.CanRun = true;
            UpdateStaminaImage();
        }
    }

    private void UpdateStaminaImage()
    {
        staminaImage.fillAmount = stamina / maxStamina;
    }
    #endregion
}
