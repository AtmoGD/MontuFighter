using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Effect
{
    public string name;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "EffectLib", menuName = "Data/EffectLib")]
public class EffectLib : ScriptableObject
{
    public List<Effect> effects = new List<Effect>();
}
