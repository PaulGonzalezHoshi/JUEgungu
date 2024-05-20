using StatesEnum;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GenericUpdateState : MonoBehaviour, IChangeState
    {
        protected Dictionary<State, IStartActionUpdateState> stateHandlers = new Dictionary<State, IStartActionUpdateState>();
        public void UpdateState(State state)
        {
            if (stateHandlers.ContainsKey(state))
            {
                stateHandlers[state].StartAction();
            }
        }
    }
}