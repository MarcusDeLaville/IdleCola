using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemBase : MonoBehaviour
{
    public int _price;
    public int _level;
    public int _growrh;
    public string _name;
    public Text _nameText;
    public Text _priceText;
    public Text _levelText;
    public Text _growthText;

    public int _upsCount;

    public virtual void OnInteract()
    {

    }

    public void Draw()
    {
        _nameText.text = _name;
        _priceText.text = _price.ToString();
        _levelText.text = $"Уровень: {_level.ToString()}";
        _growthText.text = $"Прирост: {_growrh.ToString()}";
    }

    public void SaveContUps()
    {
        if (!PlayerPrefs.HasKey("UpsCount"))
        {
            _upsCount = 0;
            PlayerPrefs.SetInt("UpsCount", _upsCount);
        }

        _upsCount = PlayerPrefs.GetInt("UpsCount");
        _upsCount++;
        PlayerPrefs.SetInt("UpsCount", _upsCount);
    }
}
