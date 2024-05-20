using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _pivot;
    [SerializeField]
    private Transform _fullBody;
    [SerializeField]
    private float _sensivity;
    [SerializeField]
    private float _angle;

    private float _mouseX;
    private float _mouseY;
    public bool IsBlocked { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (IsBlocked) return;

        CalculateRotation();
    }    
    void LateUpdate()
    { 
        _pivot.rotation = Quaternion.Euler(_mouseY, _mouseX, 0);
    }

    private void CalculateRotation()
    {
        _mouseX += Input.GetAxis("Mouse X");
        _mouseY -= Input.GetAxis("Mouse Y");

        _mouseY = Mathf.Clamp(_mouseY, -_angle, _angle);

        _fullBody.rotation = Quaternion.AngleAxis(_mouseX, Vector3.up);
    }

}
