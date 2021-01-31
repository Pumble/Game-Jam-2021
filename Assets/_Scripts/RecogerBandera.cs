﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pun2Demo;

public class RecogerBandera : MonoBehaviour
{
    public static bool tieneBandera = true;

    public static AudioSource sound;
    public List<AudioClip> audios = new List<AudioClip>();

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Player") || collision.CompareTag("enemyPlayer")) && !GameObject.Find(collision.name).GetComponent<Player>().tieneBandera)
        {
            GameObject.Find(collision.name).GetComponent<Player>().tieneBandera = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("Tiene Bandera");
            int audioIndex = Random.Range(0, audios.Count - 1);
            sound.PlayOneShot(audios[audioIndex]);
        }
    }

    #region DEBUG

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));
    }

    #endregion
}
