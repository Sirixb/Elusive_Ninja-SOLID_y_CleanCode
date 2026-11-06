using UnityEngine;

public class HealItem : AbstractItems
{
    [SerializeField] private int _healQuantity;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var healComponent = other.collider.GetComponent<IHealReceiver>();
        if (healComponent != null)
        {
            healComponent.Heal(_healQuantity);
            Destroy(gameObject);
        }
    }
}
