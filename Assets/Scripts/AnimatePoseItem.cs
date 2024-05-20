using UnityEngine;

public class AnimatePoseItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up);
    }
}
