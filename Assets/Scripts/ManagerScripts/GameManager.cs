using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private GameObject pauseMenu;

    public static bool gameStarted = false;
    public bool isPaused = false;


    public GameObject player;
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI score_text;

    //ScoreGUI
    private int score_value = 0;


    void Start()
    {
        if (gameStarted)
        {
            StartGame();
        }
    }

    void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        gameStarted = true;

        Vector3 new_cam_pos = new Vector3(-0.1f,4.7f,-11.8f);
        mainCam.transform.localPosition = new_cam_pos;
        startMenu.SetActive(false);
        HUD.SetActive(true);
    }

    public void AddScore()
    {
        score_value += 1;
        score_text.text = "Score: " + score_value;
    }

    public void Death()
    {
        Debug.Log("you lost :(");
        HUD.SetActive(false);
        deathMenu.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;


        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().enabled = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
