using ScriptableObjectArchitecture;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Vector3Variable axis;

    [SerializeField] private FloatingJoystick input;

    private void Update()
    {
        axis.Value = new Vector3(input.Horizontal, 0, input.Vertical);
    }
}