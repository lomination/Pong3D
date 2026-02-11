using System.Collections;
using UnityEngine;

namespace GameGraphics
{
    public class RainbowManager: MonoBehaviour
    {
        private static RainbowManager _singleton;
        private bool flashMode = false;
    
        public static RainbowManager Singleton
        {
            get
            {
                if (_singleton is null)
                    Debug.LogError("Rainbow manager not instantiated.");
                return _singleton;
            }
            set
            {
                if (_singleton is not null)
                    Debug.LogError("Rainbow manager already instantiated.");
                else
                    _singleton = value;
            }
        }
    
        [SerializeField] private float speed = 1;

        public float Hue { get; private set; }

        private void Awake()
        {
            Singleton = this;
        }

        private void Update()
        {
            Hue += Time.deltaTime * speed * (flashMode ? 5 : 1);
            Hue %= 1;
        }

        public void Flash()
        {
            flashMode = true;
            StartCoroutine(FlashCountdown());
        }

        private IEnumerator FlashCountdown()
        {
            yield return new WaitForSeconds(2);
            flashMode = false;
        }
    }
}