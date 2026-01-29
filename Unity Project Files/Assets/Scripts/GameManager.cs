using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state;

    public enum GameState
    {
        Menu,
        WaitingToStart,
        Playing,
        GameOver
    }


    [Header("UI")]
    [SerializeField] private GameObject startUIPrefab;
    [SerializeField] private GameObject pressSpaceText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject scoreText;

    private GameObject startUIInstance;

    private Vector3 startUIPos = new Vector3(-2.25f, 4.75f, -10.25f);

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        if (state == GameState.WaitingToStart && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

        if (state == GameState.GameOver && Input.anyKeyDown)
        {
            RestartGame();
        }
    }

    void ResetGame()
    {
        Time.timeScale = 0f;
        state = GameState.Menu;

        startUIInstance = Instantiate(startUIPrefab, startUIPos, Quaternion.identity);

        pressSpaceText.SetActive(false);
        gameOverText.SetActive(false);
        scoreText.SetActive(false);
    }

    public void OnStartButtonPressed()
    {
        Destroy(startUIInstance);
        pressSpaceText.SetActive(true);
        scoreText.SetActive(false);
        state = GameState.WaitingToStart;
    }

    void StartGame()
    {
        pressSpaceText.SetActive(false);
        scoreText.SetActive(true);
        Time.timeScale = 1f;
        state = GameState.Playing;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        state = GameState.GameOver;

        gameOverText.SetActive(true);
        scoreText.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
