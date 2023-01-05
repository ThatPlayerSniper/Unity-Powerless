using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject roomsParent;

    RoomTemplates roomTemplates;

    void Start()
    {
        roomTemplates = GetComponent<RoomTemplates>();
    }

    public void GenerateRooms(GameObject spawnpoints, List<string> entrances)
    {
        for (int i = 0; i < entrances.Count; i++)
        {
            string _spawnEntrance = null;

            switch (entrances[i])
            {
                case "TOP":
                    _spawnEntrance = "DOWN";
                    break;
                case "DOWN":
                    _spawnEntrance = "TOP";
                    break;
                case "LEFT":
                    _spawnEntrance = "RIGHT";
                    break;
                case "RIGHT":
                    _spawnEntrance = "LEFT";
                    break;
            }

            Transform _spawnPoint = null;
            GameObject _spawnRoom = null;

            foreach (Transform spawnpoint in spawnpoints.transform)
            {
                if (spawnpoint.CompareTag(entrances[i]))
                {
                    _spawnPoint = spawnpoint;
                }
            }

            foreach (KeyValuePair<string, GameObject[]> roomSets in roomTemplates.rooms)
            {
                if (roomSets.Key == _spawnEntrance)
                {
                    int _randomIndex = Random.Range(0, roomSets.Value.Length);
                    _spawnRoom = roomSets.Value[_randomIndex];
                }
            }

            if (_spawnRoom != null)
            {
                Vector3 _spawnPosition = new Vector3(
                    _spawnPoint.transform.position.x,
                    _spawnPoint.transform.position.y,
                    0
                );

                GameObject _newRoom = Instantiate(_spawnRoom, _spawnPosition, Quaternion.identity);
                RoomInformation _newRoomInfo = _newRoom.GetComponent<RoomInformation>();

                _newRoomInfo.entrances.Remove(_spawnEntrance);

                Debug.Log(_newRoom.transform.Find("SpawnPoints"));
                foreach (Transform _newSpawnpoint in _newRoom.transform.Find("SpawnPoints"))
                {
                    if (_newSpawnpoint.gameObject.CompareTag(_spawnEntrance))
                    {
                        Destroy(_newSpawnpoint.gameObject);
                    }
                }
            }
        }
    }
}
