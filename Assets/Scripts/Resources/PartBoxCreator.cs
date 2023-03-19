using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBoxCreator : MonoBehaviour
{
    [SerializeField] private PartBox _partBoxPrefab;
    [SerializeField] private float _spawnRadius;


    public void CreatePartBox(Vector3 worldPosition)
    {
        PartBox newPartBox = Instantiate(_partBoxPrefab, worldPosition, Quaternion.identity);
        float angel = Random.Range(0, 100) / 100;
        Vector3 newPosition = new Vector3(Mathf.Sin(Mathf.PI * angel) * _spawnRadius, _partBoxPrefab.transform.localScale.y / 2, -Mathf.Cos(Mathf.PI * angel) * _spawnRadius);
        newPartBox.MoveTo(newPosition);
    }
}
