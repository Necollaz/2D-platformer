using System;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    private Coin _coin;
    private MedicineChest _medicineChest;

    public event Action CoinCollected;
    public event Action PickedMedicineChest;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out _coin))
        {
            _coin.Destroy();
            CoinCollected?.Invoke();
        }
        else if(collision.TryGetComponent(out _medicineChest))
        {
            _medicineChest.Use();
            PickedMedicineChest?.Invoke();
        }
    }
}
