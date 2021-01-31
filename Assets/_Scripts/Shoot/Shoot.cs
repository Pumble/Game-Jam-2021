using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// USING AGREGADOS
using Photon.Pun;

public class Shoot : MonoBehaviourPun
{
    // REFERENCIA: https://www.youtube.com/watch?v=Qkh2IZoUNJo
    public GameObject bullet;
    public float _distance;
    public bool shoot = true;

    public static AudioSource sound;
    public List<AudioClip> audios = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        _distance = 20f;
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetMouseButtonDown(0) && shoot)
            {
                shoot = false;
                // Instantiate(bullet, transform.position, transform.rotation);
                PhotonNetwork.Instantiate(bullet.name, transform.position, transform.rotation);
                StartCoroutine("coRoutineShoot");
            }
        }
    }

    public void setDistance(float distance)
    {
        _distance = distance;
    }

    IEnumerator coRoutineShoot()
    {
        yield return new WaitForSeconds((float)0.33);
        sound.PlayOneShot(audios[0]);
        shoot = true;
    }
}
