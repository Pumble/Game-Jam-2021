using UnityEngine;

public enum CharacterOptions : int { kid = 0, mom = 1, dad = 2, geko = 3, rat = 4, cockroach = 5 };

public class Player : MonoBehaviour
{
    [Header("Solo informacion logica")]
    public bool tieneBandera = false;
    [Header("Cantidad de salud del personaje")]
    public float vida = 100f;
    [Header("Lista de personajes disponibles para jugar, establece el tipo del prefab")]
    public CharacterOptions characterType;
    [Header("Punto al que regresa el personaje al morir")]
    public Vector3 ReSpawnPoint;
}
