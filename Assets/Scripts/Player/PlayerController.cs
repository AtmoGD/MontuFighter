using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerInputController))]
public class PlayerController : StateMachine, Attackable
{
#if UNITY_EDITOR
    [Header("Debugging")]
    [SerializeField] private bool drawGizmos = false;
#endif

    [Header("Data")]
    [SerializeField] protected PlayerData data;
    [SerializeField] protected SkillData skillData;
    [SerializeField] protected EffectLib effectLib;

    [Header("References")]
    [SerializeField] protected PlayerInputController inputController;
    [SerializeField] protected GameObject groundedObject;

    [Header("Variables")]
    [SerializeField] protected int groundedLayer = 6;
    [SerializeField] protected float groundedDistance = 0.05f;
    [SerializeField] protected PlayerSkill attackSkill;
    [SerializeField] protected PlayerSkill supportSkill;

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

        HealthLeft = data.maxHealth;

        SetState(new PlayerIdleState());
    }

    public new void Update()
    {
        Inputs = inputController.Inputs;
        inputController.UseInputs();

        base.Update();
    }

    public GameObject InstantiateObject(GameObject _prefab, Vector3 _position, Quaternion _rotation)
    {
        return Instantiate(_prefab, _position, _rotation);
    }

    public GameObject InstantiateObject(GameObject _prefab, Transform _parent)
    {
        return Instantiate(_prefab, _parent);
    }

    public void DestroyObject(GameObject _object)
    {
        Destroy(_object);
    }

    public Damage GetDamage(int _damage, float _stunTime)
    {
        return new Damage(this, _damage, _stunTime);
    }

    public void TakeDamage(Damage _damage)
    {
        (State as PlayerState).TakeDamage(_damage);
    }

    public void ChangeHealthLeft(int _amount)
    {
        HealthLeft += _amount;
    }
    public PlayerData GetData() { return data; }
    public SkillData GetSkillData() { return skillData; }
    public EffectLib GetEffectLib() { return effectLib; }
    public PlayerInputController GetInputController() { return inputController; }
    public PlayerSkill GetAttackSkill() { return attackSkill; }
    public PlayerSkill GetSupportSkill() { return supportSkill; }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!drawGizmos) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundedObject.transform.position, groundedDistance);
    }
#endif

}
