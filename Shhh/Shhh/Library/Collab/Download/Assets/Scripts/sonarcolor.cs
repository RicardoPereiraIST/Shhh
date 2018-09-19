using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonarcolor : MonoBehaviour
{
    public Color edgeColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Environment"))
        {
            Renderer renderer = other.GetComponent<Renderer>();
            if(renderer != null)
                renderer.material.SetColor("_EdgeColor", edgeColor);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Environment"))
        {
            Renderer renderer = other.GetComponent<Renderer>();
            if (renderer != null)
            {
                if (renderer.material.HasProperty("_EdgeColor"))
                {
                    Color color = renderer.material.GetColor("_EdgeColor");

                    //For now its YELLOW, i will probably make a intersection property on the shader.
                    if (color == Color.white || color == edgeColor)
                    {
                        if (color == edgeColor) return;
                        renderer.material.SetColor("_EdgeColor", edgeColor);
                    } 
                    else
                        renderer.material.SetColor("_EdgeColor", Color.yellow);
            }
        }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Environment"))
        {
            Renderer renderer = other.GetComponent<Renderer>();
            if (renderer != null)
                renderer.material.SetColor("_EdgeColor", Color.white);

        }
    }
}
