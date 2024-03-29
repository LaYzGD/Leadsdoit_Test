using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    private int _movementAxis;
    private bool _isAcceleration;
    private bool _isDeceleration;

    public int MovementAxis => _movementAxis;
    public bool IsAcceleration => _isAcceleration;
    public bool IsDeceleration => _isDeceleration;

    public void OnAxisInput(InputAction.CallbackContext context) 
    {
        _movementAxis = Mathf.RoundToInt(context.ReadValue<float>());
    }

    public void OnAccelerationInput(InputAction.CallbackContext context)
    {
        if (context.started) 
        {
            _isAcceleration = true;
            _isDeceleration = false;
        }

        if (context.canceled) 
        {
            _isAcceleration = false;
        }
    }

    public void OnDecelerationInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isDeceleration = true;
            _isAcceleration = false;
        }

        if (context.canceled)
        {
            _isDeceleration = false;
        }
    }
}
