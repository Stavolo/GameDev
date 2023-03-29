using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Enums;
using Core.Movement.Controller;
namespace Core.Movement.Data
{
    [Serializable]
    public class HorizontalMovementData
    {
        [field: SerializeField] public float HorizontalSpeed { get; private set; }
        [field: SerializeField] public Direction Direction { get; private set; }


    }
}
