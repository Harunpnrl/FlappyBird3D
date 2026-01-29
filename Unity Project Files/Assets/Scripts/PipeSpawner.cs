using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float heightRange = 3.5f;
    [SerializeField] private float maxTime = 2f;
    [SerializeField] private GameObject pipe;

    ScoreManager scoreManager;

    private float timer;
    private int lastScore = 0;

    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        int currentScore = ScoreManager.instance.GetScore();
        if (currentScore > lastScore)
        {
            maxTime -= 0.01f;
            maxTime = Mathf.Max(0.70f, maxTime);
            lastScore = currentScore;
        }

        timer += Time.deltaTime;
    
        if (timer >= maxTime)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = new Vector3(0, Random.Range(-heightRange, heightRange), 50);
        GameObject pipes = Instantiate(pipe, spawnPos, Quaternion.identity);

        Destroy(pipes, 7f);
    }
}
