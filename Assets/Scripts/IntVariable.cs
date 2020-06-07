using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Variables/Int Variable")]
[Serializable]
public class IntVariable : ScriptableObject
{
    public int Value;
    public bool ResetOnStart;

    public void SetValue(int value)
    {
        Value = value;
    }

    public void SetValue(IntVariable value)
    {
        Value = value.Value;
    }

    public void ApplyChange(int amount)
    {
        Value += amount;
    }

    public void ApplyChange(IntVariable amount)
    {
        Value += amount.Value;
    }

}
