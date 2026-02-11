using System.Collections.Generic;
using GameGraphics;
using JetBrains.Annotations;
using UnityEngine;

namespace GamePhysics
{
    public class FrontWall : BallBouncer
    {
        [SerializeField] private GameObject splashPrefab;
        private List<GameObject> splashes;

        private new void Start()
        {
            base.Start();
            splashes = new List<GameObject>();
        }

        protected override void ApplyEffect(Collider other)
        {
            // project the ball position on the ball bouncer
            var contactPos = other.transform.position;
            if (normal is Axis.X)
                contactPos.x = transform.position.x;
            else if (normal is Axis.Y)
                contactPos.y = transform.position.y;
            else if (normal is Axis.Z)
                contactPos.z = transform.position.z;
                
            var splash = Instantiate(splashPrefab);
            splash.transform.position = contactPos - (splashes.Count + 1) * new Vector3(0, 0, 0.001f);
            splash.transform.eulerAngles = new Vector3(-90, 0, 0);
            var rend = splash.GetComponent<Renderer>();
            rend.material.color = Color.HSVToRGB(RainbowManager.Singleton.Hue, 1, 1);
            splashes.Add(splash);
        }

        public void ClearSplashes()
        {
            foreach (GameObject splash in splashes)
            {
                Destroy(splash);
            }
            splashes.Clear();
        }
    }
}