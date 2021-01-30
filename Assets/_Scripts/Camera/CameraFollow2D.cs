using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform Player;
    public float CameraDistance = 5.0f;

    private void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / CameraDistance);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(Player.position.x, Player.position.y);
    }
}
