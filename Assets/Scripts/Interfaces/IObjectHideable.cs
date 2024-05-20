using UnityEngine;

public interface IObjectHideable
{
    public void Hide(HiddingPlace hiddingPlace, Vector3 parentPosition);
    public void Unhide();
}
