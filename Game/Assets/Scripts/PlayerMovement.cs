using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    private Queue<Vector3> targetPos = new Queue<Vector3>();
    public float speed = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) SetTargetPosition();
        if (targetPos != null && targetPos.Count != 0)
        {
            if (Vector3.Distance(transform.position, targetPos.Peek()) > 0.01f)
            transform.position = Vector3.MoveTowards(transform.position, targetPos.Peek(), speed * Time.deltaTime);
            else 
            targetPos.Dequeue();
        }
    }
    private void SetTargetPosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = transform.position.z;
        targetPos.Enqueue(pos);
    }
}
