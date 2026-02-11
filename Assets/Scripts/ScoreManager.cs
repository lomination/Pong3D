using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _singleton;
    
    public static ScoreManager Singleton
    {
        get
        {
            if (_singleton is null)
                Debug.LogError("Score manager not instantiated.");
            return _singleton;
        }
        set
        {
            if (_singleton is not null)
                Debug.LogError("Score manager already instantiated.");
            else
                _singleton = value;
        }
    }
    
    [SerializeField] private TMP_Text scoreDisplay;
    
    private int _score;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            scoreDisplay.text = $"{Score}";
        }
    }

    private void Awake()
    {
        Singleton = this;
    }

}