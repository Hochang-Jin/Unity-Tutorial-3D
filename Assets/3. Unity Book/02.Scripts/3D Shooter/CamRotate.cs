using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 200f;
    // 회전 값 누적 변수
    public float mx = 0;
    public float my = 0;
    
    void Update()
    {
        // 1. 입력값 받기
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");
        // 2. 입력값을 누적 시키기
        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;
        // 3. 상하 회전 제한 주기
        my = Mathf.Clamp(my, -90f, 90f);
        // 4. 회전 시키기
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}