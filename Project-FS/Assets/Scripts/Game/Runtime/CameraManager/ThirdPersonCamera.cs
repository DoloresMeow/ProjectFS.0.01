using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform mainTarget;

    public float defaultDistance = 6.0f;


    private Camera mainCamera;
    private float distance;
    private Vector3 currentTargetPos;

    void Start()
    {
        //Init();
    }

    public void Init()
    {
        mainCamera = CameraManager.GetInstance().MainCameraComponent;
        if(mainCamera == null)
        {
            mainCamera = GetComponent<Camera>();
        }
        currentTargetPos = mainTarget.position;
        distance = defaultDistance;
        transform.position = currentTargetPos + new Vector3(0, 2, -distance);
        transform.localRotation = Quaternion.Euler(10, 0, 0);
    }

    private void FixedUpdate()
    {
        if (mainTarget == null)
            return;
        CameraMovement();
    }

    public void SetMainTarget(Transform target)
    {
        mainTarget = target;
        Init();
    }
    private void CameraMovement()
    {
        if (mainTarget == null)
            return;

        currentTargetPos = mainTarget.position;
        transform.position = currentTargetPos + new Vector3(0, 2, -distance);
    }
}
