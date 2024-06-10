using System;
using Controllers;
using DG.Tweening;
using Pattern.Extension;
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
         var   _move = _playerContoller.Input.Value * _playerContoller.speed * Time.deltaTime;
         _playerContoller.transform.LookAt(_playerContoller.transform.position + _playerContoller.Input);

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

        private Vector3 endPos;
        public void Jump(PlayerContoller playerContoller)
        {
            endPos =  Vector3.up + _playerContoller.Input.Value *5;
          
          //  _playerContoller.Rb.velocity = Vector3.up * _playerContoller.JumpHeight; 
          _playerContoller.transform.DOJump(endPos + _playerContoller.transform.position ,_playerContoller.JumpHeight,1,
              1f).SetEase(Ease.Linear);
        }

    

        #region CharachtereController seq

        /*public void Update()
   {
       Jump(_playerContoller);
       _playerContoller.CharacterController.Move(_playerContoller.playerVelocity.Value);
       _playerContoller.Landing(_playerContoller);
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
       
   }*/
        /*
    public void Jump(PlayerContoller playerContoller)
    {
      //  var up = _playerContoller.playerVelocity.Value.y +Mathf.Sqrt(_playerContoller.JumpHeight * -2f * _playerContoller.Gravity);
        var up = _playerContoller.playerVelocity.Value.y + (playerContoller.Gravity *  _playerContoller.JumpHeight); 
        // DOVirtual.Float(0, 3, 6, (value) =>
        // {
        //     _playerContoller.velocity = _playerContoller.velocity.With(Axis.Y, value);
        //     Debug.Log(value);
        // });
        
        _playerContoller.playerVelocity.Value = _playerContoller.playerVelocity.Value.With(Axis.Y,up) ;
    }
    */

        #endregion

       
    }
}