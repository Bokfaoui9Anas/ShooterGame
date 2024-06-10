using Controllers;
using DG.Tweening;
using Pattern.Extension;
using UnityEngine;

namespace Pattern
{
    public class JumpState : ILocomotionState
    {
        private static readonly int IsJump = Animator.StringToHash("isJump");
        private readonly PlayerContoller _playerContoller;

        private Vector3 endPos;

        public JumpState(PlayerContoller playerContoller)
        {
            _playerContoller = playerContoller;
        }

        public void Enter()
        {
            
            setAnimationState(_playerContoller._anim);
            _playerContoller.State = PlayerContoller.PlayerState.Jump;

            Jump(_playerContoller);
        }

        public void Update()
        {
          
          

            if (_playerContoller.isgrounded)
            {
                if (_playerContoller.input.Value != Vector3.zero)
                    _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Walk", _playerContoller));
                else
                    _playerContoller.Machine.ChangeTo(LocomotionFactory.Create("Idle", _playerContoller));
            }
        }


        public void Exit()
        {
           
        }

        public void setAnimationState(Animator anime)
        {
            anime.SetTrigger(IsJump);
        }

        public void Jump(PlayerContoller playerContoller)
        {
            endPos = Vector3.up + _playerContoller.input.Value * 5;
            _playerContoller.transform.DOJump(endPos + _playerContoller.transform.position,
                _playerContoller.JumpHeight,
                1,
                1f).SetEase(Ease.Linear).OnUpdate(() =>
            {
                if (_playerContoller.input!= Vector3.zero)
                {
                    _playerContoller.MovementBase.ExecuteMovement(_playerContoller,endPos);
                    _playerContoller.Orientation.ExecuteOrientaion(_playerContoller);
                   
                    
                ;}
              
               
               
            });

        }


       
    }
}