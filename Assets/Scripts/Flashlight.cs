using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private float battery;
    [SerializeField] private Light flashlight;
    [SerializeField] private Image batteryImage;
    private float timeForDischarge;
    public float Battery { get; private set; }

    public bool IsBlocked { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Battery = battery;
    }

    // Update is called once per frame
    void Update()
    {
        DischargeBattery();

        if(IsBlocked) return;

        ToggleLight();

    }

    public void RechargeBattery()
    {
        Battery = 100;
        UpdateFlashlightImage();
    }

    private void DischargeBattery()
    {
        if (!flashlight.enabled)
            return;

        if (timeForDischarge >= 3)
        {
            timeForDischarge = 0;
            Battery -= 1;
            UpdateFlashlightImage();
        }
        else
        {
            timeForDischarge += Time.deltaTime;
        }
    }

    private void UpdateFlashlightImage()
    {
        batteryImage.fillAmount = Battery / 100f;
    }

    private void ToggleLight()
    {
        if(Battery == 0)
        {
            flashlight.enabled = false;
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
