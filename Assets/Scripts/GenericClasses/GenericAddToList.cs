using Assets.Scripts;

public class GenericAddToList : GenericUpdateState, IAddToList
{
    private IEntityList interactionHandler;

    private void Awake()
    {
        interactionHandler = FindAnyObjectByType<InteractionHandler>();
    }

    public void AddToList()
    {
        interactionHandler.EntitiesList.Add(this);
    }

    public void RemoveFromList()
    {
        interactionHandler.EntitiesList.Remove(this);
    }
}
