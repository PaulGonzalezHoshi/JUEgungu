using System.Collections;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject sHW_Light;
    public Light cielingLight;
    [SerializeField]
    private bool _isWorking;
    [SerializeField]
    private Switch _switch;
    [SerializeField]
    private bool _toggleRandomOn;
    [SerializeField]
    private float maxTimeRangeOn = 10;
    [SerializeField]
    private float minTimeRangeOn = 10;
    [SerializeField]
    private float _timeOn;
    [SerializeField]
    private bool _toggleRandomOff;
    [SerializeField]
    private float maxTimeRangeOff = 10;
    [SerializeField]
    private float minTimeRangeOff = 10;
    [SerializeField]
    private float _timeOff;
    private bool _isReady = true;

    // Update is called once per frame
    void Update()
    {

        if (_isWorking && _isReady && _switch.isPressed)
        {
            _isReady = false;
            StartCoroutine("ToggleLight");
        }
        else if (!_isWorking || !_switch.isPressed)
        {
            _isReady = true;
            StopAllCoroutines();
            if (sHW_Light.activeInHierarchy) ChangeLight();
        }

        ToggleGO();
    }

    private void ToggleGO()
    {
        if (sHW_Light.activeInHierarchy)        
            cielingLight.enabled = true;
        
        else        
            cielingLight.enabled = false;
        
    }

    IEnumerator ToggleLight()
    {
        _timeOn = _toggleRandomOn ? Random.Range(minTimeRangeOn, maxTimeRangeOn) : _timeOn;
        ChangeLight();
        yield return new WaitForSeconds(_timeOn);

        _timeOff = _toggleRandomOff ? Random.Range(minTimeRangeOff, maxTimeRangeOff) : _timeOff;
        ChangeLight();
        yield return new WaitForSeconds(_timeOff);

        _isReady = true;
    }

    private void ChangeLight()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(0).SetAsLastSibling();
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
