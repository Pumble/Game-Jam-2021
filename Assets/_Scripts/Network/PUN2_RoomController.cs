using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// USING AGREGADOS
using Photon.Pun;
using System;

namespace Pun2Demo
{
    /* REFERENCIA 
     * ONLINE: https://sharpcoderblog.com/blog/make-a-multiplayer-game-in-unity-3d-using-pun-2
     * ASIGNAR OBJETO COMO HIJO DE OTRO: https://answers.unity.com/questions/478051/how-to-add-child-gameobjects-to-parent-in-script.html
     * OBTENER LA MAIN CAMERA: https://forum.unity.com/threads/script-of-camera-as-a-child-of-player.427287/
     */

    public class PUN2_RoomController : MonoBehaviourPunCallbacks
    {
        //Player instance prefab, must be located in the Resources folder
        [Header("Si algún prefab no se encuentra, se utiliza este")]
        public GameObject defaultPrefab;
        [Header("Arrays de prefabs que se utilizarán en las partidas online")]
        public List<GameObject> playerPrefabs;

        //Player spawn point
        [Header("Spawn point para los duendes")]
        public Transform CasaDuendes;
        [Header("Spawn point para la familia")]
        public Transform CasaFamilia;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        // Start is called before the first frame update
        void Start()
        {
            //In case we started this demo with the wrong scene being active, simply load the menu scene
            if (PhotonNetwork.CurrentRoom == null)
            {
                Debug.Log("Is not in the room, returning back to Lobby");
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameLobby");
                return;
            }

            //We're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
            CharacterOptions selectedCharacter = (CharacterOptions)PhotonNetwork.LocalPlayer.TagObject;

            GameObject character = null;
            foreach (GameObject c in playerPrefabs)
            {
                if (c.GetComponent<Player>().characterType == selectedCharacter)
                {
                    character = c;
                    break;
                }
            }
            if (character == null)
                character = defaultPrefab;

            // SELECCIONAR DONDE DEBE HACER EL PRIMER SPAWN
            Transform spawnPoint = null;
            if (selectedCharacter == CharacterOptions.kid || selectedCharacter == CharacterOptions.mom || selectedCharacter == CharacterOptions.dad)
                spawnPoint = CasaFamilia;
            else if (selectedCharacter == CharacterOptions.rat || selectedCharacter == CharacterOptions.geko || selectedCharacter == CharacterOptions.cockroach)
                spawnPoint = CasaDuendes;
            else
                spawnPoint = GetComponent<Transform>(); // En caso de que todo falle, sale en el 0.0.0
            GameObject player = PhotonNetwork.Instantiate(character.name, spawnPoint.position, Quaternion.identity, 0);
            player.GetComponent<Player>().ReSpawnPoint = spawnPoint; // ASIGNAR EL PUNTO DE SPAWN CORRESPONDIENTE

            // ASIGNAR LA CAMARA AL JUGADOR
            if (_camera != null && player != null)
            {
                _camera.GetComponent<CameraFollow2D>().target = player.transform;
            }
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("OnJoinedRoom CCCCCCCCCCCCCCCCCCCCC");
        }

        #region OVERRIDES

        public override void OnLeftRoom()
        {
            //We have left the Room, return back to the GameLobby
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameLobby");
        }

        #endregion

        #region UI

        void OnGUI()
        {
            if (PhotonNetwork.CurrentRoom == null)
                return;

            //Leave this Room
            if (GUI.Button(new Rect(5, 5, 125, 25), "Leave Room"))
            {
                PhotonNetwork.LeaveRoom();
            }

            //Show the Room name
            GUI.Label(new Rect(135, 5, 200, 25), PhotonNetwork.CurrentRoom.Name);

            //Show the list of the players connected to this Room
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {
                //Show if this player is a Master Client. There can only be one Master Client per Room so use this to define the authoritative logic etc.)
                string isMasterClient = (PhotonNetwork.PlayerList[i].IsMasterClient ? ": MasterClient" : "");
                string characterType = null;
                try
                {
                    characterType = "(" + (CharacterOptions)PhotonNetwork.PlayerList[i].TagObject + ")";
                }
                catch (Exception e)
                {
                    characterType = "";
                }
                finally
                {
                    GUI.Label(new Rect(5, 35 + 30 * i, 200, 25), PhotonNetwork.PlayerList[i].NickName + isMasterClient + characterType);
                }
            }
        }

        #endregion

        #region RPCs

        #endregion
    }
}