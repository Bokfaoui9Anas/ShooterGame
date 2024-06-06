using Pattern;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Controllers
{
    public class PlayerContoller : MonoBehaviour
    {
        [SerializeField] private ILocomotionState _state;
        [field: SerializeField] public Fsm Machine { get; private set; }
        [SerializeField] private Animator _anim;
        [SerializeField] private Vector3Variable Input;
        
        


        void Start()
        {
            Machine = new LocomotionMachine();
            Machine.Initialisation(LocomotionFactory.Create("Walk", this));
        }

        void Update()
        {
            Machine.Update();
        }
    }
    
}