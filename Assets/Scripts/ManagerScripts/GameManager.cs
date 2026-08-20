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

    [SerializeField] private GameObject enemy;

    public static bool gameStarted = false;
    public bool isPaused = false;
    public static int hi_score = 0;
    public static float enemySpeed = 0.5f;

    public GameObject player;
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI score_text;
    [SerializeField] private TextMeshProUGUI hi_score_txt;

    //ScoreGUI
    private int score_value = 0;


    void Start()
    {
        if (!gameStarted)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyMovement>().enabled = false;
            }
            player.GetComponent<PlayerMovement>().enabled = false;
        }
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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().enabled = true;
        }
        player.GetComponent<PlayerMovement>().enabled = true;
        gameStarted = true;
        hi_score_txt.text = "HI: " + hi_score;
        Vector3 new_cam_pos = new Vector3(-0.1f,4.7f,-11.8f);
        mainCam.transform.localPosition = new_cam_pos;
        startMenu.SetActive(false);
        HUD.SetActive(true);
    }

    public void AddScore()
    {
        
        score_value += 1;
        score_text.text = "Score: " + score_value;
        if(score_value > hi_score)
        {
            hi_score = score_value;
            hi_score_txt.text = "HI: " + hi_score;
        }

        if(score_value % 3 == 0)
        {
            SpawnEnemy();
            
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            enemySpeed += 0.1f;
            enemy.GetComponent<EnemyMovement>().speed = enemySpeed;
        }
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

    public void SpawnEnemy()
    {
        float rand_z = Random.Range(-14,22);
        float rand_x = Random.Range(-15,10);
        Vector3 enemy_spawn = new Vector3(rand_x, 10f, rand_z);

        Instantiate(enemy, enemy_spawn, Quaternion.identity);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().speed = enemySpeed;
        }
    }

    public void speedIncrease()
    {
        player.GetComponent<PlayerMovement>().player_speed += 0.5f;
    }

}
