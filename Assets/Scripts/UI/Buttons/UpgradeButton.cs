using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : ActionButtons
{
    public UpgradeButtonsObject upgradeButtonsObject;

    private void Awake()
    {
        if (upgradeButtonsObject != null)
        {
            SetObject(upgradeButtonsObject);
        }
    }

    public override void DownLogic()
    {
        if (upgradeButtonsObject.isUnlock == false)
        {
            Message.TextMessage($"Upgrade is locked");
            return;
        }
        if (ChekcStatConditions() == false)
            return;

        Stats.main.NewUpdate(this);
    }

    public void SetObject(UpgradeButtonsObject value)
    {
        upgradeButtonsObject = value;
        buttonObject = upgradeButtonsObject;
        Inicializate();
        CheckPurchaseConditions();
    }
}
