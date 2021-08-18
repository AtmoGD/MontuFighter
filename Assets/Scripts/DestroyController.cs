using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    [SerializeField] GameObject target;
    public void Destroy() {
        Destroy(target.gameObject);
    }
}
