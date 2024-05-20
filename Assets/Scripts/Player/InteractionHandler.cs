using System.Collections.Generic;
using UnityEngine;
using StatesEnum;

public class InteractionHandler : MonoBehaviour, IEntityList
{
    private List<IChangeState> entitiesList;

    public List<IChangeState> EntitiesList { get => entitiesList; }

    // Start is called before the first frame update
    void Start()
    {
        entitiesList = new List<IChangeState>();
    }

    public void UpdateState(State state)
    {
        foreach (IChangeState entity in entitiesList)
        {
            entity.UpdateState(state);
        }
    }
}
