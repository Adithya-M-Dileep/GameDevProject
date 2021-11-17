using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class roomListItem : MonoBehaviour
{
    
    [SerializeField] TMP_Text text;

    public RoomInfo info;
   public void setup(RoomInfo _info)
    {
        info = _info;
        text.text = _info.Name;
    }
    public void OnClick()
    {
        launcher.Instance.joinRoom(info);
    }
}
