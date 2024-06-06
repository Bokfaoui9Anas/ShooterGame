using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private FloatingJoystick _input;
    
    [SerializeField] private Vector3Variable _axis;
    
    void Start()
    {
        
    }

    void Update()
    {
        _axis.Value = new Vector3(_input.Horizontal,0,_input.Vertical);
    }
}
