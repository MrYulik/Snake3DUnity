using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out SnakeMovement snake))
        {
            snake.AddTail();
            snake.EatFood.Invoke();
            Destroy(gameObject);
        }
    }
}
