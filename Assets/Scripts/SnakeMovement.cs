using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using TMPro;

public class SnakeMovement : MonoBehaviour
{
    public float Speed => _speed;
    public List<GameObject> TailObjects => _tailObjects;
    public float ZOffSet => _zOffset;
    public UnityEvent EatFood => _eatFood;

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private List<GameObject> _tailObjects = new List<GameObject>();
    [SerializeField] private GameObject _tailPrefab;
    [SerializeField] private int _score;
    [SerializeField] private float _zOffset = -0.5f;
    [SerializeField] private UnityEvent _eatFood;
    [SerializeField] private TMP_Text _textScore;

    private void Awake()
    {
        AddScore(PlayerPrefs.GetInt(SaveName.NameSaveScore));
    }

    private void Start()
    {
        _tailObjects.Add(gameObject);

    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        RotationSnake();
    }

    private void RotationSnake()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * _rotationSpeed * Time.deltaTime);
        }
    }
    
    private void AddScore(int score)
    {
        _score += score;
        _textScore.text = "SCORE: " + _score;
        PlayerPrefs.SetInt(SaveName.NameSaveScore, _score);
    }

    public void AddTail()
    {
        Vector3 tailPos = _tailObjects[_tailObjects.Count - 1].transform.position;
        tailPos.z -= _zOffset;
        _tailObjects.Add(Instantiate(_tailPrefab, tailPos, Quaternion.identity));
        AddScore(1);
    }
}
class SaveName
{
    public const string NameSaveScore = "Score";
}
