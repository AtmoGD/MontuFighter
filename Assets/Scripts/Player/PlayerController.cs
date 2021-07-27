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

    public void Move()
    {
        Vector3 lookAtPos = transform.position;
        lookAtPos.x += Inputs.Movement.x;
        lookAtPos.z += Inputs.Movement.y;
        transform.LookAt(lookAtPos);

        Vector3 newPos = transform.position + transform.forward * data.speed;
        rb.MovePosition(newPos);
    }

    public void Jump()
    {
        Vector3 velocity = rb.velocity;
        velocity.y = data.jumpForce;
        rb.velocity = velocity;
    }
    
    public bool IsGrounded()
    {
        return Physics.SphereCast(groundedObject.transform.position, groundedDistance, Vector3.down, out RaycastHit _hit, groundedDistance, 1 << groundedLayer);
    }

    private void OnDrawGizmos()
    {
        if (!drawGizmos) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundedObject.transform.position, groundedDistance);
    }
}
