using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
namespace InputReader
{
    public interface IEntityInputSource
    {
         float Direction { get; }

         bool Jump { get; }
         bool Attack { get; }

         void ResetOneTimeActions();
    }
}