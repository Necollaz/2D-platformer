using System.Collections.Generic;
using UnityEngine;

public class MedicineChestSpawner : MonoBehaviour
{
    [SerializeField] private MedicineChest[] _medicineChests;
    [SerializeField] private float _timeToSpawn;

    private List<MedicineChest> _pickedChests = new List<MedicineChest>();

    void Start()
    {
        InvokeRepeating(nameof(Spawn), _timeToSpawn, _timeToSpawn);
    }

    private void Spawn()
    {
        _pickedChests.Clear();

        foreach (var medicineChest in _medicineChests)
        {
            if (medicineChest.IsPicked)
            {
                _pickedChests.Add(medicineChest);
            }
        }

        if(_pickedChests.Count > 0)
        {
            MedicineChest medicineChest = _pickedChests[Random.Range(0, _pickedChests.Count)];
            medicineChest.ResetState();
        }
    }
}
