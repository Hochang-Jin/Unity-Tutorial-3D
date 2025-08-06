using UnityEngine;

public class MoveRun : IMovement
{
    public float speed;

    public MoveRun(float speed)
    {
        this.speed = speed;
    }
    
    public void Move(Transform transform)
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
}
