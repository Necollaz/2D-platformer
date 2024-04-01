using UnityEngine;

public abstract class PickableItem : MonoBehaviour
{
    protected Animator Animator;

    public bool IsPicked => gameObject.activeSelf == false;

    protected void Awake()
    {
        Animator = GetComponent<Animator>();
        ResetState();
    }

    public virtual void ResetState()
    {
        gameObject.SetActive(true);
    }

    public void Pick()
    {
        gameObject.SetActive(false);
    }
}
