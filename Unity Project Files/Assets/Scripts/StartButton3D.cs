using UnityEngine;

public class StartButton3D : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnStartButtonPressed();
        }
    }
}