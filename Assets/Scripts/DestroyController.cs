using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    [SerializeField] bool destroyAfterTime = false;
    [SerializeField] float destroyAfter = 1.0f;
    [SerializeField] GameObject target;

    void Start()
    {
        target = gameObject;
    }

    private void Update() {
        if(!destroyAfterTime) return;

        destroyAfter -= Time.deltaTime;
        if(destroyAfter <= 0)
            Destroy();
    }
    public void Destroy()
    {
        Destroy(target.gameObject);
    }
}
