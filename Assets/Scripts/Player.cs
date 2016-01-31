using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour{
	public List<string> relics = new List<string>();

	public AudioClip pickupClip;

	private static Player _instance;
	public static Player Instance {
		get{
			return _instance;
		}
	}

	void Awake(){
		_instance = this;
		SimpleCameraFollow.target = transform;
		DontDestroyOnLoad(gameObject);
	}

	void Start(){}

	public void PickUpRelic(string relic){
		relics.Add(relic);
		GetComponent<AudioSource>().clip = pickupClip;
		GetComponent<AudioSource>().Play();
		UIController.Instance.UpdateProgress(relics.Count);
	}

	void OnLevelWasLoaded(int level){
		relics = new List<string>();
	}
}