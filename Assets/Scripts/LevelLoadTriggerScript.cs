using UnityEngine;
using System.Collections;

public class LevelLoadTriggerScript : MonoBehaviour {

    public Level.LevelTypes LevelToLoad = Level.LevelTypes.LEVEL_POINTCOUNT;
    private SceneControllerScript sceneController;


	// Use this for initialization
	void Start () {

        if (LevelToLoad == Level.LevelTypes.NONE)
        {
            Debug.LogError("No level to load");
        }

        sceneController = (SceneControllerScript)GameObject.Find("Main Camera").GetComponent("SceneControllerScript");

        if (sceneController == null)
        {
            Debug.LogError("Receiver is null!. Bad initialization.");
        }
    }


		void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.tag.Equals("player"))
        {
            Debug.Log("not player. Tag = " + collision.gameObject.tag+", collision = "+collision.gameObject.layer+" : "+collision.gameObject.name);
            return;
        }

        if (sceneController == null)
        {
            Debug.LogError("No SceneController!");
            return;
        }
		
		
        StartCoroutine("TriggerNextPart");
		
    }
	
	


    IEnumerator TriggerNextPart()
    {
        if (SceneControllerScript.levelCriterionMet())
        {
//	        HUDScript.showAreaCompleteInfoText();
	        yield return new WaitForSeconds(2);
			
			sceneController.endCurrentLevelAndLoadNextLevel(LevelToLoad);
            Debug.Log("Next LevelPart");
        }
        else
        {
//            HUDScript.showCryptolockInfoText();
//            Debug.Log("LEvel crit *NOT* MEt!");
        }


	}


}
