using UnityEngine;

public class PlayerSpawner : MonoBehaviour{
	void Start(){
		Player.Instance.transform.position = transform.position;
	}
}