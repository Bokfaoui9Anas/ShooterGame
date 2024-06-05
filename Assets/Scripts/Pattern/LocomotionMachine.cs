using Controllers;
using UnityEditor.IMGUI.Controls;

namespace Pattern
{
    public class LocomotionMachine : Fsm
    {
        private IdleState _idle;
        private ILocomotionState _currentState;


        public override void Initialisation(IState state)
        {
            _currentState = (ILocomotionState) state;
            _currentState.Enter();
        }

        public override void ChangeTo(IState newState)
        {
          _currentState.Exit();
          _currentState = (ILocomotionState)newState;
          newState.Enter();
            
        }

        public override void Update()
        {
            _currentState?.Update();
        }
    }
}