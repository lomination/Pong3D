using UnityEngine;

namespace GamePhysics
{
    public class PaddleMovement : BallBouncer
    {
        [SerializeField] private Transform cameraTransform;
        private new void Start()
        {
            base.Start();
            ScoreManager.Singleton.Score = 0;
        }

        // Update is called once per frame
        private void Update()
        {
            transform.position = cameraTransform.position + new Vector3(0f, 0f, 0.1f);
        }

        protected override void ApplyEffect(Collider _)
        {
            ScoreManager.Singleton.Score++;
        }
    }
}
