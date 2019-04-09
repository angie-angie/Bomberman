using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstDestroy : MonoBehaviour
{

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Burst")
        {
            Destroy(col.gameObject);
        }
    }
}
