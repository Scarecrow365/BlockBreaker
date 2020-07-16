using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _blocks;
    [SerializeField] private int _spawnCountBlocks;
    [SerializeField] private float _offsetSideBorders;
    [SerializeField] private Transform _spawnPlaceForBlocks;
    private readonly List<Vector2> _spawnPositions = new List<Vector2>();
    private Vector2 _startSpawnPos;
    private Vector2 _endSpawnPos;

    private void Awake()
    {
        _startSpawnPos = new Vector2(-NewPosX / 2 + _offsetSideBorders , 11);
        _endSpawnPos = new Vector2(NewPosX / 2 - _offsetSideBorders, _endSpawnPos.y);
    }

    private void Start()
    {
        StartCreateBlocks();
    }

    private void StartCreateBlocks()
    {
        _spawnPositions.Add(new Vector2(_startSpawnPos.x, _startSpawnPos.y));

        for (var i = 0; i < _spawnCountBlocks; i++)
        {
            if (_spawnPositions[i].x >= _endSpawnPos.x)
            {
                _spawnPositions.Add(new Vector2(_startSpawnPos.x, _spawnPositions[i].y - 0.5f));
                CreateBlock(_spawnPositions[i]);
            }
            else
            {
                _spawnPositions.Add(new Vector2(_spawnPositions[i].x + 0.5f, _spawnPositions[i].y));
                CreateBlock(_spawnPositions[i]);
            }
        }
    }

    private void CreateBlock(Vector2 position)
    {
        int index = Random.Range(0, _blocks.Length);
        GameObject go = Instantiate(_blocks[index], position, Quaternion.identity);
        go.transform.SetParent(_spawnPlaceForBlocks);
    }

    private float NewPosX => 1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f);
}