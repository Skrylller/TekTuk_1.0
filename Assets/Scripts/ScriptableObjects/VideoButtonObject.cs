using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VideoButtonData", menuName = "SciptableObjects/Buttons/VideoButtonObject")]
public class VideoButtonObject : ActionButtonObject
{
    [Header("Video")]
    [SerializeField] private int _viwesPotential;

    [Range(0f, 1f)]
    [SerializeField] private float _viwesPotentialCoefficient;
    [Range(0f, 1f)]
    [SerializeField] private float _newSubscribersCoefficient;
    [Range(0f, 1f)]
    [SerializeField] private float _oldViwesCoefficient;

    public int ViwesPotential { get { return _viwesPotential; } }

    public float ViwesPotentialCoefficient { get { return _viwesPotentialCoefficient; } }
    public float NewSubscribersCoefficient { get { return _newSubscribersCoefficient; } }
    public float OldViwesCoefficient { get { return _oldViwesCoefficient; } }
}
