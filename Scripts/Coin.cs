using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject _coinGameObject;
    private Animator _animator;

    public bool IsPicked => _coinGameObject.activeSelf == false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _coinGameObject = gameObject;
        _coinGameObject.SetActive(true);
    }

    public void Pick()
    {
        Debug.Log("Монета подобрана");
        _coinGameObject.SetActive(false);
    }

    public void ResetState()
    {
        _coinGameObject.SetActive(true);
    }
}
