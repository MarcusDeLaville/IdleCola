using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{
    [SerializeField] private Transform _lightLines;
    [SerializeField] private float _angelPerTik = 5;

    private void Update()
    {
        _lightLines.Rotate(new Vector3(0, 0, _angelPerTik) * Time.deltaTime);
    }
}
