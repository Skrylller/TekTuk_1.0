using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultButtons : Buttons
{
    [SerializeField] private bool isHaveText = true;

    [SerializeField] private string _name;
    [SerializeField] private Text _ButtonText;
    private void Awake()
    {
        Inicializate();
    }

    public override void SetText()
    {
        if (isHaveText)
        {
            _ButtonText.text = Translator.TranslateText(_name);
        }
    }

}
