using System.Collections;
using System.Linq;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin[] _coins;
    [SerializeField] private float _timeToSpawn;

    private Coin[] _pickedCoins;

    private void Start()
    {
        StartCoroutine(SpawnRepeating());
    }

    private IEnumerator SpawnRepeating()
    {
        var wait = new WaitForSeconds(_timeToSpawn);

        while (true)
        {
            yield return wait;

            _pickedCoins = _coins.Where(coin => coin.IsPecked).ToArray();

            if (_pickedCoins.Length == 0)
                continue;

            Coin coin = _pickedCoins[Random.Range(0, _pickedCoins.Length)];
            coin.ResetState();
        }
    }
}
