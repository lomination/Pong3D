using GameGraphics;
using GamePhysics;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Button startButton;
    [SerializeField] private FrontWall frontWall;
    
    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        ScoreManager.Singleton.Score = 0;
        frontWall.ClearSplashes();
        Instantiate(ballPrefab);
    }
}
