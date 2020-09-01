using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Caps : MonoBehaviour
{
    [SerializeField] private int _capsCount;
    [SerializeField] private int _capsPerSeconds;
    [SerializeField] private int _capsPerTap;
    private int _globalCapsPerTap;

    private long _producedCaps;
    private int _producedPerTaps;
    private int _tapsCount;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("CapsPerTap"))
        {
            _capsPerTap = 1;
            PlayerPrefs.SetInt("CapsPerTap", _capsPerTap);
        }
        _capsCount = PlayerPrefs.GetInt("Caps");
        _capsPerSeconds = PlayerPrefs.GetInt("CapsPerSeconds");
        _capsPerTap = PlayerPrefs.GetInt("CapsPerTap");

        _globalCapsPerTap = _capsPerTap;
        StartCoroutine(UpdateCaps());
        StartCoroutine(SaveCaps());
    }

    private IEnumerator UpdateCaps()
    {
        while (true)
        {
            _capsCount += _capsPerSeconds;
            _producedCaps += _capsPerSeconds;
            yield return new WaitForSeconds(1.0f);
        }      
    }

    private IEnumerator SaveCaps()
    {
        while (true)
        {
            PlayerPrefs.SetInt("Caps", _capsCount);
            PlayerPrefs.SetString("ProducedCaps", _producedCaps.ToString());
            PlayerPrefs.SetInt("TapsCount", _tapsCount);
            PlayerPrefs.SetInt("ProducedCapsPerTap", _producedPerTaps);
            yield return new WaitForSeconds(10.0f);
        }
    }

    public void OnTap()
    {
        _capsCount += _globalCapsPerTap;
        _producedCaps += _globalCapsPerTap;
        _tapsCount++;
        _producedPerTaps += _globalCapsPerTap;

    }

    public void AddCap(int caps)
    {
        _capsCount += caps;
        _producedCaps += caps;
    }

    public int GetCaps()
    {
        return _capsCount;
    }

    public int GetCapsPerSeconds()
    {
        return _capsPerSeconds;
    }

    public int GetCapsPerTaps()
    {
        return _globalCapsPerTap;
    }

    public void SetRate(int rate)
    {
        StartCoroutine(SetRates(rate));
    }

    private IEnumerator SetRates(int rate)
    {
        _globalCapsPerTap = _capsPerTap;
        _globalCapsPerTap = _capsPerTap * rate;

        yield return new WaitForSeconds(15);
        SetDefaultRate();
    }

    public void SetDefaultRate()
    {
        _globalCapsPerTap = _capsPerTap;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Caps", _capsCount);
    }
    
    public void AddCapsPerSeconds(int growth)
    {
        _capsPerSeconds += growth;
        PlayerPrefs.SetInt("CapsPerSeconds", _capsPerSeconds);
    }

    public void AddCapsPerTap(int growth)
    {
        _capsPerTap = _capsPerTap * growth;
        _globalCapsPerTap = _capsPerTap;
        PlayerPrefs.SetInt("CapsPerTap", _capsPerTap);
    }

    public void DepriveCaps(int depriveAmount)
    {
        _capsCount -= depriveAmount;
    }
}
    
