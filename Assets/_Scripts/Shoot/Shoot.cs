using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // REFERENCIA: https://www.youtube.com/watch?v=Qkh2IZoUNJo
    public GameObject bullet;
    public float _distance;
    public bool shoot = true;

    // Start is called before the first frame update
    void Start()
    {
        _distance = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shoot)
        {
            shoot = false;
            Instantiate(bullet, transform.position, transform.rotation);
            StartCoroutine("coRoutineShoot");
        }
    }

    public void setDistance(float distance)
    {
        _distance = distance;
    }

    IEnumerator coRoutineShoot()
    {
        yield return new WaitForSeconds((float)0.33);
        shoot = true;
    }
}
