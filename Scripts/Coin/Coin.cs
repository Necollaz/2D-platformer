
public class Coin : PickableItem
{
    public override void ResetState()
    {
        gameObject.SetActive(true);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
