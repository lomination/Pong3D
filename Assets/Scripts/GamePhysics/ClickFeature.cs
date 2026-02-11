using GameGraphics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GamePhysics
{
    public class ClickFeature : MonoBehaviour
    {
        private Vector2 touchPos;
        private RaycastHit hit;
        private Camera cam;
        public PlayerInput playerInput;
        private InputAction touchPressAction;
        private InputAction touchPosAction;
    
        // Start is called before the first frame update
        void Start()
        {
            cam = GetComponent<Camera>();
            touchPressAction = playerInput.actions["TouchPress"];
            touchPosAction = playerInput.actions["TouchPos"];
        }

        // Update is called once per frame
        void Update()
        {
            if (!touchPressAction.WasPerformedThisFrame()) return;
            touchPos = touchPosAction.ReadValue<Vector2>();
            Ray ray = cam.ScreenPointToRay(touchPos);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObj = hit.collider.gameObject;
                if (hitObj.layer == 3)
                {
                    RainbowManager.Singleton.Flash();
                }
            }
        }

    }
}