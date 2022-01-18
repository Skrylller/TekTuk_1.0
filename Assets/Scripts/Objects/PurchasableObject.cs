using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchasableObject : MonoBehaviour
{
    private Image _objectImage;
    [SerializeField] private Image[] _objectImageLevels;
    public int Level { get; private set; }

    private void Awake()
    {
        _objectImage = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        ChangeLevelObject(Level);
    }

    public void ChangeLevelObject(int level)
    {
        Level = level;
        if(level > 0)
        {
            _objectImage.gameObject.SetActive(true);
            _objectImage = _objectImageLevels[level - 1];
        }
        else
        {
            _objectImage.gameObject.SetActive(false);
        }
    }
}
