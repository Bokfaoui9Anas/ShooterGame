using Pattern;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerContoller : MonoBehaviour
    {
        [SerializeField] private ILocomotionState _state;
        [field: SerializeField] public Fsm Machine { get; private set; }
        [SerializeField] public Animator _anim;
        [SerializeField] public Vector3Variable Input;
         private CharacterController characterController;
        [SerializeField] public float  speed;
        [SerializeField] public bool  _isgrounded = true;
        
        

        public CharacterController CharacterController
        {
            get => characterController; set => characterController = value;
        }


        void Start()
        {
            characterController = this.GetComponent<CharacterController>();
            Machine = new LocomotionMachine();
            Machine.Initialisation(LocomotionFactory.Create("Idle", this));
        }
        

        void Update()
        {
            _isgrounded = characterController.isGrounded;
          //  Landing(this);
           
            
            Machine.Update();
        }

        public void Landing(PlayerContoller playerContoller)
        {
           var gravity = -9.81f;
           var velocity = Vector3.zero;
            velocity.y += gravity * Time.deltaTime;
            if (playerContoller._isgrounded && velocity.y <0.2f)
            {
                velocity.y = -1;
            }
            playerContoller.CharacterController.Move(velocity);
            
            

           
        }


    }
    
}