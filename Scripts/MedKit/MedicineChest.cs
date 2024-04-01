using UnityEngine;

public class MedicineChest : PickableItem
{
    [SerializeField] private int _restoreAmount;

    public override void ResetState()
    {
        gameObject.SetActive(true);
    }

    public int Use()
    {
        int restoreAmount = _restoreAmount;
        gameObject.SetActive(false);
        Destroy(gameObject);
        return restoreAmount;
    }
}
