using Controllers;
using UnityEngine;

namespace Pattern
{
    public class WalkState : ILocomotionState
    {
        private PlayerContoller _playerContoller;
        
        public WalkState(PlayerContoller playerContoller)
        {
            this._playerContoller = playerContoller;
        }
        public void Enter()
        {
            Debug.Log("Walk enter");
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.I))
            {
                _playerContoller.Machine.ChangeTo(new IdleState(_playerContoller));
            }
        }

        public void Exit()
        {
            Debug.Log("Walk enter");
        }
    }
}