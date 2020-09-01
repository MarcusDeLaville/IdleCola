using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottleStore : MonoBehaviour
{
    [SerializeField] private GameObject[] _bottleList;
    [SerializeField] private GameObject[] _bottles;

    private int _index;


    private void Start()
    {
        _index = PlayerPrefs.GetInt("Bottle");
        _bottles[_index].SetActive(true);

        _bottleList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _bottleList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject gameObject in _bottleList)
        {
            gameObject.SetActive(false);
        }
        if (_bottleList[_index])
        {
            _bottleList[_index].SetActive(true);
        }

    }

    public void Switch(int step)
    {
        _bottleList[_index].SetActive(false);
        _index += step;

        if (_index < 0)
        {
            _index = _bottleList.Length - 1;
        }
        if (_index == _bottleList.Length)
        {
            _index = 0;
        }
        _bottleList[_index].SetActive(true);

    }

    public void SubmitChange()
    {
        for (int i = 0; i < _bottles.Length; i++)
        {
            _bottles[i].SetActive(false);
        }
        _bottles[_index].SetActive(true);

        PlayerPrefs.SetInt("Bottle", _index);
    }
}
