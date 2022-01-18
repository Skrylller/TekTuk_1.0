using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name { get { return _name; } }
}
