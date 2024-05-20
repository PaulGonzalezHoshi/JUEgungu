using UnityEngine;

public class AnimationGenericInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = animator == null ? GetComponent<Animator>() : animator;
    }

    public void Interact()
    {
        bool newState = animator.GetBool("Start");
        animator.SetBool("Start", newState);
    }
}
