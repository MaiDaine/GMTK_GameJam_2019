﻿using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(menuName = "Variables/FloatVariable")]
    public class FloatVariable : ScriptableObject
    {
        public float value;

        public void SetValue(float value)
        {
            this.value = value;
        }

        public void SetValue(FloatVariable value)
        {
            this.value = value.value;
        }

        public void ApplyChange(float amount)
        {
            value += amount;
        }

        public void ApplyChange(FloatVariable amount)
        {
            value += amount.value;
        }
    }
}