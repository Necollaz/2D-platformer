using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    public PlayerMover Player { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover player))
            Player = player;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover player))
            Player = null;
    }
}
