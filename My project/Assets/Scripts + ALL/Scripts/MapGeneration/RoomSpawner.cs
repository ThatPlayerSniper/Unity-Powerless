using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door


	public GameObject RoomTemplatesOBJ;
	public RoomTemplates templates;
	//private int rand;
	public bool spawned = false;
	public int rand;
	public float waitTime = 4f;

	void Start(){
		Destroy(gameObject, waitTime);
		Invoke("Spawn", 0.1f);

		templates = RoomTemplatesOBJ.GetComponent<RoomTemplates>();
	}


	void Spawn(){
		if(spawned == false){
			switch (openingDirection) { 
				case 1:
					// Need to spawn a room with a BOTTOM door.
						rand = Random.Range(0, 4);
						Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
					break; 
				case 2:
                    break;
				case 3:
                    break;
				case 4:
                    break;
			}
			
			/*
			if(openingDirection == 1){
			} else if(openingDirection == 2){
				// Need to spawn a room with a TOP door.
			    rand = Random.Range(0, templates.topRooms.Length);
				Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
			} else if(openingDirection == 3){
				// Need to spawn a room with a LEFT door.
				rand = Random.Range(0, templates.leftRooms.Length);
				Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
			} else if(openingDirection == 4){
				// Need to spawn a room with a RIGHT door.
			    rand = Random.Range(0, templates.rightRooms.Length);
				Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
			}
			*/

			spawned = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("SpawnPoint")){
			if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
				Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			} 
			spawned = true;
		}
	}
}
