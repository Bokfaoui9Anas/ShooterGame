using System;
using Controllers;
using UnityEngine;

namespace Pattern
{
    public class JumpState : ILocomotionState
    {
        private PlayerContoller _playerContoller;
        private static readonly int IsJump = Animator.StringToHash("isJump");
        public JumpState(PlayerContoller playerContoller)
        {
            _playerContoller = playerContoller;
        }
        public void Enter()
        {
            Debug.Log("Jump enter");
            setAnimationState(_playerContoller._anim);
            Jump(_playerContoller);
           


        }

        public void Update()
        {
            _playerContoller.CharacterController.Move(_playerContoller.velocity);
            if (_playerContoller._isgrounded)
            {
                if (_playerContoller.Input.Value != Vector3.zero)
                {
                    _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Walk", _playerContoller));
                }
                else
                {
                    _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Idle", _playerContoller));

                }

            }
            
        }

        public void Exit()
        {
            Debug.Log("Jump exit");
        }

        public void setAnimationState(Animator anime)
        {
            anime.SetTrigger(IsJump);
        }

        public void Jump(PlayerContoller playerContoller)
        {
            _playerContoller.velocity.y = Mathf.Sqrt(_playerContoller.jumpHeight * -2f * _playerContoller.gravity);
        }

      
       
    }
}