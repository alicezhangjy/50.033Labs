using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player; // Mario's Transform
    public Transform endLimit; // GameObject that indicates end of map
    private float offset; // initial x-offset between camera and Mario
    private float startX; // smallest x-coordinate of the Camera
    private float endX; // largest x-coordinate of the camera
    private float viewportHalfWidth;
    public Transform startLimit; //GameObject that indicates left side start of map
    private float rightEndX;

    private Camera Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
        // get coordinate of the bottomleft of the viewport
        // z doesn't matter since the camera is orthographic
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        viewportHalfWidth = Mathf.Abs(bottomLeft.x - this.transform.position.x);

        offset = this.transform.position.x - player.position.x;
        startX = this.transform.position.x;
        endX = endLimit.transform.position.x - viewportHalfWidth; //distance between end of map from the left bottom corner of the camera 
        rightEndX = startLimit.transform.position.x - viewportHalfWidth;

    }

    // Update is called once per frame
    void Update()
    {
        float desiredX = player.position.x + offset; //maintain the offset between camera's position and mario's position
        // check if desiredX is within startX and endX
        if ((desiredX > startX && desiredX < endX) || (desiredX < startX && desiredX > rightEndX))
        {
            this.transform.position = new Vector3(desiredX, this.transform.position.y, this.transform.position.z);
        }



    }
}
