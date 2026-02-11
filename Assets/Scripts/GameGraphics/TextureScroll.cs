using UnityEngine;

namespace GameGraphics
{
    public class TextureScroll : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
        private Renderer rend;
    
        // Start is called before the first frame update
        void Start()
        {
            rend = GetComponent<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
            rend.material.mainTextureOffset += new Vector2(Time.deltaTime * speed, 0);
        }
    }
}
