using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Services.Updater
{
    public interface IProjectUpdater
    {
        event Action UpdateCalled;
        event Action FixedUpdateCalled;
        event Action LateUppdateCalled;
    }
}