using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoomTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject spawnpoints;

    RoomInformation roomInfo;
    RoomGenerator roomGenerator;

    void Start()
    {
        roomGenerator = GameObject.Find("RoomGenerator").GetComponent<RoomGenerator>();
        roomInfo = GetComponent<RoomInformation>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            roomGenerator.GenerateRooms(spawnpoints, roomInfo.entrances);
        }
    }
}
