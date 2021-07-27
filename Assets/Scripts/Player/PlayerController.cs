using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(PlayerInputController))]
public class PlayerController : StateMachine
{
    [Header("Debugging")]
    [SerializeField] private bool drawGizmos = false;

    [Header("Player Controller References")]
    [SerializeField] public PlayerInputController inputController;
    [SerializeField] public PlayerData data;
    [SerializeField] public GameObject groundedObject;


    [Header("Variables")]
    [SerializeField] public int groundedLayer = 6;
    [SerializeField] public float groundedDistance = 0.05f;
    [SerializeField] public PlayerSkill firstSkill;
    [SerializeField] public PlayerSkill secondSkill;

    public new void Awake()
    {
        base.Awake();

        inputController = GetComponent<PlayerInputController>();
        data = GetComponent<PlayerData>();

        SetState(new PlayerIdleState());
    }

    public new void Update()
    {
        Inputs = inputController.Inputs;
        inputController.UseInputs();
        
        base.Update();
    }

    public new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public bool IsGrounded()
    {
        return Physics.SphereCast(groundedObject.transform.position, groundedDistance, Vector3.down, out RaycastHit _hit, groundedDistance, 1 << groundedLayer);
    }

    public State GetNewSkillState(bool _first)
    {
        switch (_first ? firstSkill : secondSkill)
        {
            case PlayerSkill.Dash:
                return new PlayerDashState();
            default:
                return new PlayerIdleState();
        }
    }

    private void OnDrawGizmos()
    {
        if (!drawGizmos) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundedObject.transform.position, groundedDistance);
    }

}
