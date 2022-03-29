using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Pad pad;
    [SerializeField] private float pushX;
    [SerializeField] private float pushY;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFloat;

    private Vector2 ballOffset;
    private bool hasStarted = false;

    AudioSource audioSource;
    Rigidbody2D rbBall;

    private void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
        ballOffset = transform.position - pad.transform.position; 
        audioSource = GetComponent<AudioSource>();
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!hasStarted)
        {
            LockBallToPad();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rbBall.velocity = new Vector2(pushX, pushY);
            hasStarted = true;
        }
    }

    private void LockBallToPad()
    {
        Vector2 padPosition = new Vector2(pad.transform.position.x, pad.transform.position.y);
        transform.position = padPosition + ballOffset;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        rbBall.velocity += new Vector2(Random.Range(-0.1f, 0.2f), Random.Range(-0.1f, 0.2f));
        if (hasStarted && collision.collider.tag != "Breakable")
        {
            //transform.localScale = new Vector2(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f);
            audioSource.PlayOneShot(ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]);
        }
    }

    public void SlowBall()
    {
        rbBall.velocity = new Vector2(-1f,0);
    }
}
