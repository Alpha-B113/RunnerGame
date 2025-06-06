using System.Collections;
using UnityEngine;

public class Elevator : Door
{
    public Player player;
    public Transform destination;
    private SpriteRenderer playerSr;
    private Rigidbody2D playerRb;
    public AudioSource doorSound;
    public bool ShowSr;

    private void Start()
    {
        playerSr = player.GetComponent<SpriteRenderer>();
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsOpened && Input.GetKeyDown(KeyCode.E))
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        // player.transform.position = destination.position;
        var startPosition = player.transform.position;
        var endPosition = destination.position;
        if (doorSound != null)
            doorSound.Play();
        StartCoroutine(DoTeleport(startPosition, endPosition));
    }

    IEnumerator DoTeleport(Vector3 start, Vector3 end)
    {
        var duration = ShowSr ? 1.5f : 0.5f;
        var elapsed = 0f;
        playerSr.enabled = ShowSr;
        playerRb.bodyType = RigidbodyType2D.Kinematic;

        while (elapsed < duration)
        {
            player.transform.position = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        player.transform.position = end;

        playerSr.enabled = true;
        playerRb.bodyType = RigidbodyType2D.Dynamic;
    }

}
