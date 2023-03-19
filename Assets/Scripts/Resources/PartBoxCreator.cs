using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBoxCreator : MonoBehaviour
{
    [SerializeField] private GameObject _partBoxPrefab;
    [SerializeField] private float _maxSpawnRadius;
    [SerializeField] private float _minSpawnRadius;
    [SerializeField] private float _rightBorder;
    [SerializeField] private float _leftBorder;
    [SerializeField] private Resources _resources;

    private void OnDisable()
    {
        _rightBorder *= 100;
        _leftBorder *= 100;
    }


    public void CreatePartBox(Vector3 worldPosition)
    {

        PartBox newPartBox = Instantiate(_partBoxPrefab, worldPosition + new Vector3(0, 0.5f, 0), Quaternion.identity).GetComponent<PartBox>();
        newPartBox.setResources(_resources);
        float angel = Random.Range(_rightBorder, _leftBorder) / 100f;
        float radius = Random.Range(_minSpawnRadius, _maxSpawnRadius);
        float x = Mathf.Sin(angel);
        float z = Mathf.Cos(angel);
        float y = newPartBox.transform.localScale.y / 2;
        Vector3 newPosition = new Vector3(x * radius, y, z * radius);
        newPartBox.MoveTo(newPosition);
    }
}
