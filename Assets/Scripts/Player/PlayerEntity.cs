using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using Core.Tools;
using Player.PlayerAnimation;
using System;
using System.Diagnostics;
using Core.Movement.Controller;
using Core.Movement.Data;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private AnimatorController _animator;

        [SerializeField] private HorizontalMovementData _horizontalMovementData;
        [SerializeField] private JumpData _jumpData;
        [SerializeField] private DirectionalCameraPair _cameras;

        private Rigidbody2D _rigidbody;
        private  Collider2D _collider;
        private HorizontalMover _horizontalMover;
        private Jumper _jumper;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
            _horizontalMover = new HorizontalMover(_rigidbody, _horizontalMovementData);
            _jumper = new Jumper(_rigidbody, _collider, _jumpData);
        }
        private void Update()
        {
            UpdateAnimations();
            UpdateCameras();

            if (_jumper.IsGrounded) _jumper.IsJumping = false;
            if (_jumper.IsJumping)
                _jumper.UpdateJump();

        }
        private void UpdateCameras()
        {
            foreach (var cameraPair in _cameras.DirectionalCameras)
                cameraPair.Value.enabled = cameraPair.Key == _horizontalMovementData.Direction;
        }
        private void UpdateAnimations()
        {
            _animator.PlayAnimation(AnimationType.Idle, true);
            _animator.PlayAnimation(AnimationType.Run, _horizontalMover.IsMoving);
            _animator.PlayAnimation(AnimationType.Jump, _jumper.IsJumping);

        }


        public void MoveHorizontally(float direction) => _horizontalMover.MoveHorizontally(direction);

        public void Jump() => _jumper.Jump();

        public void StartAttack()
        {
            if (_animator.PlayAnimation(AnimationType.Attack, true))
                return;
            _animator.ActionRequested += Attack;
            _animator.AnimationEnded += EndAttack;
        }


        private void Attack()
        {

        }
        private void EndAttack()
        {
            _animator.ActionRequested -= Attack;
            _animator.AnimationEnded -= EndAttack;
            _animator.PlayAnimation(AnimationType.Attack, false);
        }
    }
}
