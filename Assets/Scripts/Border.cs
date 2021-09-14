using UnityEngine;
using UnityEngine.SceneManagement;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeMovement snake))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
