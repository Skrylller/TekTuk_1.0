using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeButtonData", menuName = "SciptableObjects/Buttons/UpgradeButtonsObject")]
public class UpgradeButtonsObject : ActionButtonObject
{
    [Header("Upgrade")]
    [SerializeField] private int _GetPassiveIncome;
    [SerializeField] private int _GetFixLoyalty;
    public int GetPassiveIncome { get { return _GetPassiveIncome; } }
    public int GetFixLoyalty { get { return _GetFixLoyalty; } }
}
