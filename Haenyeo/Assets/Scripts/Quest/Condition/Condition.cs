using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : ScriptableObject
{
    [SerializeField]
    string description;
    public abstract bool IsPass(Quest_ quest);
}
