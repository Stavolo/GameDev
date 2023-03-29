using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    public interface IEntityInputSource
    {
         float Direction { get; }

         bool Jump { get; }
         bool Attack { get; }

         void ResetOneTimeActions();
    }
}