using Controllers;
using UnityEditor.IMGUI.Controls;

namespace Pattern
{
    public class LocomotionMachine : Fsm
    {
        private IdleState _idle;
        private ILocomotionState _currentState;

       
        protected override void Initialisation(IState state)
        {
            state = _currentState;
            _currentState.Enter();
        }

        protected override void ChangeTo(IState newState)
        {
          _currentState.Exit();
          _currentState = newState as ILocomotionState;
          newState.Enter();
            
        }

        protected override void Update()
        {
            _currentState?.Update();
        }
    }
}