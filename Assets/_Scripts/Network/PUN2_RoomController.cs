using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// USING AGREGADOS
using Photon.Pun;
using System;

namespace Pun2Demo
{
    // REFERENCIA: https://sharpcoderblog.com/blog/make-a-multiplayer-game-in-unity-3d-using-pun-2

    public class PUN2_RoomController : MonoBehaviourPunCallbacks
    {
        //Player instance prefab, must be located in the Resources folder
        public GameObject defaultPrefab;
        public List<GameObject> playerPrefabs;
        //Player spawn point
        public Transform spawnPoint;

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
            Debug.Log("personaje seleccionado: " + selectedCharacter.ToString());

            GameObject character = null;
            foreach (GameObject c in playerPrefabs)
            {
                if (c.GetComponent<PlayerMovement>().characterType == selectedCharacter)
                {
                    character = c;
                    break;
                }
            }
            if (character == null)
                character = defaultPrefab;
            Debug.Log("personaje a mostrar: " + character.name);
            PhotonNetwork.Instantiate(character.name, spawnPoint.position, Quaternion.identity, 0);

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