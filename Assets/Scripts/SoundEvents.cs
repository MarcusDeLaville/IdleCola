using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvents : MonoBehaviour
{
    [SerializeField] internal AudioSource _audioSourceTaps;
    [SerializeField] internal AudioSource _audioSourceEvents;
    [SerializeField] internal List<AudioClip> _tapSounds;    

    public void TapEvent()
    {
        int random = Random.Range(0, 10);
        if (random <= 7)
            _audioSourceTaps.clip = _tapSounds[0];
        else
        {
            _audioSourceTaps.clip = _tapSounds[1];
        }
        _audioSourceTaps.Play();
    }

    public void TapSound()
    {
        _audioSourceTaps.clip = _tapSounds[5];
        _audioSourceTaps.Play();
    }

    public void PlayAudioClip(AudioClip audioClip, AudioSource audioSource)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

}
