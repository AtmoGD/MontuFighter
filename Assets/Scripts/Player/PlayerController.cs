using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(PlayerInputController))]
public class PlayerController : StateMachine, Attackable
{
    [Header("Debugging")]
    [SerializeField] private bool drawGizmos = false;


    [Header("Player Controller References")]
    [SerializeField] protected PlayerInputController inputController;
    [SerializeField] protected PlayerData data;
    [SerializeField] protected SkillData skillData;
    [SerializeField] protected GameObject groundedObject;


    [Header("Variables")]
    [SerializeField] protected int groundedLayer = 6;
    [SerializeField] protected float groundedDistance = 0.05f;
    [SerializeField] protected PlayerSkill firstSkill;
    [SerializeField] protected PlayerSkill secondSkill;


    public int HealthLeft { get; private set; }
    public bool IsGrounded
    {
        get
        {
            return Physics.CheckSphere(groundedObject.transform.position, groundedDistance, 1 << groundedLayer);
        }
    }

    public new void Awake()
    {
        base.Awake();

        inputController = GetComponent<PlayerInputController>();
        data = GetComponent<PlayerData>();

        HealthLeft = data.maxHealth;

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

    public Damage GetDamage(int _damage, float _stunTime)
    {
        return new Damage(this, _damage, _stunTime);
    }

    public void TakeDamage(Damage _damage)
    {
        HealthLeft -= _damage.attackDamage;
        
    }

    public PlayerData GetData() { return data; }
    public SkillData GetSkillData() { return skillData; }
    public PlayerInputController GetInputController() { return inputController; }


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
