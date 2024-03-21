using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
            coin.Pick();
    }
}
