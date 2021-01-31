using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarDisparadorConMouse : MonoBehaviour
{
    private Vector3 mousePosicion, objetoPosicion;
    private float angulo;

    private void Update()
    {
        mousePosicion = Input.mousePosition;
        objetoPosicion = Camera.main.WorldToScreenPoint(transform.position);

        angulo = Mathf.Atan2((mousePosicion.y - objetoPosicion.y), (mousePosicion.x - objetoPosicion.x)) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0,0,angulo));
    }

    // codigo de https://www.youtube.com/watch?v=Qkh2IZoUNJo
}
