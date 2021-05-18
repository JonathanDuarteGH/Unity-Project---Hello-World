using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPulse : MonoBehaviour
{
    [Header("Opacity Parameter")]
    public float maxOpacity, minOpacity, opacityStep;

    [Header("Renderer and Material Referances")]
    public MeshRenderer objectRenderer;
    public Material objectMaterial;

    private Color tempColor;

    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the mesh renderer attached to this object
        objectRenderer = gameObject.GetComponent<MeshRenderer>();
        objectMaterial = objectRenderer.material;

        tempColor = new Color(objectMaterial.color.r, objectMaterial.color.b, objectMaterial.color.b, objectMaterial.color.a);
    }

    // Update is called once per frame  
    void Update()
    {
        if (tempColor.a <= maxOpacity || tempColor.a >= maxOpacity)
        {
            opacityStep *= -1.0f;
        }
        tempColor.a += opacityStep;
        objectMaterial.SetColor("_Color", tempColor);
    }
}
