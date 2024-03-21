using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject _coinPrefab;
    private Animator _animator;

    public bool IsPecked => gameObject.activeSelf == false;

    private void Awake()
    {
        _coinPrefab = gameObject;
        _coinPrefab.SetActive(true);
        _animator = GetComponent<Animator>();
    }

    public void Pick()
    {
        _coinPrefab.SetActive(false);
    }

    public void ResetState()
    {
        _coinPrefab.SetActive(true);
    }

}
