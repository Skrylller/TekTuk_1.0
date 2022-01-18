using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseButton : Buttons
{
    [Header("Purchase")]
    [SerializeField] private Text _ButtonText;
    [SerializeField] private Text _ButtonAdditionalText;

    private PurchasableObject _purchasbnleObject;
    public PurchaseButtonObject purchaseButton;

    private void Awake()
    {
        if (purchaseButton != null)
        {
            SetObject(purchaseButton);
        }
    }

    public void OnButtonClick()
    {
        SetAnimation(false);
        if (purchaseButton.isUnlock == false)
            return;

        if(Stats.main.MoneyStat.PlusValue(-purchaseButton.Costs[_purchasbnleObject.Level]))
        {
            _purchasbnleObject.ChangeLevelObject(_purchasbnleObject.Level + 1);
            ActionsUI.main.UpdateIsActiveAllButtons();
            if (_purchasbnleObject.Level < purchaseButton.Costs.Length)
            {
                SetText();
            }
            else
            {
                purchaseButton.isUnlock = false;
                SetMaxLevelText();
            }
        }
        else
        {
            Message.TextMessage($"need {purchaseButton.Costs[_purchasbnleObject.Level]} money");
        }
    }

    public override void SetText()
    {
        _ButtonText.text = Translator.TranslateText($"{purchaseButton.Name} Level:{_purchasbnleObject.Level + 1}");
        string aditionalText;
        aditionalText = $"Need {purchaseButton.Costs[_purchasbnleObject.Level]} money. ";
        _ButtonAdditionalText.text = Translator.TranslateText(aditionalText);
    }

    public void SetMaxLevelText()
    {
        _ButtonText.text = Translator.TranslateText($"Level:{_purchasbnleObject.Level} Max");
        _ButtonAdditionalText.text = Translator.TranslateText("");
    }

    public void SetObject(PurchaseButtonObject value)
    {
        purchaseButton = value;

        SetPurchasableObject();
        Inicializate();
        purchaseButton.isUnlock = true;
    }

    public void SetPurchasableObject()
    {
        _purchasbnleObject = PurchasableObjectPull.main.FindPurchasableObject(purchaseButton.Name);
    }
}
