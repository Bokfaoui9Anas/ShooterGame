using Controllers;

namespace Pattern
{
    class IdleState : ILocomotionState
    {
        private PlayerContoller _playerContoller;
        public IdleState(PlayerContoller playerContoller)
        {
            this._playerContoller = playerContoller;
        }
        public void Enter()
        {
            
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}