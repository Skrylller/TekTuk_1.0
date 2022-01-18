using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static Stats main;

    [System.Serializable]
    public class Stat
    {
        [SerializeField] protected int _statValue = 0;
        [SerializeField] protected int _statMaxValue = 0;
        [SerializeField] protected int _statMinValue = 0;
        [SerializeField] private string _nameStat;
        [SerializeField] private StatText _textStat;

        public void Inicialize()
        {
            UpdateText();
        }

        public bool PlusValue(int value)
        {
            if (value > 0 && _statValue + value > _statMaxValue)
            {
                SetMaxValue();
                return false;
            }
            if(value < 0 && _statValue + value < _statMinValue)
            {
                SetMinValue();
                return false;
            }

            SetValue(_statValue + value);
            return true;
        }

        public int ReturnValue()
        {
            return _statValue;
        }

        protected void SetValue(int value)
        {
            _statValue = value;
            UpdateText();
        }

        protected void UpdateText()
        {
            _textStat.UpdateText(_statValue);
        }

        protected void SetMaxValue()
        {
            SetValue(_statMaxValue);
        }

        protected void SetMinValue()
        {
            SetValue(_statMinValue);
        }
    }

    [System.Serializable]
    public class CurrencyStat : Stat
    {
        protected new void SetMinValue()
        {
            Message.TextMessage($"need more {this}");
        }
    }

    public CurrencyStat MoneyStat;
    public Stat SubscribersStat;
    public Stat ViwesStat;
    public Stat LoyaltyStat;
    public Stat VideosStat;
    public Stat PassiveIncome;

    public void Awake()
    {
        main = this;
    }

    public void Start()
    {
        MoneyStat.Inicialize();
        SubscribersStat.Inicialize();
        ViwesStat.Inicialize();
        LoyaltyStat.Inicialize();
        VideosStat.Inicialize();
        PassiveIncome.Inicialize();
    }

    public void NewVideo(VideoButton video)
    {
        VideosStat.PlusValue(1);

        Action(video);

        int oldViwes = (int)(SubscribersStat.ReturnValue() * (LoyaltyStat.ReturnValue() / 100f) * video.videoButtonObject.OldViwesCoefficient);
        int newViwes = (int)((video.videoButtonObject.ViwesPotential - oldViwes) * 0.3f);

        if (newViwes < video.videoButtonObject.ViwesPotential * video.videoButtonObject.ViwesPotentialCoefficient)
        {
            newViwes = (int)(video.videoButtonObject.ViwesPotential * video.videoButtonObject.ViwesPotentialCoefficient);
        }

        if (newViwes > SubscribersStat.ReturnValue())
        {
            newViwes = SubscribersStat.ReturnValue();
        }

        ViwesStat.PlusValue(oldViwes + newViwes);

        MoneyStat.PlusValue(PassiveIncome.ReturnValue() * (oldViwes + newViwes));

        SubscribersStat.PlusValue((int)(newViwes * video.videoButtonObject.NewSubscribersCoefficient));
    }

    public void NewUpdate(UpgradeButton upgrade)
    {
        PassiveIncome.PlusValue(upgrade.upgradeButtonsObject.GetPassiveIncome);

        Action(upgrade);
    }

    public void Action(ActionButtons action)
    {
        LoyaltyStat.PlusValue((int)(LoyaltyStat.ReturnValue() * (action.buttonObject.LoyaltyCoefficient - 1)));

        SubscribersStat.PlusValue((int)(action.buttonObject.GetSubscribers * (LoyaltyStat.ReturnValue() / 100f)));

        MoneyStat.PlusValue(action.buttonObject.GetMoney);
    }

    public float ValueNoize(float value, float noizeValue)
    {
        float random = Random.Range(-noizeValue, +noizeValue);
        return value * random;
    }
    public float ValueNoize(float value)
    {
        return ValueNoize(value, 0.5f);
    }
}
