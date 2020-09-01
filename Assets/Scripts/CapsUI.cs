using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CapsUI : MonoBehaviour
{
    [SerializeField] private Text _capsCountText;
    [SerializeField] private Text _capsPerSecondsText;

    [SerializeField] private Caps _caps;

    private int _capsCount;

    private void Start()
    {
        _capsCount = _caps.GetCaps();
    }

    private void FixedUpdate()
    {
        
        _capsCountText.text = String.Format(CultureInfo.InvariantCulture, "{0:#,# 'крышек'}", _caps.GetCaps()); 
        _capsPerSecondsText.text = _caps.GetCapsPerSeconds().ToString() + " в секунду";
     
    }

    
}
