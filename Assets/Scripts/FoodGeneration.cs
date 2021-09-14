using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    [SerializeField] private float _mapSizeX = 10f;
    [SerializeField] private float _mapSizeY = 7f;
    [SerializeField] private GameObject _foodPrefab;

    private GameObject _currentFood;

    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-_mapSizeX, _mapSizeX), 0.5f, Random.Range(-_mapSizeY, _mapSizeY));
    }

    private void AddNewFood()
    {
        _currentFood = Instantiate(_foodPrefab, RandomPosition(), Quaternion.identity);
    }

    private void Update()
    {
        if (!_currentFood)
        {
            AddNewFood();
        }
        else
        {
            return;
        }
    }
}
