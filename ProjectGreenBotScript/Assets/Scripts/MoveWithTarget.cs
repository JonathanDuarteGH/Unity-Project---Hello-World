using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTarget : MonoBehaviour
{
    public bool useTriggerAsSensor = false;
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    Vector3 lastPosition;
    Transform _transform;
    [HideInInspector] public Rigidbody _rigidbody;

    void Start()
    {
        _transform = transform;
        lastPosition = _transform.position;
        _rigidbody = GetComponent<Rigidbody>();

        if (useTriggerAsSensor)
        {
            foreach (MoveWithTargetSensor sensor in GetComponentsInChildren<MoveWithTargetSensor>())
            {
                sensor.carrier = this;
            }
        }
    }   
    void LateUpdate()
    {
        if (rigidbodies.Count > 0)
        {
            for (int i = 0; i < rigidbodies.Count; i++)
            {
                Rigidbody rb = rigidbodies[i];
                Vector3 velocity = (_transform.position - lastPosition);
                rb.transform.Translate(velocity, _transform);
            }

        }

        lastPosition = _transform.position; 
    }

    void OnCollisionEnter(Collision c)
    {
        if (useTriggerAsSensor) return;

        Rigidbody rb = c.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Add(rb);
        }
    }

    void OnCollisionExit(Collision c)
    {
        if (useTriggerAsSensor) return;

        Rigidbody rb = c.collider.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Remove(rb);
        }
    }

    public void Add(Rigidbody rb)
    {
        if (!rigidbodies.Contains(rb))
        {
            rigidbodies.Add(rb);
        }
    }

    public void Remove(Rigidbody rb)
    {
        if (rigidbodies.Contains(rb))
        {
            rigidbodies.Remove(rb);
        }
    }
}
