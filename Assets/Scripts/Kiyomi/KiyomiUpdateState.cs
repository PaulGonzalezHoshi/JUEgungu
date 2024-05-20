using Assets.Scripts;
using StatesEnum;

public class KiyomiUpdateState : GenericAddToList
{
    private void Start()
    {
        stateHandlers.Add(State.hide, GetComponent<KiyomiUSHide>());
    }
}
