using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchasableObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectLevels;
    [SerializeField] private bool isLevable;
    public int Level { get; private set; }


    private void Start()
    {
        ChangeLevelObject(Level);
    }

    public void ChangeLevelObject(int level)
    {
        if (isLevable)
            UpdateLevableObject(level);
        else
            ActiveSomeObject(level);
    }

    private void UpdateLevableObject(int level)
    {
        foreach(GameObject obj in _objectLevels)
            obj.SetActive(false);

        Level = level;
        if(level > 0)
        {
            _objectLevels[level - 1].SetActive(true);
        }
    }
    private void ActiveSomeObject(int level)
    {
        foreach (GameObject obj in _objectLevels)
            obj.SetActive(false);

        Level = level;
        for (int i = 0; i < Level; i++)
        {
            _objectLevels[i].SetActive(true);
        }
    }
}
