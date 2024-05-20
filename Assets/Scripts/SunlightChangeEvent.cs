using UnityEngine;

public class SunlightChangeEvent : MonoBehaviour
{
    [SerializeField]
    private float _ambientIntensity;
    [SerializeField]
    private float _reflectionIntensity;
    [SerializeField] 
    private Light _sun;

    private bool _isEnvironmentDarked = false;

    void Update()
    {
        //_sun.transform.rotation *= Quaternion.Euler(1 * Time.deltaTime, 0, 0);
        DynamicGI.UpdateEnvironment();
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!_isEnvironmentDarked)
        {
            RenderSettings.reflectionIntensity = _reflectionIntensity;
            RenderSettings.ambientIntensity = _ambientIntensity;
            _isEnvironmentDarked = true;
        }
        else
        {
            RenderSettings.reflectionIntensity = 1;
            RenderSettings.ambientIntensity = 1;
            _isEnvironmentDarked = false;
        }
    }
}
