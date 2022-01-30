using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private Sprite _jewelNight;
        [SerializeField]
        private Sprite _jewelDay;
        private Image _currentJewelImage;
        private Text _jewelAmount;

        private DataPlayer _dataPlayer;

        void Awake()
        {
            _currentJewelImage = GameObject.Find("JewelAmount").GetComponent<Image>();
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
                _currentJewelImage.sprite = _jewelDay;
            }
            else
            {
                _currentJewelImage.sprite = _jewelNight;
            }

            _jewelAmount.text = "x"+ _dataPlayer.JewelAmount.ToString();
    }
    }
}