using UnityEngine;
using Random = UnityEngine.Random;

namespace GamePhysics
{
    public class Ball : MonoBehaviour
    {
        private void Start()
        {
            transform.eulerAngles = new Vector3(Random.Range(-15f, 15f) , Random.Range(-15f, 15f), 0);
        }
    
        private void Update()
        {
            transform.position += (1.5f + ScoreManager.Singleton.Score / 10f) * Time.deltaTime * (transform.rotation * Vector3.forward);
        }
    }
}
