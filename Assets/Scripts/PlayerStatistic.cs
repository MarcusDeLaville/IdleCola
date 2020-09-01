using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatistic : MonoBehaviour
{
    private long _producedCapsCount; 

    [SerializeField] private Text _currentCapsCountText;
    [SerializeField] private Text _producedCapsCountText;
    [SerializeField] private Text _capsPerSecondsText;
    [SerializeField] private Text _tapsCountText;
    [SerializeField] private Text _tapProducedText;
    [SerializeField] private Text _goldCapCountText;
    [SerializeField] private Text _upsCountText;

    private Caps _caps;

    private void Start()
    {
        _caps = FindObjectOfType<Caps>();
        Draw();
    }

    public void Draw()
    {
        _producedCapsCount = Convert.ToInt64(PlayerPrefs.GetString("ProducedCaps"));

        _producedCapsCountText.text = "Добыто крышек за всё время:   " + _producedCapsCount.ToString();
        _currentCapsCountText.text = "Текущиее количество крышек:   " + _caps.GetCaps().ToString();
        _capsPerSecondsText.text = "Крышек в секунду:   " + _caps.GetCapsPerSeconds().ToString();
        _tapsCountText.text = "Кликов по бутылке за всё время:   " + PlayerPrefs.GetInt("TapsCount").ToString();
        _tapProducedText.text = "Добыто с помощью кликов:   " + PlayerPrefs.GetInt("ProducedCapsPerTap").ToString();
        _goldCapCountText.text  = "Поймано золотых крышек:   " + PlayerPrefs.GetInt("GoldCapsCount").ToString();
        _upsCountText.text = "Количество улучшений за всё время:   " + PlayerPrefs.GetInt("UpsCount").ToString();
    }


}
