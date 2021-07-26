using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
public struct PlayerInputs
{
    public Vector2 Movement;
    public bool Jump;
    public bool Attack;
    public bool Crouch;
} 

public class PlayerInputController : MonoBehaviour
{
    private PlayerInputs inputs;
    private void Start() {
        inputs = new PlayerInputs();
    }
    public void PlayerMovement(InputAction.CallbackContext _context)
    {
        inputs.Movement = _context.ReadValue<Vector2>();
        Debug.Log(inputs);
    }
    // public void PlayerJump = () => Input.Jump = true;
    // public void PlayerAttack = () => Input.Attack = true;
    // public void PlayerCrouch = () => Input.Crouch = true;

}
