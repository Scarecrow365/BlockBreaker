using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] blocks;
    [SerializeField] private Vector2 maxVector;
    [SerializeField] private Vector2 minVector;
    [SerializeField] private Transform spawnBlocks;
    [SerializeField] private List<Vector2> vector2;

    private void Start()
    {
        vector2.Add(new Vector2(minVector.x, minVector.y));

        for (var i = 0; i < 329; i++) //329 blocks for 5 rows (1 row = 48 blocks)
            vector2.Add(vector2[i].x == maxVector.x
                ? new Vector2(minVector.x, vector2[i].y - 0.5f)
                : new Vector2(vector2[i].x + 0.5f, vector2[i].y));

        foreach (var t in vector2)
        {
            var goIndex = Random.Range(0, blocks.Length);
            var go = Instantiate(blocks[goIndex], t, Quaternion.identity);
            go.transform.SetParent(spawnBlocks);
        }
    }
}