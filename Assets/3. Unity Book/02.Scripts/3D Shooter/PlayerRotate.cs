using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float rotSpeed = 200f;
    // 회전 값 누적 변수
    public float mx = 0;
    
    void Update()
    {
        // 1. 입력값 받기
        float mouse_X = Input.GetAxis("Mouse X");
        // 2. 입력값을 누적 시키기
        mx += mouse_X * rotSpeed * Time.deltaTime;
        
        // 3. 회전 시키기
        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
