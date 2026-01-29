using UnityEngine;

public class MovePipe : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;

    void Update()
    {
        if (Time.timeScale == 0) return;

        transform.position += Vector3.back * speed * Time.deltaTime; 
    }
}
