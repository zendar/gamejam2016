using UnityEngine;

public class LevelFirebolt : MonoBehaviour {
	public Unit slime;
	public GameObject door;

	public void Update(){
		if(slime == null && door != null){
			Destroy(door);
		}
	}
}