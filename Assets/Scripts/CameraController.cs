using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 lookAtOffset;

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (!target) return;

        transform.position = target.transform.position + offset;
        transform.LookAt(target.transform.position + lookAtOffset);
    }

}
