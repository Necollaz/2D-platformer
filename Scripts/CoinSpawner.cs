using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin[] _coins;
    [SerializeField] private float _timeToSpawn;

    private List<Coin> _pickedCoins = new List<Coin>();

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), _timeToSpawn, _timeToSpawn);
    }

    private void Spawn()
    {
        _pickedCoins.Clear();

        foreach (var coin in _coins)
        {
            if (coin.IsPicked)
            {
                _pickedCoins.Add(coin);
            }
        }

        if(_pickedCoins.Count > 0)
        {
            Coin coin = _pickedCoins[Random.Range(0, _pickedCoins.Count)];
            coin.ResetState();
        }
    }
}
