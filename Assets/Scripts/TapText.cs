using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapText : MonoBehaviour
{
    private bool _isMove;
    private Vector2 _moveVector;

    [SerializeField]private Animation _animationText;

    private void Update()
    {
        if (!_isMove) return;
        transform.Translate(_moveVector * Time.deltaTime);

    }

    public void StartMotion(int capsRecived)
    {
        transform.localPosition = new Vector2(Random.Range(-50, 50), Random.Range(-50, 50));
        GetComponent<Text>().text = "+" + capsRecived;
        _moveVector = new Vector2(0, Random.Range(3, 3));
        _isMove = true;
       _animationText.Play();
    }

    public void StopMotion()
    {
        _isMove = false;
    }
}
