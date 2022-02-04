using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ActionButtons : Buttons
{
    [SerializeField] private Text _ButtonText;
    [SerializeField] private Text _ButtonAdditionalText;

    [HideInInspector] public ActionButtonObject buttonObject;

    public void OnButtonClick()
    {
        if (buttonObject.isUnlock)
        {
            DownLogic();
        }
        SetAnimation(false);
    }

    public abstract void DownLogic();

    public void SetObject(ActionButtonObject value)
    {
        buttonObject = value;
    }

    public bool CheckPurchaseConditions()
    {
        foreach (ActionButtonObject.NeedPurchase conditions in buttonObject.NeedPurchases)
        {
            if (PurchasableObjectPull.main.FindPurchasableObject(conditions._NeedPurchase).Level < conditions._NeedPurchasesLevel)
            {
                buttonObject.isUnlock = false;
                SetText();
                return false;
            }
        }
        buttonObject.isUnlock = true;
        SetText();
        return true;
    }

    protected bool ChekcStatConditions()
    {
        if (buttonObject.NeedLoyalty * 100 > Stats.main.LoyaltyStat.ReturnValue() || buttonObject.NeedSubscribers > Stats.main.SubscribersStat.ReturnValue() || -buttonObject.GetMoney > Stats.main.MoneyStat.ReturnValue())
        {
            Message.TextMessage($"You are missing something");
            return false;
        }
        else
        {
            return true;
        }
    }

    public override void SetText()
    {

        if (buttonObject.isUnlock)
            SetTextIfActive();
        else
            SetTextIfDontActive();
    }

    private void SetTextIfActive()
    {
        _ButtonText.text = Translator.TranslateText(buttonObject.Name);

        string aditionalText = "";

        if (buttonObject.GetMoney < 0)
            aditionalText += $"Need {-buttonObject.GetMoney} money. ";
        if (buttonObject.NeedSubscribers > 0)
            aditionalText += $"Need {buttonObject.NeedSubscribers} subscribers. ";
        if (buttonObject.NeedLoyalty > 0)
            aditionalText += $"Need {buttonObject.NeedLoyalty} loyalty. ";
        _ButtonAdditionalText.text = Translator.TranslateText(aditionalText);
    }

    private void SetTextIfDontActive()
    {
        _ButtonText.text = Translator.TranslateText("Unavailable");
        string aditionalText = "Need ";
        foreach (ActionButtonObject.NeedPurchase purchase in buttonObject.NeedPurchases)
        {
            aditionalText += $"{purchase._NeedPurchase}, ";
        }
        _ButtonAdditionalText.text = Translator.TranslateText(aditionalText);
    }
}
