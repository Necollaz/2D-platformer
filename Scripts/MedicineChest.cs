using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    [SerializeField] private int _healthRestoreAmount;

    private GameObject _medicineChestGameObject;
    private Animator _animator;

    public bool IsPicked => _medicineChestGameObject.activeSelf == false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _medicineChestGameObject = gameObject;
        _medicineChestGameObject.SetActive(true);
    }

    public int Use()
    {
        int restoreAmount = _healthRestoreAmount;
        _medicineChestGameObject.SetActive(false);
        return restoreAmount;
    }

    public void ResetState()
    {
        _medicineChestGameObject.SetActive(true);
    }
}
