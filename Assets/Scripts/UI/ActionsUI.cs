using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsUI : MonoBehaviour
{
    public static ActionsUI main;

    [SerializeField] private ActionsButtonMenu[] Actions;

    private void Awake()
    {
        main = this; 
    }

    private void Start()
    {
        CloseAll();
    }

    public void SelectAction(ActionsButtonMenu selectedAction)
    {

        if (selectedAction.gameObject.activeSelf)
        {
            CloseAll();
            return;
        }

        CloseAll();
        selectedAction.gameObject.SetActive(true);
    }

    public void CloseAll()
    {
        foreach (ActionsButtonMenu action in Actions)
            action.gameObject.SetActive(false);
    }

    public void UpdateIsActiveAllButtons()
    {
        foreach(ActionsButtonMenu actionMenu in Actions)
        {
            actionMenu.UpdateIsActiveButtons();
        }
    }
}
