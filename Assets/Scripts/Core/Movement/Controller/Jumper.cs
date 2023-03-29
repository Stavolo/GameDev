using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Movement.Data;
using System.Security.Cryptography;

namespace Core.Movement.Controller
{
    public class Jumper : MonoBehaviour
    {
        private readonly JumpData _jumpData;
        private readonly Rigidbody2D _rigidbody;
        private readonly Collider2D _collider;
        private readonly Transform _transform;

        private float _startJumpVerticalPos;

        public bool IsJumping { get;  set; }
        public bool IsGrounded { get; private set; }

        public Jumper(Rigidbody2D rigidbody2D,Collider2D collider2D, JumpData jumpData)
        {
            _rigidbody = rigidbody2D;
            _collider = collider2D;
            _jumpData = jumpData;
            _transform = _rigidbody.transform;
        }

        public void Jump()
        {
            if (IsJumping)
                return;

            IsJumping = true;
            _startJumpVerticalPos = _rigidbody.position.y;
            _rigidbody.AddForce(Vector2.up * _jumpData.JumpForce);
        }

        public void UpdateJump()
        {
            if (_rigidbody.velocity.y < 0 && _transform.position.y < _startJumpVerticalPos)
            {
                ResetJump();
                return;
            }

        }
        private void ResetJump()
        {
            _transform.position = new Vector2(_transform.position.x, _startJumpVerticalPos);
            IsJumping = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ground"))
            {
                IsGrounded = true;
                IsJumping = false;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ground"))
            {
                IsGrounded = false;
            }
        }
    }
}