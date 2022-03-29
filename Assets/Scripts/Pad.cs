using UnityEngine;

public class Pad : MonoBehaviour
{
    [SerializeField] private float _screenWidthInUnits = 16f;
    [SerializeField] private float _minX = 1f;
    [SerializeField] private float _maxX = 15f;
    [SerializeField] private bool isAutoplayEnabled;
    [SerializeField] Ball ball;

    private void Update()
    {
        Vector2 padPosition = new Vector2(transform.position.x, transform.position.y);
        padPosition.x = Mathf.Clamp(GetXPos(), _minX, _maxX);
        transform.position = padPosition;
    }

    private float GetXPos()
    {
        if (IsAutoplayEnabled())
        {
            return ball.transform.position.x;
        }
        else 
        {
            return Input.mousePosition.x / Screen.width * _screenWidthInUnits;
        }
    }

    private bool IsAutoplayEnabled()
    {
        return isAutoplayEnabled;
    }
}
