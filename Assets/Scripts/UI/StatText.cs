using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class StatText : MonoBehaviour
{
    private Text _textStat;

    [SerializeField] private string _nameStat;
    private string _translateNameStat;

    [SerializeField] private bool _isTwoString;

    public void Awake()
    {
        _textStat = GetComponent<Text>();
        _translateNameStat = Translator.TranslateText(_nameStat);
    }

    public void UpdateText(int statValue)
    {
        if(_isTwoString)
            _textStat.text = $"{_translateNameStat}:\n{statValue}";
        else
            _textStat.text = $"{_translateNameStat}: {statValue}";
    }
}
