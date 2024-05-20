using UnityEngine;
using StatesEnum;
using Assets.Scripts;

public class VisibilityManager : MonoBehaviour
{
    [SerializeField] private CharacterController cc;
    [SerializeField] private InteractionHandler interactionHandler;
    private Vector3 lastPosition;    

    void Start()
    {
        interactionHandler = transform.GetComponent<InteractionHandler>();
    }

    public void Hide(HiddingPlace hiddingPlace, Vector3 parentPosition)
    {        
        interactionHandler.UpdateState(State.hide);
        lastPosition = transform.position;
        transform.position = parentPosition + hiddingPlace.inPosition;
        transform.localScale *= hiddingPlace.scale;
        cc.enabled = false;
    }

    public void Unhide()
    {
        transform.position = lastPosition;
        transform.localScale = Vector3.one;
        cc.enabled = true;
    }
}
