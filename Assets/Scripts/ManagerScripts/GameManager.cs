using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject player;
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

    public void Death()
    {
        Debug.Log("you lost :(");
        
        player.GetComponent<PlayerMovement>().enabled = false;


        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().enabled = false;
        }
    }
}
