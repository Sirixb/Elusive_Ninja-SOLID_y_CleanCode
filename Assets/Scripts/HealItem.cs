using UnityEngine;

public class HealItem : AbstractItems
{
    //private ItemsManager.ItemTypes type = ItemsManager.ItemTypes.Heal;
    [SerializeField] private int _healQuantity;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var /*player*/ healComponent = other.collider.GetComponent</*HealtController*/IHealReceiver>();
        if (/*player*/healComponent != null)
        {
            /*player*/healComponent.Heal(_healQuantity);
            Destroy(gameObject);
        }

    }
}
