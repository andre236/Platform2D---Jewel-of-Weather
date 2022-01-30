using System.Collections;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
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

        public bool OnGround { get; private set; }

        private void Awake()
        {
            _playerRB = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            CheckOnTheGround();

        }

        void CheckOnTheGround()
        {
            OnGround = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(_footPosition.position, _radiusToGround, _groundLayer);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    OnGround = true;
            }
        }

        private void ApplyMovement(float amountMovement)
        {
            var velocityPlayer = new Vector2(amountMovement * 10, _playerRB.velocity.y);

            Vector2 velocity = Vector2.zero;
            _playerRB.velocity = Vector2.SmoothDamp(_playerRB.velocity, velocityPlayer, ref velocity, _smoothMovement);
        }

        public void Movement(float amountMovement, bool isJumping)
        {
            if (OnGround || _airControl)
            {
                ApplyMovement(amountMovement);
            }

            if (OnGround && isJumping)
            {
                OnGround = false;
                _playerRB.AddForce(new Vector2(_playerRB.position.x, _jumpForce));
            }
        }


        public IEnumerator TransitionDayAndNight()
        {
            _playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(1f);
            _playerRB.constraints = RigidbodyConstraints2D.None;
            _playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }
}