using UnityEngine;

public class BallEnemy : MonoBehaviour
{
    private Vector2 kickForce = new Vector2(-12f, 5f);
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
    }

    public void Kick()
    {
        rb.AddForce(kickForce, ForceMode2D.Impulse);
    }
}