using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerInputController : MonoBehaviour
{
    public PlayerInputs Inputs { get; private set; }

    private void Awake()
    {
        Inputs = new PlayerInputs();
    }

    private void FixedUpdate() { }

    public void PlayerMovement(InputAction.CallbackContext _context)
    {
        Inputs.Movement = _context.ReadValue<Vector2>();
    }

    public void PlayerJump(InputAction.CallbackContext _context)
    {
        Inputs.Jump = _context.phase == InputActionPhase.Performed;
    }

    public void PlayerAttackSkill(InputAction.CallbackContext _context)
    {
        Inputs.AttackSkill = _context.phase == InputActionPhase.Performed;
    }

    public void PlayerSupportSkill(InputAction.CallbackContext _context)
    {
        Inputs.SupportSkill = _context.phase == InputActionPhase.Performed;
    }

    public void UseInputs()
    {
        PlayerInputs newInputs = new PlayerInputs();
        newInputs.Movement = Inputs.Movement;
        Inputs = newInputs;
    }
}
