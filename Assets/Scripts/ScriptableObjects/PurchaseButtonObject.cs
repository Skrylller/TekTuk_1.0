using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PurchaseButtonData", menuName = "SciptableObjects/Buttons/PurchaseButtonObject")]
public class PurchaseButtonObject : ButtonObject
{
    [SerializeField] private string[] _visualName;
    [SerializeField] private int[] _costs;

    public string[] VisualName { get { return _visualName; } }
    public int[] Costs { get { return _costs; } }

    public bool isUnlock = true;
}
