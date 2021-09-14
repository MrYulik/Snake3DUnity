using UnityEngine;
using UnityEngine.SceneManagement;

public class TailMovement : MonoBehaviour
{
    private float _speed;
    private Vector3 _tailTarget;
    private GameObject _tailTargetObject;
    private SnakeMovement _snake;
    private int _indexTail;

    private void Start()
    {
        _snake = GameObject.FindObjectOfType<SnakeMovement>().GetComponent<SnakeMovement>();
        _speed = _snake.Speed;
        _tailTargetObject = _snake.TailObjects[_snake.TailObjects.Count - 2];
        _indexTail = _snake.TailObjects.IndexOf(gameObject);
    }
    private void Update()
    {
        _tailTarget = _tailTargetObject.transform.position;
        _tailTarget.z -= _snake.ZOffSet;
        transform.LookAt(_tailTarget);
        transform.position = Vector3.Lerp(transform.position, _tailTarget, Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out SnakeMovement snake))
        {
            if(_indexTail > 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
