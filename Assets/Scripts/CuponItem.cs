using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuponItem : ShopItemBase
{
    [SerializeField] private GameObject _codePanel;
    [SerializeField] private PanelCloser _panelCloser;

    public SoundEvents _soundEvents;
    public Caps _caps;

    private void Start()
    {
        _soundEvents = FindObjectOfType<SoundEvents>();
        _caps = FindObjectOfType<Caps>();

        Draw();
    }

    public override void OnInteract()
    {
        if (_caps.GetCaps() >= _price)
        {
            _soundEvents.PlayAudioClip(_soundEvents._tapSounds[3], _soundEvents._audioSourceTaps);
            _caps.DepriveCaps(_price);
            _panelCloser.OpenPanel(_codePanel);
        }
        else
        {
            _soundEvents.PlayAudioClip(_soundEvents._tapSounds[4], _soundEvents._audioSourceTaps);
        }
    }

    
}
