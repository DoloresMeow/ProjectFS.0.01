using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    internal Vector3 input;
    internal bool isGrounded;

    public virtual void ControlAnimatorRootMotion()
    {
        if (!this.enabled)
            return;
        
    }

    public virtual void UpdateMoveDirection(Transform referenceTransform = null)
    {

    }

    public virtual void AirControl()
    {
        transform.position = new Vector3(transform.position.x + input.x * Time.deltaTime, transform.position.y, transform.position.z + input.z * Time.deltaTime);
    }
}
