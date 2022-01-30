using System.Collections;
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

            if (Input.GetKeyDown(KeyCode.Z))
            {
                _control.StartCoroutine("TransitionDayAndNight");
                GameManager.Instance.ChangeDayCycle();
                if (GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Day)
                {
                    _playerAnim.SetBool("IsDay", true);
                    _playerAnim.Play("Player_Idle_Day");
                }
                else
                {
                    _playerAnim.SetBool("IsDay", false);
                    _playerAnim.Play("Player_Idle");
                }
            }

        }



    }
}