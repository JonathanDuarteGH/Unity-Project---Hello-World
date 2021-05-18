using System.Collections;

using UnityEngine;

public class MoveWithTargetSensor : MonoBehaviour
{
    [HideInInspector] public MoveWithTarget carrier;


    void OnTriggerEnter(Collider ob)
    {
        Rigidbody rb = ob.GetComponent<Rigidbody>();
        if (rb != null && rb != carrier._rigidbody)
        {
            carrier.Add(rb);
        }
    }

    void OnTriggerExit(Collider ob)
    {
        Rigidbody rb = ob.GetComponent<Rigidbody>();
        if (rb != null && rb != carrier._rigidbody)
        {
            carrier.Remove(rb);
        }
    }
}
