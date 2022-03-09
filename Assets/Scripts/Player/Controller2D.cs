using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Controller2D : MonoBehaviour
    {
        [SerializeField]
        private float _jumpForce = 700f;
        private float _smoothMovement = 0.05f;
        private float _radiusToGround = 0.3f;

        private bool _airControl = true;

        [SerializeField]
        private LayerMask _groundLayer;
        [SerializeField]
        private Transform _footPosition;
        private Rigidbody2D _playerRB;
        public bool IsOnGround { get; private set; }

        private void Awake()
        {
            _playerRB = GetComponent<Rigidbody2D>();
            StartCoroutine(FreezeRigidbody());
        }

        private void FixedUpdate()
        {
            CheckOnTheGround();

        }

        public void CheckOnTheGround()
        {
            IsOnGround = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(_footPosition.position, _radiusToGround, _groundLayer);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    IsOnGround = true;
            }
        }

        public void Movement(float amountMovement, bool isJumping)
        {
            if (IsOnGround || _airControl)
            {
                ApplyMovement(amountMovement);
            }

            if (IsOnGround && isJumping)
            {
                IsOnGround = false;
                _playerRB.AddForce(new Vector2(_playerRB.position.x, _jumpForce));
            }
        }

        private void ApplyMovement(float amountMovement)
        {
            var velocityPlayer = new Vector2(amountMovement * 10, _playerRB.velocity.y);

            Vector2 velocity = Vector2.zero;
            _playerRB.velocity = Vector2.SmoothDamp(_playerRB.velocity, velocityPlayer, ref velocity, _smoothMovement);
        }

        public IEnumerator FreezeRigidbody()
        {
            _playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(2f);
            _playerRB.constraints = RigidbodyConstraints2D.None;
            _playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}