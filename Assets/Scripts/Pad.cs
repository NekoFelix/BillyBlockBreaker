using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    [SerializeField] private float _screenWidthInUnits = 16f;
    [SerializeField] private float _minX = 1f;
    [SerializeField] private float _maxX = 15f;

    private void Update()
    {
        float mousePositionX = Input.mousePosition.x / Screen.width * _screenWidthInUnits;
        
        Vector2 padPosition = new Vector2(transform.position.x, transform.position.y);
        padPosition.x = Mathf.Clamp(mousePositionX, _minX, _maxX);
        transform.position = padPosition;
    }
}
