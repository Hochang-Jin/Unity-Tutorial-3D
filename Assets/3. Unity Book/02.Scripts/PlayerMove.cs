using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * (Time.deltaTime * 3f);
    }
}
