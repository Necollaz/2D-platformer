using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    public PlayerMover Player { get; private set; }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.TryGetComponent(out PlayerMover player);

        if (player != null)
            Player = player;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerMover>())
            Player = null;
    }
}
