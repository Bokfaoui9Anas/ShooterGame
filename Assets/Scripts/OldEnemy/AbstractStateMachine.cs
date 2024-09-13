using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    
    public class AbstractStateMachine<T> : MonoBehaviour, IStateMachine where T : System.Enum
    {
       
        [SerializeField] protected T startState;

        
        protected Dictionary<T, StateCase> states = new Dictionary<T, StateCase>();

      
        public T CurrentState { get; protected set; }

       
        public bool IsPlaying { get; protected set; }

     
        public void StartMachine()
        {
            IsPlaying = true;

            CurrentState = startState;
            StartState();
        }

 
        private void StartState()
        {
            var state = states[CurrentState].state;

            state.OnFinished += OnStateFinished;
            state.OnStart();
        }

       
        private void EndState()
        {
            var state = states[CurrentState].state;

            state.OnFinished -= OnStateFinished;
            state.OnEnd();
        }

      
        public void StopMachine()
        {
            IsPlaying = false;

            var state = states[CurrentState].state;

            state.OnEnd();
        }

      
        private void OnStateFinished()
        {
            var stateCase = states[CurrentState];

            var state = stateCase.state;
            var transitions = stateCase.transitions;

            for (int i = 0; i < transitions.Count; i++)
            {
                var transition = transitions[i];
                if (transition.transitionType == StateTransitionType.OnFinish && transition.Evaluate(out var nextState))
                {
                    EndState();

                    CurrentState = nextState;

                    StartState();
                    break;
                }
            }
        }

     
        private void Update()
        {
            /*if (IsPlaying && LevelController.IsGameplayActive)
            {
                var stateCase = states[CurrentState];

                var state = stateCase.state;
                var transitions = stateCase.transitions;

                state.OnUpdate();

                for (int i = 0; i < transitions.Count; i++)
                {
                    var transition = transitions[i];
                    if (transition.transitionType == StateTransitionType.Independent && transition.Evaluate(out var nextState))
                    {
                        EndState();

                        CurrentState = nextState;

                        StartState();
                        break;
                    }
                }
            }*/
        }

      
        public class StateCase
        {
            public EnemyStateBehavior state;
            public List<StateTransition<T>> transitions;
        }
    }

    public interface IStateMachine
    {
        void StartMachine();
        void StopMachine();
    }
}