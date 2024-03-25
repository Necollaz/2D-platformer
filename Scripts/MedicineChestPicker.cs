using UnityEngine;

public class MedicineChestPicker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out MedicineChest medicineChest))
            medicineChest.Use();
            
    }
}
