using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerInputController : MonoBehaviour
{
    public CharacterInputs Inputs { get; private set; }

    private void Awake()
    {
        Inputs = new CharacterInputs();
    }

    private void FixedUpdate() { }

    public void PlayerMovement(InputAction.CallbackContext _context)
    {
        Inputs.Movement = _context.ReadValue<Vector2>();
    }

    public void PlayerLook(InputAction.CallbackContext _context)
    {
        Inputs.Look = _context.ReadValue<Vector2>();
    }

    public void MousePosion(InputAction.CallbackContext _context)
    {
        Inputs.MousePosion = _context.ReadValue<Vector2>();
    }

    public void PlayerJump(InputAction.CallbackContext _context)
    {
        if (_context.phase != InputActionPhase.Canceled)
            Inputs.Jump = _context.phase == InputActionPhase.Performed;
    }

    public void PlayerAttackSkill(InputAction.CallbackContext _context)
    {
        // if (_context.phase != InputActionPhase.Canceled)
        Inputs.AttackSkill = _context.phase == InputActionPhase.Performed;
    }

    public void PlayerSupportSkill(InputAction.CallbackContext _context)
    {
        // if (_context.phase != InputActionPhase.Canceled)
        Inputs.SupportSkill = _context.phase == InputActionPhase.Performed;
    }

    public void PlayerSideSkill(InputAction.CallbackContext _context)
    {
        // if (_context.phase != InputActionPhase.Canceled)
        Inputs.SideSkill = _context.phase == InputActionPhase.Performed;
    }

    public void UseInputs()
    {
        CharacterInputs newInputs = new CharacterInputs();
        newInputs.Movement = Inputs.Movement;
        Inputs = newInputs;
    }
}
