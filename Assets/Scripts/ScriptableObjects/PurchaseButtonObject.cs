using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PurchaseButtonData", menuName = "SciptableObjects/Buttons/PurchaseButtonObject")]
public class PurchaseButtonObject : ButtonObject
{
    [SerializeField] private int[] _costs;

    public int[] Costs { get { return _costs; } }

    public bool isUnlock = true;
}
