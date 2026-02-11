using System;
using UnityEngine;

namespace GamePhysics
{
    public class ShadowMovement : MonoBehaviour
    {
        [SerializeField] private float yPosition;

        private void Update()
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(position.x, yPosition, position.z);
        }
    }
}
