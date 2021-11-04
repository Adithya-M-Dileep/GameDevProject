using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class playerNameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInput;

    private void Start()
    {
        if(PlayerPrefs.HasKey("username"))
        {
            usernameInput.text = PlayerPrefs.GetString("username");
            

        }
        else
        {
            usernameInput.text = "player" + Random.Range(0, 10000).ToString("0000");
            
        }
        onUsernameInputValueChange();
    }
    public void onUsernameInputValueChange()
    {
        PhotonNetwork.NickName = usernameInput.text;
        PlayerPrefs.SetString("username", usernameInput.text);
    }
}
