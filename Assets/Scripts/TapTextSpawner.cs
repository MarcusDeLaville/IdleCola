using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTextSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _textsParent;
    [SerializeField] private GameObject _textPrefab;
    [SerializeField] private TapText[] _textPool = new TapText[15];
    [SerializeField] private Caps _caps;
    [SerializeField ]private bool _isGoldCap;
    private int _index;
    private bool _isCollect;
   
    private void Start()
    {
        _isCollect = false;
        _caps = FindObjectOfType<Caps>();

        for(int i = 0; i < _textPool.Length; i++)
        {
            _textPool[i] = Instantiate(_textPrefab, _textsParent.transform).GetComponent<TapText>();
        }
    }

    public void OnClick()
    {
        if (_isGoldCap)
        {      
            if(_isCollect == false)
            {
                _textPool[_index].StartMotion(_caps.GetCapsPerTaps() * 200);
                _isCollect = true;
            }  
        }
        else
        {
            _textPool[_index].StartMotion(_caps.GetCapsPerTaps());
        }
        
        _index = _index == _textPool.Length - 1 ? 0 : _index + 1;
    }
}
