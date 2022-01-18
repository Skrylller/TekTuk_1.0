using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonObject : ButtonObject
{
    [System.Serializable]
    public class NeedPurchase
    {
        public string _NeedPurchase;
    }

    [Header("Action")]
    [SerializeField] private NeedPurchase[] _needPurchases = new NeedPurchase[0];

    [SerializeField] private int _NeedSubscribers;
    [Range(0f, 1f)]
    [SerializeField] private float _NeedLoyalty;

    [Range(0.1f, 2f)]
    [SerializeField] private float _LoyaltyCoefficient;

    [SerializeField] private int _GetMoney;
    [SerializeField] private int _GetSubscribers;

    public bool isUnlock;


    public NeedPurchase[] NeedPurchases { get { return _needPurchases; } }
    public int NeedSubscribers { get { return _NeedSubscribers; } }
    public float NeedLoyalty { get { return _NeedLoyalty; } }

    public float LoyaltyCoefficient { get { return _LoyaltyCoefficient; } }

    public int GetMoney { get { return _GetMoney; } }
    public int GetSubscribers { get { return _GetSubscribers; } }
}
