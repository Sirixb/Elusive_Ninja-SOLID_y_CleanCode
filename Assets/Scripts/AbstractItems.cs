using UnityEngine;

public  abstract class AbstractItems : MonoBehaviour
{

    [SerializeField] private string _id;
    public string Id => _id;
}
