using UnityEngine;
using UnityEngine.UI;

namespace GamePhysics
{
    public class KillWall : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 3)
            {
                Destroy(other.gameObject);
                startButton.gameObject.SetActive(true);
            }
        }
    }
}
