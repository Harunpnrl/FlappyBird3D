using UnityEngine;

public class MoveGround : MonoBehaviour
{

    [SerializeField] float speed = 10.0f;

    void Update()
    {
        if (Time.timeScale == 0) return;

        transform.position += Vector3.back * speed * Time.deltaTime;
    }
}
