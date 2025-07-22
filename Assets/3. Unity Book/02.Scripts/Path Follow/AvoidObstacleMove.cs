using System;
using UnityEngine;

public class AvoidObstacleMove : MonoBehaviour
{
    public float speed = 10f;
    public float mass = 5f;
    public float force = 50f;
    public float minDistToAvoid = 5f; 

    private float curSpeed;
    private Vector3 targetPoint;
    public float steeringForce = 10f;

    private void Start()
    {
        targetPoint = Vector3.zero;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                targetPoint = hit.point; // 마우스 클릭한 곳을 목표 지점으로 설정
            }
        }
        
        Vector3 dir = targetPoint - transform.position;
        dir.Normalize();

        dir = GetAvoidanceDirection(dir);
        if (Vector3.Distance(transform.position, targetPoint) < 1f)
            return;
        
        curSpeed = speed * Time.deltaTime;

        transform.position += transform.forward * curSpeed;
        
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, steeringForce * Time.deltaTime);
        
    }

    public Vector3 GetAvoidanceDirection(Vector3 direction)
    {
        RaycastHit hit;
        int layermask = 1 << 15;
        if (Physics.Raycast(transform.position, transform.forward, out hit, minDistToAvoid, layermask))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0f;
            direction = transform.forward + hitNormal * force;
            direction.Normalize();
        }

        return direction;
    }
}
