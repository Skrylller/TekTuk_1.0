using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PurchasableObjectPull : MonoBehaviour
{
    public static PurchasableObjectPull main;

    [System.Serializable]
    private class PurchasableObjectOnScene
    {
        public string _nameObject;
        public PurchasableObject _purchasableObject;
    }

    [SerializeField] private List<PurchasableObjectOnScene> _purchasableObjectsList = new List<PurchasableObjectOnScene>();

    private void Awake()
    {
        main = this;
    }

    public PurchasableObject FindPurchasableObject(string name)
    {
        var purchasableObject = _purchasableObjectsList.Where(x => x._nameObject == name).ToList();
        if (purchasableObject.Count > 0)
        {
            if (purchasableObject.Count > 1)
                Debug.Log($"Find more {name} purchasable object Count:{purchasableObject.Count}");

            return purchasableObject[0]._purchasableObject;
        }
        else
        {
            Debug.Log($"Dont find {name} purchasable object Count:{purchasableObject.Count}");
            return new PurchasableObject();
        }
    }
}
