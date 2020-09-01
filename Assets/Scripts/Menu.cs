using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Image _soundImage;
    [SerializeField] private Sprite _soundOff;
    [SerializeField] private Sprite _soundOn;

    [SerializeField] private AudioSource[] _audioSources;

    private bool _isInclude;

    public void OpenSite()
    {
        Application.OpenURL("https://ru.coca-colahellenic.com/");
    }

    public void SwitchSound()
    {
        _isInclude = !_isInclude;
        if(_isInclude == true)
        {
            for(int i = 0; i < _audioSources.Length; i++)
            {
                _audioSources[i].volume = 0;
            }
            _soundImage.sprite = _soundOn;
        }
        else
        {
            for (int i = 0; i < _audioSources.Length; i++)
            {
                _audioSources[i].volume = 1;
            }
            _soundImage.sprite = _soundOff;
        }

    }
}
