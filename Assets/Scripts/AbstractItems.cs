using UnityEngine;

/* Base of every collectible: it disappears by itself if the player does not pick it up in time */
public abstract class AbstractItems : MonoBehaviour
{
    [SerializeField] private string _id;
    [SerializeField, Min(0.1f)] private float _lifetime = 8;

    public string Id => _id;

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }
}
