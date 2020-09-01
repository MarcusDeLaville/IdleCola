using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsPerTapItem : ShopItemBase
{
    public SoundEvents _soundEvents;
    public Caps _caps;

    private void Start()
    {
        _soundEvents = FindObjectOfType<SoundEvents>();
        _caps = FindObjectOfType<Caps>();

        if (PlayerPrefs.HasKey(_name))
        {
            _level = PlayerPrefs.GetInt(_name);
            _price = _level * (int)(5.5f * _price);
        }

        Draw();
    }

    public override void OnInteract()
    {
        if (_caps.GetCaps() >= _price)
        {
            _soundEvents.PlayAudioClip(_soundEvents._tapSounds[3], _soundEvents._audioSourceTaps);
            _caps.DepriveCaps(_price);
            _caps.AddCapsPerTap(_growrh);
            _price = (int)(_price * 5.5f);
            _level++;
            Draw();
            PlayerPrefs.SetInt(_name, _level);
            SaveContUps();
        }
        else
        {
            _soundEvents.PlayAudioClip(_soundEvents._tapSounds[4], _soundEvents._audioSourceTaps);
        }
    }
}
