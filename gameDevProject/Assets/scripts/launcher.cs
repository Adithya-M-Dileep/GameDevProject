using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class launcher : MonoBehaviourPunCallbacks
{
    public static launcher Instance;

    private void Awake()
    {
        Instance = this;
    }


    [SerializeField] TMP_InputField createInputRoomName;
    [SerializeField] TMP_Text error;
    [SerializeField] TMP_Text roomName;
    [SerializeField] Transform roomListContent;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject roomListPrefab;
    [SerializeField] GameObject playerListPrefab;
    [SerializeField] GameObject startGameButton;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        MenuManaher.Instance.OpenMenu("Title");
        Debug.Log("Joined lobby");
        //PhotonNetwork.NickName = "player" + Random.Range(0, 1000).ToString("0000");
    }
    
    public void createRoom()
    {
        if(string.IsNullOrEmpty(createInputRoomName.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(createInputRoomName.text);
        MenuManaher.Instance.OpenMenu("Loading");

    }

    public override void OnJoinedRoom()
    {
        MenuManaher.Instance.OpenMenu("room");
        roomName.text = PhotonNetwork.CurrentRoom.Name;
        Player[] players = PhotonNetwork.PlayerList;

        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(playerListPrefab, playerListContent).GetComponent<playeListItem>().setup(players[i]);
        }
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        error.text = "Room creation failed , message :" + message;
        MenuManaher.Instance.OpenMenu("error");
    }

    public void leaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManaher.Instance.OpenMenu("Loading");
    }

    public void joinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManaher.Instance.OpenMenu("Loading");
        
    }

    public override void OnLeftRoom()
    {
        MenuManaher.Instance.OpenMenu("Title");
        MenuManaher.Instance.OpenMenu("Loading");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            Instantiate(roomListPrefab, roomListContent).GetComponent<roomListItem>().setup(roomList[i]);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListPrefab, playerListContent).GetComponent<playeListItem>().setup(newPlayer);
    }
    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
