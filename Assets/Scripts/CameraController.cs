using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public BallController target;
    private float offset;
    private float extraDistance = -1f;

    // Start is called before the first frame update
    void Awake()
    {
        offset = transform.position.y - target.transform.position.y + extraDistance;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;
        curPos.y = target.transform.position.y + offset;
        transform.position = curPos;
    }
}
