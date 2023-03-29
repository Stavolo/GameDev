using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Movement.Data
{
    [Serializable]
    public class JumpData
    {
        [field: SerializeField] public float JumpForce { get; private set; }
    }
}