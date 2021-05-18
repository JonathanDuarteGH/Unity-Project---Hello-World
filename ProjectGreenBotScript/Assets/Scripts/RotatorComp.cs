using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorComp : MonoBehaviour
{
    [Header("Rotational Controls")]

    [Tooltip("The axis whic the GameObject is rotating")]
    [SerializeField]
    private Vector3 rotationalAxis = Vector3.up;

    [Tooltip("Speed of rotation in degrees/frame")]
    [SerializeField]
    private float rotationalSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationalAxis, rotationalSpeed);
    }
}
