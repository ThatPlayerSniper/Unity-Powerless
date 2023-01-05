using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] topRooms;
    public GameObject[] downRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public Dictionary<string, GameObject[]> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    void Start()
    {
        rooms = new Dictionary<string, GameObject[]>()
        {
            { "TOP", topRooms },
            { "DOWN", downRooms },
            { "LEFT", leftRooms },
            { "RIGHT", rightRooms }
        };
    }
}
