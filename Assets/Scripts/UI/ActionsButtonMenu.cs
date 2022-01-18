using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsButtonMenu : MonoBehaviour
{
    private RectTransform _transformMenu;
    private SensorSlider _SliderMenu;

    [SerializeField] private Buttons _buttonPrefab;
    private RectTransform _buttonRectTransform;

    [SerializeField] private float _ButtonDistance = 50;

    [System.Serializable]
    public enum TypeButtons
    {
        Video,
        Upgrade,
        Purchase
    }

    [SerializeField] private TypeButtons _typeButtons;

    [SerializeField] private List<VideoButtonObject> _Videos = new List<VideoButtonObject>();
    private List<VideoButton> _VideosButtons = new List<VideoButton>();
    [SerializeField] private List<UpgradeButtonsObject> _Upgrades = new List<UpgradeButtonsObject>();
    private List<UpgradeButton> _UpgradesButtons = new List<UpgradeButton>();
    [SerializeField] private List<PurchaseButtonObject> _Purchases = new List<PurchaseButtonObject>();

    private int sizeList;


    private void Awake()
    {
        _buttonRectTransform = _buttonPrefab.GetComponent<RectTransform>();
        _transformMenu = GetComponent<RectTransform>();
        _SliderMenu = GetComponent<SensorSlider>();
    }

    private void Start()
    {
        SetSizeList();
        CreateButtons();
        _SliderMenu.SetPosition();
    }

    public void CreateButtons()
    {
        _transformMenu.sizeDelta = new Vector2(_transformMenu.sizeDelta.x, _ButtonDistance * 2 + (_buttonRectTransform.sizeDelta.y + _ButtonDistance) * sizeList);
        _transformMenu.anchoredPosition = new Vector2(_transformMenu.anchoredPosition.x, _transformMenu.anchoredPosition.y - _transformMenu.sizeDelta.y / 2);

        for (int i = 0; i < sizeList; i++)
        {
            Vector2 position = new Vector2(_buttonRectTransform.anchoredPosition.x, (_transformMenu.sizeDelta.y / 2) - (_buttonRectTransform.sizeDelta.y / 2 + _ButtonDistance) - (_buttonRectTransform.sizeDelta.y + _ButtonDistance) * i);
            GameObject button = Instantiate(_buttonPrefab.gameObject, transform);
            button.GetComponent<RectTransform>().anchoredPosition = position;
            SelectList(button, i);
        }
    }

    private void SetSizeList()
    {
        switch (_typeButtons)
        {
            case TypeButtons.Video:
                sizeList = _Videos.Count;
                break;

            case TypeButtons.Upgrade:
                sizeList = _Upgrades.Count;
                break;

            case TypeButtons.Purchase:
                sizeList = _Purchases.Count;
                break;
        }
    }
    private void SelectList(GameObject button, int num)
    {
        switch (_typeButtons)
        {
            case TypeButtons.Video:
                _VideosButtons.Add(button.GetComponent<VideoButton>());
                _VideosButtons[num].SetObject(_Videos[num]);
                break;

            case TypeButtons.Upgrade:
                _UpgradesButtons.Add(button.GetComponent<UpgradeButton>());
                _UpgradesButtons[num].SetObject(_Upgrades[num]);
                break;

            case TypeButtons.Purchase:
                button.GetComponent<PurchaseButton>().SetObject(_Purchases[num]);
                break;
        }
    }

    public void UpdateIsActiveButtons()
    {
        switch (_typeButtons)
        {
            case TypeButtons.Video:
                foreach (VideoButton button in _VideosButtons)
                {
                    button.CheckPurchaseConditions();
                }
                break;

            case TypeButtons.Upgrade:
                foreach (UpgradeButton button in _UpgradesButtons)
                {
                    button.CheckPurchaseConditions();
                }
                break;
        }
    }
}
