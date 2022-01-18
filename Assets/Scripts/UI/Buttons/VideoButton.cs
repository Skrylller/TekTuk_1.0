using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoButton : ActionButtons
{
    public VideoButtonObject videoButtonObject;

    private void Awake()
    {
        if (videoButtonObject != null)
        {
            SetObject(videoButtonObject);
        }
    }

    public override void DownLogic()
    {
        if (videoButtonObject.isUnlock == false)
        {
            Message.TextMessage($"Video is locked");
            return;
        }
        if (ChekcStatConditions() == false)
            return;

        Stats.main.NewVideo(this);
    }

    public void SetObject(VideoButtonObject value)
    {
        videoButtonObject = value;

        buttonObject = value;

        Inicializate();
        CheckPurchaseConditions();
    }
}
