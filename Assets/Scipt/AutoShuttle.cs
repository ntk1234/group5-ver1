using UnityEngine;

public class AutoShuttle : MonoBehaviour
{
    public float speed = 10f; // 車輛運動的速度
    public float distance = 50f; // 車輛移動的距離

    private Vector3 startPos; // 車輛的起始位置
    private Vector3 endPos; // 車輛的終點位置
    private bool isMovingToEnd = true; // 車輛是否正在往終點位置移動

    // 在啟動腳本時初始化變數
    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + (transform.forward * distance);
    }

    // 在每一帧中更新車輛的位置和方向
    private void Update()
    {
        // 根據車輛的方向和速度移動車輛
        float moveDistance = speed * Time.deltaTime;
        if (isMovingToEnd)
        {
            transform.position += transform.forward * moveDistance;
        }
        else
        {
            transform.position -= transform.forward * moveDistance;
        }

        // 如果車輛到達了終點位置，則切換方向
        float distanceToEnd = Vector3.Distance(transform.position, endPos);
        if (distanceToEnd < moveDistance)
        {
            isMovingToEnd = false;
        }

        // 如果車輛回到了起始位置，則切換方向
        float distanceToStart = Vector3.Distance(transform.position, startPos);
        if (distanceToStart < moveDistance)
        {
            isMovingToEnd = true;
        }
    }
}