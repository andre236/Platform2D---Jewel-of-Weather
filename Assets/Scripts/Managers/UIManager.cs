using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private Sprite _jewelNightSprite;
        [SerializeField]
        private Sprite _jewelDaySprite;
        [SerializeField]
        private Sprite _keyNightSprite;
        [SerializeField]
        private Sprite _keyDaySprite;

        private Image _currentJewelImage;
        private Image _currentKeyImage;
        private Text _jewelAmount;

        private DataPlayer _dataPlayer;

        void Awake()
        {
            _currentJewelImage = GameObject.Find("JewelAmountUI").GetComponent<Image>();
            _currentKeyImage = GameObject.Find("KeyUI").GetComponent<Image>();
            _jewelAmount = GameObject.Find("JewelAmountTXT").GetComponent<Text>();
            _dataPlayer = FindObjectOfType<DataPlayer>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateUI();
        }

        public void UpdateUI()
        {
            if (GameManager.Instance.CurrentCycle == GameManager.DayNightCycle.Day)
            {
                _currentJewelImage.sprite = _jewelDaySprite;
                _currentKeyImage.sprite = _keyDaySprite;
            }
            else
            {
                _currentJewelImage.sprite = _jewelNightSprite;
                _currentKeyImage.sprite = _keyNightSprite;
            }

            _jewelAmount.text = "x" + _dataPlayer.JewelAmount.ToString();

            if (_dataPlayer.HaveKey)
            {
                _currentKeyImage.gameObject.SetActive(true);
            }
            else
            {
                _currentKeyImage.gameObject.SetActive(false);
            }
        }
    }
}