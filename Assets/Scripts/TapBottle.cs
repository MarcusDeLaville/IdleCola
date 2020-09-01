using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapBottle : MonoBehaviour
{
    private Transform _botteleTransform;

    private float _normalScale = 1.08f;
    private float _tapScale = 1.04f;

    private void Start()
    {
        _botteleTransform = GetComponent<Transform>();
    }

    public void OnDown()
    {    
        _botteleTransform.localScale = new Vector3(_tapScale, _tapScale, _tapScale);      
    }

    public void OnUp()
    {
        _botteleTransform.localScale = new Vector3(_normalScale, _normalScale, _normalScale);
    } 

}
