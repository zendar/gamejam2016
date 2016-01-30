using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public enum EntityTypes
    {
        DEFAULT,
        GENERIC_DESTROYABLE, // WTF.. should we even have this?
        TURRET,



    }

    public enum EventTypes
    {
        OBJECT_DESTROYED,
        OBJECT_PICKEDUP,
        OBJECT_DAMAGED,
        PLAYER_KILLED
    }



    private Dictionary<EventTypes, List<GameObject>> Observers = new Dictionary<EventTypes,List<GameObject>>();



    public void AddObserver(GameObject go, EventTypes nt)
    {
        List<GameObject> gameObjects;

        if (Observers.TryGetValue(nt, out gameObjects))
        {
            gameObjects.Add(go);
            return;
        }

        gameObjects = new List<GameObject>();
        gameObjects.Add(go);
        Observers.Add(nt, gameObjects);
    }

    public void RemoveObserver(GameObject go, EventTypes nt)
    {
        List<GameObject> gameObjects;
        if (Observers.TryGetValue(nt, out gameObjects))
        {
            gameObjects.Remove(go);
            return;
        }

        Debug.Log("Could not find GameObject ["+go+"] to remove for EventType ["+nt+"]");

    }

    public void NotifyObservers(Message message)
    {
        if (message == null)
        {
            Debug.LogError("PostNotification: Message is null!");
            return;
        }


        List<GameObject> gameObjects;
        if (Observers.TryGetValue(message.eventType, out gameObjects))
        {
            if (gameObjects == null || gameObjects.Count == 0)
            {
                Debug.LogError("No observers for Event [" + message.eventType + "]");
                return;
            }

            // Looping backwards so we can remove stuff
            for (int i = gameObjects.Count-1; i >= 0; i--)
            {
                GameObject go = gameObjects[i];
                if (go == null) // why the fuck should it be?
                {
                    Debug.Log("Pruned/removed null observer for EventType [" + message.eventType + "]");
                    gameObjects.RemoveAt(i);
                    continue;
                }

                go.SendMessage("receiveMessage",message,SendMessageOptions.DontRequireReceiver);
                Debug.Log("Sending mssage to observer ["+go+"] for EventType [" + message.eventType + "]");
            }
            return;
        }

        Debug.Log("Could not find observers for EventType [" + message.eventType + "]");
    }





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    // Singleton variables and functions
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = (GameManager)GameObject.FindObjectOfType(typeof(GameManager));

                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "GameManager";
                    instance = (GameManager)container.AddComponent(typeof(GameManager));
                }
            }
            return instance;
        }
    }


}
