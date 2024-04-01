using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private PickableItem[] _items;
    [SerializeField] private float _timeToSpawn;

    private List<PickableItem> _pickedItems = new List<PickableItem>();

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), _timeToSpawn, _timeToSpawn);
    }

    private void Spawn()
    {
        _pickedItems.Clear();

        foreach (var item in _items)
        {
            if (item.IsPicked)
            {
                _pickedItems.Add(item);
            }
        }

        if(_pickedItems.Count > 0)
        {
            PickableItem item = _pickedItems[Random.Range(0, _pickedItems.Count)];
            item.ResetState();
        }
    }
}
