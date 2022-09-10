using UnityEngine;

namespace DavidSolution
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private string id;
        public string Id => id;
    }

}
