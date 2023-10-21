using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using Server;

public class CubeMovement : MonoBehaviour
{
    public float moveDistance = 2.0f; // The distance the cube will move.
    public float moveSpeed = 2.0f;    // The speed of the cube's movement.

    private Vector3 startPos;
    private Vector3 endPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.right * moveDistance;
        Thread dowmov = new Thread(Download);
        dowmov.Start();
    }

    void Update()
    {
        // Calculate the new position for the cube.
        Vector3 targetPos = movingRight ? endPos : startPos;
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        // If the cube reaches its destination, change direction.
        if (transform.position == targetPos)
        {
            movingRight = !movingRight;
        }
    }

    void Download()
    {
        DownloadFile.DownloadFileFromUrl("https://speed.hetzner.de/100MB.bin", "Assets/Links/Download.bin");
    }
}