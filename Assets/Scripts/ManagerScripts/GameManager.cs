using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI score_text;

    //ScoreGUI
    private int score_value = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        score_value += 1;
        score_text.text = "Score: " + score_value;
    }
}
