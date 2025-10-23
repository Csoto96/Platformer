using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AnimationFSM
{
    public struct Conditions
    {
        public bool isOnGround;
        public bool movingX;
        public bool movingY;
    }

    public abstract class State
    {
        public string animationName;
        protected State(string animationName)
        {
            this.animationName = animationName;
        }

        public abstract bool isMatchingConditions(Conditions conditions);
    }
    public class FSM
    {
        public Conditions conditions;
        public State currentState;
        List<State> states = new List<State>();
        public void AddState(State state)
        {
            states.Add(state);
        }
        public void Update()
        {
            foreach (var state in states)
            {
                if (state.isMatchingConditions(conditions))
                {
                    currentState = state;
                    break;
                }
            }
        }
    }
}
