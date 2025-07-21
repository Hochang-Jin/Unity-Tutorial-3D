using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // 카메라가 있을 위치
    public Transform target;

    void Update()
    {
        // 카메라를 목표 위치에 둔다
        transform.position = target.position;
    }
}
