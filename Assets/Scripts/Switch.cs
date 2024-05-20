using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{    
    public bool isPressed;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Interact()
    {
        isPressed = !isPressed;
        animator.SetBool("Start", !animator.GetBool("Start"));
    }
}
