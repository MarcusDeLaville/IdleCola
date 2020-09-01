using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsRainEvent : MonoBehaviour
{
    [SerializeField] private GoldCapSpawner _goldCapSpawner;
    [SerializeField] private Caps _caps;
    [SerializeField] private int _limit;
    [SerializeField] private Slider _slider;
    private int _buffer;

    public void OnClick()
    {
        _buffer++ ;
        if(_buffer >= _limit)
        {
            _buffer = 0;
            for (int i = 0; i < 6; i++)
            {
                _goldCapSpawner.SpawnCap();
            }
        }
        _slider.value = _buffer;
    }
}
