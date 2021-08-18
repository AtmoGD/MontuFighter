using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArenaObjectData", menuName = "ArenaObjectData/ArenaObjectData", order = 1)]
public class ArenaObjectData : ScriptableObject
{
    [SerializeField] public string getHitAnimName;
    [SerializeField] public string dieAnimName;
    [SerializeField] public float maxHealth;
    [SerializeField] public GameObject hitEffect;
    [SerializeField] public GameObject dieEffect;
}
