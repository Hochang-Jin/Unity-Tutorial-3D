using UnityEngine;

public class MoveFly : IMovement
{
    public float speed;

    public MoveFly(float speed)
    {
        this.speed = speed;
    }
    
    public void Move(Transform transform)
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
}
