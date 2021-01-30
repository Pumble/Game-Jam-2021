using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pun2Demo;

public class RecogerBandera : MonoBehaviour
{
    public static bool tieneBandera = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !GameObject.Find(collision.name).GetComponent<PlayerMovement>().getTieneBandera())
        {
            GameObject.Find(collision.name).GetComponent<PlayerMovement>().setTieneBandera(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("Tiene Bandera");
        }
    }
}
