using UnityEngine;

namespace GameGraphics
{
    public class ScreenAwaker : MonoBehaviour
    {
        private void Awake()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}
