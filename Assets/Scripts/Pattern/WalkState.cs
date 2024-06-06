using Controllers;
using UnityEngine;

namespace Pattern
{
    public class WalkState : ILocomotionState
    {
        private readonly PlayerContoller _playerContoller;

        public WalkState(PlayerContoller playerContoller)
        {
            _playerContoller = playerContoller;
        }

        public void Enter()
        {
            Debug.Log("Walk enter");
        }

        public void Update()
        {
            var move = _playerContoller.Input.Value * Time.deltaTime * _playerContoller.speed;
            _playerContoller.CharacterController.Move(move);
            if(_playerContoller.Input == Vector3.zero)
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Idle", _playerContoller));
        }

        public void Exit()
        {
            Debug.Log("Walk exit");
        }
    }
}