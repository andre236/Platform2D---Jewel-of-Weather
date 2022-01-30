using UnityEngine;
using Manager;

namespace Player
{

    [RequireComponent(typeof(Controller2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _velocity = 48f;
        private float _horizontalMovement;

        private bool _isJumping;

        private SpriteRenderer _currentSpritePlayer;
        private Animator _playerAnim;
        private Controller2D _control;

        private void Awake()
        {
            _control = GetComponent<Controller2D>();
            _playerAnim = GetComponent<Animator>();
            _currentSpritePlayer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            CommandsPlayer();
        }

        private void FixedUpdate()
        {
            _control.Movement(_horizontalMovement * Time.fixedDeltaTime, _isJumping);
            _isJumping = false;
        }

        public void TradePositionPlayer(Vector2 firepitPos)
        {
            transform.position = new Vector2(firepitPos.x, firepitPos.y);
        }

        void CommandsPlayer()
        {
            var JumpWithSpace = Input.GetKeyDown(KeyCode.Space);
            _horizontalMovement = Input.GetAxisRaw("Horizontal") * _velocity;
            _playerAnim.SetBool("IsJumping", !_control.OnGround);

            if (Input.GetButtonDown("Jump") || JumpWithSpace)
            {  
                _isJumping = true;
                AudioManager.Instance.PlaySoundEffect(0);
            }

            if (_horizontalMovement < 0)
            {
                _playerAnim.SetBool("IsRunning", true);
                _currentSpritePlayer.flipX = true;

            }
            else if (_horizontalMovement > 0)
            {
                _playerAnim.SetBool("IsRunning", true);
                _currentSpritePlayer.flipX = false;
            }
            else if (_horizontalMovement == 0)
            {
                _playerAnim.SetBool("IsRunning", false);
            }



        }

    }
}