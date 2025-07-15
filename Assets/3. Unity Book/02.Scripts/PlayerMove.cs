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
        
        transform.position = transform.position + new Vector3(h, 0, v);

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
        }
        
    }
}
