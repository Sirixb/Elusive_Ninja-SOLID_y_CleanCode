using UnityEngine;

/* Set permanent speed power up */
public class SpeedItem : AbstractItems
{
    [SerializeField] private float _speedToAssign;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<MovementController>();
        if (player)
        {
            player.SetSpeed(_speedToAssign);
            Destroy(gameObject);
        }

    }
}
