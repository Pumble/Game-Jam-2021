using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    // REFERENCIA: https://www.youtube.com/watch?v=Qkh2IZoUNJo
    private Vector3 mousePosition, objectPosition;
    private float angle;

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        objectPosition = Camera.main.WorldToScreenPoint(transform.position);

        angle = Mathf.Atan2(mousePosition.y - objectPosition.y, mousePosition.x - objectPosition.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
