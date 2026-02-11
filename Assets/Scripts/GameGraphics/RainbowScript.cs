using UnityEngine;

namespace GameGraphics
{
    public class RainbowScript : MonoBehaviour
    {
        private Renderer rend;
        private void Start()
        {
            rend = GetComponent<Renderer>();
            rend.material.color = Color.HSVToRGB(RainbowManager.Singleton.Hue, 1, 1);
        }

        private void Update()
        {
            rend.material.color = Color.HSVToRGB(RainbowManager.Singleton.Hue, 1, 1);
        }

    }
}
