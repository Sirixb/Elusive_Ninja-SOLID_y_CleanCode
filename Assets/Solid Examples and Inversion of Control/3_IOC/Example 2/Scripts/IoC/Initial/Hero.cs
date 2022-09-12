using UnityEngine;

namespace IoC.Initial
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var x = horizontal * _speed * Time.deltaTime;
            transform.Translate(x, 0.0f, 0.0f);
        }
    }
}
