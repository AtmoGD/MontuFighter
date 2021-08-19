using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerInputController))]
public class CharacterController : StateMachine, Attackable
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
    [SerializeField] protected Skill attackSkill;
    [SerializeField] protected Skill supportSkill;
    [SerializeField] protected List<Cooldown> cooldowns = new List<Cooldown>();

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

        cooldowns = new List<Cooldown>();

        SetState(new IdleState());
    }

    public new void Update()
    {
        GetInputs();

        CheckCooldowns();

        base.Update();
    }

    private void GetInputs()
    {
        Inputs = inputController.Inputs;
        inputController.UseInputs();
    }

    public void CheckCooldowns()
    {
        cooldowns.ForEach(c => c.Remove(Time.deltaTime));
        cooldowns.RemoveAll(c => c.left <= 0f);
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

    public void DestroyObjectImmediate(GameObject _object)
    {
        DestroyImmediate(_object);
    }

    public Damage GetDamage(int _damage, float _stunTime)
    {
        return new Damage(this, _damage, _stunTime);
    }

    public void TakeDamage(Damage _damage)
    {
        (State as CharacterState).TakeDamage(_damage);
    }

    public void ChangeHealthLeft(int _amount)
    {
        HealthLeft += _amount;
    }

    public void AddCoolDown(Cooldown _cooldown)
    {
        cooldowns.Add(_cooldown);
    }

    public void RemoveCoolDown(Cooldown _cooldown)
    {
        cooldowns.Remove(_cooldown);
    }

    public bool HasCoolDown(string _cooldown) {
        foreach (Cooldown cooldown in cooldowns)
        {
            if (cooldown.name == _cooldown)
                return true;
        }
        return false;
    }

    public PlayerData GetData() { return data; }
    public SkillData GetSkillData() { return skillData; }
    public EffectLib GetEffectLib() { return effectLib; }
    public PlayerInputController GetInputController() { return inputController; }
    public Skill GetAttackSkill() { return attackSkill; }
    public Skill GetSupportSkill() { return supportSkill; }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!drawGizmos) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundedObject.transform.position, groundedDistance);
    }
#endif

}
