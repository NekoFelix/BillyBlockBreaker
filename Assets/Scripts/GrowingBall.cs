using UnityEngine;

public class GrowingBall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.localScale = new Vector2(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f);
    }
}
