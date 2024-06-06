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
        [SerializeField] private Animator _anim;
        [SerializeField] public Vector3Variable Input;
        [SerializeField] private CharacterController characterController;
        [SerializeField] public float  speed;
        

        public CharacterController CharacterController
        {
            get => characterController; set => characterController = value;
        }


        void Start()
        {
            characterController = this.GetComponent<CharacterController>();
            Machine = new LocomotionMachine();
            Machine.Initialisation(LocomotionFactory.Create("Walk", this));
        }

        void Update()
        {
            Machine.Update();
        }
    }
    
}