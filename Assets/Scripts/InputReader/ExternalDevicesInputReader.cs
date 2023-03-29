using UnityEngine;
using UnityEngine.EventSystems;
using Player;
using InputReader;
using Core.Services.Updater;
using System;

public class ExternalDevicesInputReader : IEntityInputSource, IDisposable
{

    public float Direction => Input.GetAxisRaw("Horizontal");

    public bool Jump    { get; private set; }
    public bool Attack { get; private set; }

    public ExternalDevicesInputReader()
    {
        ProjectUpdater.Instance.UpdateCalled += OnUpdate;
    }

    public void ResetOneTimeActions()
    {
        Jump = false;
        Attack = false;
    }

    public void Dispose() => ProjectUpdater.Instance.UpdateCalled -= OnUpdate;

    private void OnUpdate()
    {

        if (Input.GetKeyDown(KeyCode.C))
            Jump = true;

        if (!IsPointerOverUi() && Input.GetButtonDown("Fire1"))
            Attack = true;
    }
    private bool IsPointerOverUi() => EventSystem.current.IsPointerOverGameObject();

}
