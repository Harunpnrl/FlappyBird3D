using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ground;
    [SerializeField] private float maxTime = 4.0475f;

    private float timer = 4.0475f;

    private void SpawnGround()
    {
        Vector3 spawnPos = new Vector3(0f, -1.19f, 85.067f);
        GameObject grounds = Instantiate(ground, spawnPos, Quaternion.Euler(-90,0,90));

        Destroy(grounds, 12f);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= maxTime)
        {
            SpawnGround();
            timer = 0f;
        }
    }
}
