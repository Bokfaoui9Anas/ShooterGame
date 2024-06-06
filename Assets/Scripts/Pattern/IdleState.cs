using Controllers;
using UnityEngine;

namespace Pattern
{
    public class IdleState : ILocomotionState
    {
        private readonly PlayerContoller _playerContoller;

        public IdleState(PlayerContoller playerContoller)
        {
            _playerContoller = playerContoller;
        }

        public void Enter()
        {
            Debug.Log("idle enter");
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.W))
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Walk", _playerContoller));
        }

        public void Exit()
        {
            Debug.Log("idle exit");
        }
    }
}