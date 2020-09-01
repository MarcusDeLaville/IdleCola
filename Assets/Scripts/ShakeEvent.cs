using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakeEvent : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _textRate;
    [SerializeField] private Animator _animatorRate;


    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;


    private bool _shaked;

    [SerializeField] private Caps _caps;
    [SerializeField] private Animator _animator;

    private Vector3 _accerationDir;

    private void Start()
    {   
        StartCoroutine(Restart());
    }

    private void Update()
    {
        _accerationDir = Input.acceleration;
       
        if (_accerationDir.sqrMagnitude >= 2f)
        {
            _shaked = true;
        }
        else
        {
            _shaked = false;
        }
    }

    public void SetProgress(float value, float maxValue)
    {
        _slider.value = 0;

        float normalezedValue = value / maxValue;
        float duration = Mathf.Lerp(_minTime, _maxTime, normalezedValue);

        StartCoroutine(LerpValue(0, normalezedValue, duration));
    }

    private IEnumerator LerpValue(float startValue, float endValue,float duration)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            _slider.value = nextValue;

            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator Restart()
    {
        SetProgress(55, 55);
        yield return new WaitForSeconds(55);
        StartCoroutine(SetRate());
    }

    private IEnumerator SetRate()
    {
        _animator.SetBool("isPlaying", true);
        yield return new WaitForSeconds(5);

        if (_shaked)
        {
            _caps.SetRate(55);
            _textRate.text = "55x";
            _animatorRate.SetBool("isPlaying", true);
            Invoke("EndEvent", 15);
        }
        else
        {
            _caps.SetDefaultRate();
        }

        _animator.SetBool("isPlaying", false);
        StartCoroutine(Restart());
    }

    private void EndEvent()
    {
        _textRate.text = "1x";
        _animatorRate.SetBool("isPlaying", false);
    }
}
