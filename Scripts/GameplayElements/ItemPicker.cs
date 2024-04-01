using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PickableItem> (out var item))
            item.Pick();
    }
}
