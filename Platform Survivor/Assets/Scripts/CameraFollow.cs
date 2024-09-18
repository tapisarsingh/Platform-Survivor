using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public float cameraSpeed;
    public float distanceSpeed;
    public float speedFrequency;
    public Transform player;
    public float yOffset;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameStart)
            return;

        distanceSpeed += speedFrequency*Time.deltaTime;
        Vector3 newPos = new Vector3(transform.position.x + distanceSpeed, transform.position.y + yOffset, -10);
        transform.position = Vector3.Slerp(transform.position, newPos, cameraSpeed * Time.deltaTime);
    }
}
