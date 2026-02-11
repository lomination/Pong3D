using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;

namespace GamePhysics
{
    public class BallBouncer : MonoBehaviour
    {
        protected enum Axis
        {
            X,
            Y,
            Z
        }

        [SerializeField] protected Axis normal;
        [SerializeField] [CanBeNull] private ParticleSystem particles = null;
    
        protected Vector3 normalVector;
        protected void Start()
        {
            normalVector = normal switch
            {
                Axis.X => Vector3.right,
                Axis.Y => Vector3.up,
                Axis.Z => Vector3.forward,
                _ => throw new InvalidEnumArgumentException("Invalid axis")
            };
        }

        protected virtual void ApplyEffect(Collider other)
        {
            if (particles != null)
            {
                // project the ball position on the ball bouncer
                var contactPos = other.transform.position;
                if (normal is Axis.X)
                    contactPos.x = transform.position.x;
                else if (normal is Axis.Y)
                    contactPos.y = transform.position.y;
                else if (normal is Axis.Z)
                    contactPos.z = transform.position.z;

                Instantiate(particles, contactPos, Quaternion.identity);
            }
        }
    
        protected void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 3)
            {
                other.gameObject.transform.rotation =
                    Quaternion.LookRotation(Vector3.Reflect(other.gameObject.transform.rotation * Vector3.forward, normalVector));
                
                ApplyEffect(other);
            }
        }
    }
}
