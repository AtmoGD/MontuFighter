using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public abstract class StateMachine : MonoBehaviour
{
    [Header("State Machine Referenzes")]
    [SerializeField] public Animator animator;
    [SerializeField] public Rigidbody rb;
    public State State { get; private set; }
    public PlayerInputs Inputs { get; protected set; }

    public void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Inputs = new PlayerInputs();
    }

    public void SetState(State _state)
    {
        if (State != null)
            State.Exit();

        State = _state;
        State.Enter(this);
    }

    public void Update()
    {
        State.UpdateFrame();
    }

    public void FixedUpdate()
    {
        State.UpdatePhysics();
    }

    public void OnCollisionEnter(Collision _collision)
    {
        State.OnCollisionEnter(_collision);
    }

    public void OnCollisionStay(Collision _collision)
    {
        State.OnCollisionStay(_collision);
    }

    public void OnCollisionExit(Collision _collision)
    {
        State.OnCollisionExit(_collision);
    }

    public void OnTriggerEnter(Collider _collider)
    {
        State.OnTriggerEnter(_collider);
    }

    public void OnTriggerStay(Collider _collider)
    {
        State.OnTriggerStay(_collider);
    }

    public void OnTriggerExit(Collider _collider)
    {
        State.OnTriggerExit(_collider);
    }

}
