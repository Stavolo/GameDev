using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private bool _faceRight;

        [Header("Jump")]
        [SerializeField] private float _jumpForce;

        private Rigidbody2D _rigidbody;
        private Collider2D _collider;

        //private bool _isGrounded;
        private bool _isJumping = false;
        private float _startJumpVerticalPosition;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }
        private void Update()
        {
            if (_isJumping)
            {
                UpdateJump();
            }

        }
        public void MoveHorizontally(float direction)
        {
            SetDirection(direction);
            Vector2 velocity = _rigidbody.velocity;
            velocity.x = direction * _horizontalSpeed;
            _rigidbody.velocity = velocity;
        }

        public void Jump()
        {
            //if(_isJumping && !_isGrounded) return;
            //_isGrounded = false;
            if (_isJumping)
                return;

            _isJumping = true;
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _startJumpVerticalPosition = transform.position.y;
        }

        private void SetDirection(float direction)
        {
            if (_faceRight && direction < 0 || !_faceRight && direction > 0)
            {
                Flip();
            }
        }
        private void Flip()
        {
            transform.Rotate(0, 180, 0);
            _faceRight = !_faceRight;
        }
        private void UpdateJump()
        {
            if (_rigidbody.velocity.y < 0 && _rigidbody.position.y <= _startJumpVerticalPosition)
            {
                ResetJump();
                return;
            }
        }

        private void ResetJump()
        {
            _isJumping = false;
            _rigidbody.position = new Vector2(_rigidbody.position.x, _startJumpVerticalPosition);
        }
        /*private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ground"))
            {
                _isGrounded = true;
                _isJumping = false;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ground"))
            {
                _isGrounded = false;
            }
        }*/
    }
}
