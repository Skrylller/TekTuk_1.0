using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorSlider : MonoBehaviour
{
    private RectTransform _panelPosition;
    private Vector2 _newPosition;
    private float _startPosY;
    private float _DownPosY;
    private float _startMousePosY;

    private const float _visibleHeight = 500f;
    private const float _speedMove = 1.5f;
    private const float _speedLerp = 5f;

    [SerializeField] private bool _startSetPosition;

    private void Awake()
    {
        _panelPosition = GetComponent<RectTransform>();
    }

    private void Start()
    {
        if (_startSetPosition)
            SetPosition();
    }

    public void SetPosition()
    {
        _newPosition = _panelPosition.anchoredPosition;
        _startPosY = _panelPosition.anchoredPosition.y;
    }

    private void Update()
    {
        _panelPosition.anchoredPosition = Vector2.Lerp(_panelPosition.anchoredPosition, _newPosition, Time.deltaTime * _speedLerp);
    }

    public void Down()
    {
        _DownPosY = _panelPosition.anchoredPosition.y;
        _startMousePosY = Input.mousePosition.y;
    }

    public void Drag()
    {
        float posY = _DownPosY + (Input.mousePosition.y - _startMousePosY) * _speedMove;

        if (posY < _startPosY)
            posY = _startPosY;

        if (posY > _startPosY + _panelPosition.sizeDelta.y - _visibleHeight)
            posY = _startPosY + _panelPosition.sizeDelta.y - _visibleHeight;

        _newPosition = new Vector2(_newPosition.x, posY);
    }
}
