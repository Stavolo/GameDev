using UnityEngine;
using Player;
using System.Runtime.CompilerServices;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private float _direction;

    private void Update()
    {
        _direction = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.C))
        {
            _playerMovement.Jump();
        }
    }

    private void FixedUpdate()
    {
        _playerMovement.MoveHorizontally(_direction);
    }

}
