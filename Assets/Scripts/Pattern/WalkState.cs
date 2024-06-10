using Controllers;
using UnityEngine;

namespace Pattern
{
    public class WalkState : ILocomotionState
    {
        private static readonly int Loco = Animator.StringToHash("loco");

        private readonly Vector3 _move = Vector3.zero;
        private readonly PlayerContoller _playerContoller;


        public WalkState(PlayerContoller playerContoller)
        {
            _playerContoller = playerContoller;
        }

        public void Enter()
        {
         
            _playerContoller.State = PlayerContoller.PlayerState.Walk;
        }

        public void Update()
        {
            setAnimationState(_playerContoller._anim);
            _playerContoller.MovementBase.ExecuteMovement(_playerContoller, _move);
            _playerContoller.Orientation.ExecuteOrientaion(_playerContoller);


            if (_playerContoller.input == Vector3.zero && _playerContoller.isgrounded)
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Idle", _playerContoller));
            if (Input.GetKey(KeyCode.Space) && _playerContoller.isgrounded)
                _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Jump", _playerContoller));
        }


        public void Exit()
        {
           
        }

        public void setAnimationState(Animator anime)
        {
            anime.SetFloat(Loco, _playerContoller.input.Value.magnitude);
        }

        

       
    }
}