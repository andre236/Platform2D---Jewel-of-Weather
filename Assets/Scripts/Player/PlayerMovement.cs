using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Manager;

namespace Player
{

    [RequireComponent(typeof(Controller2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private float _movementSpeed = 40f;
        private float _horizontalMovement = 0f;

        private bool _jump;

        private SpriteRenderer _currentSpritePlayer;
        private Animator _playerAnim;
        [SerializeField]
        private RuntimeAnimatorController _playerDayController;
        [SerializeField]
        private RuntimeAnimatorController _playerNightController;

        private Controller2D _controller2D;
        private DataPlayer _dataPlayer;

        private void Awake()
        {
            _controller2D = GetComponent<Controller2D>();
            _playerAnim = GetComponent<Animator>();
            _currentSpritePlayer = GetComponent<SpriteRenderer>();
            _dataPlayer = GetComponent<DataPlayer>();
        }

        private void Update()
        {
            CommandsPlayer();
            ChangeAnimation();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        void MovePlayer()
        {
            _controller2D.Movement(_horizontalMovement * Time.fixedDeltaTime, _jump);
            _jump = false;
        }

        void ChangeAnimation()
        {
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


        void CommandsPlayer()
        {
            _horizontalMovement = Input.GetAxisRaw("Horizontal") * _movementSpeed;
            _playerAnim.SetBool("IsJumping", !_controller2D.IsOnGround);

            if (Input.GetKeyDown(KeyCode.X))
            {
                _jump = true;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (Input.GetKeyDown(KeyCode.Z) && _dataPlayer.JewelAmount > 0)
            {
                StartCoroutine(_controller2D.FreezeRigidbody());
                _dataPlayer.DecrementJewel();
                GameManager.Instance.ChangeDayCycle();
                if (GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Day)
                {
                    _playerAnim.runtimeAnimatorController = _playerDayController;
                }
                else
                {
                    _playerAnim.runtimeAnimatorController = _playerNightController;
                }
            }


        }


    }
}