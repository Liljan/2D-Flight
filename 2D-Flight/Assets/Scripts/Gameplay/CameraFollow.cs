using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 offset;

    private void FixedUpdate()
    {
        Vector3 newPos = new Vector3(target.position.x + offset.x,
                                    target.position.y + offset.y,
                                    transform.position.z);

        transform.position = newPos;
    }


}
