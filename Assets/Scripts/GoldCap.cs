using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCap : MonoBehaviour
{
    private Caps _caps;
    private SoundEvents _soundEvents;
    private bool _isCollected;

    private int _goldCapsCount;

    [SerializeField] private float _fallSpeed = 5;
    [SerializeField] private Animation _animation;

    private void Start()
    {
        _soundEvents = FindObjectOfType<SoundEvents>();
        _isCollected = false;
        _caps = FindObjectOfType<Camera>().GetComponent<Caps>();
        Destroy(gameObject, 7f);
    }

    public void GetReward()
    {   
        if (!_isCollected)
        {
            _soundEvents.PlayAudioClip(_soundEvents._tapSounds[2], _soundEvents._audioSourceEvents);
            _isCollected = true;
            _animation.Play();
            _caps.AddCap(_caps.GetCapsPerTaps() * 200);
            SaveCount();
            Destroy(gameObject, 1f);
        }    
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _fallSpeed * Time.deltaTime);
    }

    private void SaveCount()
    {
        if (!PlayerPrefs.HasKey("GoldCapsCount"))
        {
            _goldCapsCount = 0;
            PlayerPrefs.SetInt("GoldCapsCount", _goldCapsCount);
        }

        _goldCapsCount = PlayerPrefs.GetInt("GoldCapsCount");
        _goldCapsCount++;
        PlayerPrefs.SetInt("GoldCapsCount", _goldCapsCount);
    }
}
