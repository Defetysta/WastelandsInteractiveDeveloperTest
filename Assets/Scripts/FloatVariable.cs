﻿using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Variables/Float variable")]
public class FloatVariable : ScriptableObject
{
    public float Value;
    public bool ResetOnStart;

    public void SetValue(float value)
    {
        Value = value;
    }

    public void SetValue(FloatVariable value)
    {
        Value = value.Value;
    }

    public void ApplyChange(float amount)
    {
        Value += amount;
    }

    public void ApplyChange(FloatVariable amount)
    {
        Value += amount.Value;
    }

}
