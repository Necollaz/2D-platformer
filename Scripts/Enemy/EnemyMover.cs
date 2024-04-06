using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public void MoveAndRotate(Transform mover, Transform target, float speed)
    {
        mover.position = Vector2.MoveTowards(mover.position, target.position, speed * Time.deltaTime);

        if (target.position.x > mover.position.x)
            mover.localScale = new Vector3(Mathf.Abs(mover.localScale.x), mover.localScale.y, mover.localScale.z);
        else if (target.position.x < mover.position.x)
            mover.localScale = new Vector3(-Mathf.Abs(mover.localScale.x), mover.localScale.y, mover.localScale.z);
    }
}
