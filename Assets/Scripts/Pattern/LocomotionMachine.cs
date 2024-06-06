namespace Pattern
{
    public class LocomotionMachine : Fsm
    {
        private ILocomotionState _currentState;
        private IdleState _idle;
        private WalkState _walk;


        public override void Initialisation(IState state)
        {
            _currentState = (ILocomotionState) state;
            _currentState.Enter();
        }

        public override void ChangeTo(IState newState)
        {
            _currentState.Exit();
            _currentState = (ILocomotionState) newState;
            newState.Enter();
        }

        public override void Update()
        {
            _currentState?.Update();
        }
    }
}