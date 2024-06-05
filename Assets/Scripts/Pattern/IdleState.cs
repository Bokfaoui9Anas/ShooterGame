using Controllers;
using UnityEngine;

namespace Pattern
{
    public  class IdleState : ILocomotionState
    {
        private PlayerContoller _playerContoller;
        public IdleState(PlayerContoller playerContoller)
        {
            this._playerContoller = playerContoller;
        }
        public void Enter()
        {
            Debug.Log("idle enter");
        }

        public void Update()
        {
            _playerContoller.Machine.ChangeTo(new WalkState(_playerContoller));

        }

        public void Exit()
        {
            Debug.Log("idle exit");

        }
    }
    
}