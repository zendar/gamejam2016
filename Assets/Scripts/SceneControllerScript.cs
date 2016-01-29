using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneControllerScript : GravityRunBase
{
//    public GameObject SpaceshipPrefab;

		private static Level.LevelTypes currentLevel = Level.LevelTypes.LEVEL_1;
		private static Level.LevelTypes lastLevel = Level.LevelTypes.LEVEL_1;

    private static Dictionary<Level.LevelTypes, Level> Levels = new Dictionary<Level.LevelTypes, Level>();
    public GameObject EndOfLevelInfo;
	
	public GameObject SpawnPoint;

	[SerializeField]
	private GameObject ShipExplodingPrefab;

    void Awake()
    {
//		Cursor.visible = false;
//        currentLevel = LevelTypes.LEVEL_1_DESCENT;
        SetupLevels();
		
    }

    // Use this for initialization
    void Start()
    {
        applyLevelFades();
		
		if (currentLevel != Level.LevelTypes.INTRO_SPLASH && currentLevel != Level.LevelTypes.NONE)
		{
			Debug.Log("CurrentLevel is = "+currentLevel);
		// Spawn the player
		spawnPlayerShip();

        GameManager.Instance.AddObserver(this.gameObject, GameManager.EventTypes.PLAYER_KILLED);
		}
    }


    public void receiveMessage(Message message)
    {
        Debug.Log("I got the message. Event = " + message.eventType + ", from GameObject [" + message.from + "]");
    }


    private void SetupLevels()
    {
        if (Levels.Count > 0)
		{
			return;
//			Levels.Clear();
		}

				Level l = new Level(Level.LevelTypes.LEVEL_1,"Descent","testbed_01");
		l.checkCryptoLocks = true;
        Levels.Add(l.getLevelType(), l);

		l = new Level(Level.LevelTypes.LEVEL_POINTCOUNT,"Pointcount","level_pointcount");
		l.checkCryptoLocks = true;
        Levels.Add(l.getLevelType(), l);
				
		l = new Level(Level.LevelTypes.LEVEL_2,"Descent2","testbed_02");
		l.checkCryptoLocks = true;
        Levels.Add(l.getLevelType(), l);
				
								
																/*		
//		LevelPart part = new LevelPart("Descent","level_01_descent");
		LevelPart part = new LevelPart("Descent","testbed_01");
		part.checkCryptoLocks = true;
		l.addPart(part);
		part = new LevelPart("Reactor","level_01_reactor");
		l.addPart(part);
		part = new LevelPart("Escape","level_01_chase");
		l.addPart(part);
		part = new LevelPart("Pointcount","level_pointcount");
		l.addPart(part);
/*		
		Level l = new Level(Level.LevelTypes.LEVEL_1_DESCENT);
        l.checkCryptoLocks = true;
        Levels.Add(l.getLevelType(), l);

        l = new Level(Level.LevelTypes.LEVEL_1_REACTOR);
        l.checkCryptoLocks = false;
        Levels.Add(l.getLevelType(), l);

        l = new Level(Level.LevelTypes.LEVEL_1_CHASE);
        l.checkCryptoLocks = false;
        Levels.Add(l.getLevelType(), l);
*/
        // Massive debug ball of wtf
        Debug.Log("LEVELS have been setup!");
        //foreach (KeyValuePair<LevelTypes, Level> pair in Levels)
        //{
        //    Debug.Log("[" + pair.Key + "," + pair.Value + "]");
        //}
        //Debug.Log("LEVELS have been setup!----END. l = "+l+", type = "+l.getLevelType());

    }
	
	
    public static void addEntity()
    {
        Level currLevel = Levels[currentLevel];
        if (currLevel == null)
            return;

        currLevel.Entities++;
    }

    public static void addEntityKilled()
    {
        Level currLevel = Levels[currentLevel];
        if (currLevel == null)
            return;
		currLevel.EntitiesKilled++; 

    }
	
    public static void addShotFired()
    {
        Level currLevel = Levels[currentLevel];
        if (currLevel == null)
            return;
		currLevel.ShotsFired++; 

    }
	
    public static void addShotHit()
    {
        Level currLevel = Levels[currentLevel];
        if (currLevel == null)
            return;
		currLevel.ShotsHit++; 

    }
	
	public static Level getCurrentLevel()
	{
		return Levels[currentLevel];
	}

	public static Level getLastLevel()
	{
		return Levels[lastLevel];
	}

    public static void addOpenedCryptoLock()
    {
        Level currLevel = Levels[currentLevel];
        if (currLevel == null)
            return;
		
		currLevel.CryptoLocksUnlocked++;
    }

    public static int getCurrentLevelCryptolocksUnlocked()
    {
        if (!Levels.ContainsKey(currentLevel))
            return 0;

        Level currLevel = Levels[currentLevel];

		return currLevel.CryptoLocksUnlocked;
    }


    public static int getCurrentLevelCryptolocksToUnlock()
    {
        if (!Levels.ContainsKey(currentLevel))
            return 0;

        Level currLevel = Levels[currentLevel];
		return currLevel.CryptoLocksToUnlock;
    }

    public void setStartTime()
    {
		if (!Levels.ContainsKey(currentLevel))
		{
			Debug.Log("Could not find level ["+currentLevel+"] to set StartTime");
		    return;
	    }

        Level currLevel = Levels[currentLevel];
		currLevel.StarTime = Time.time;
		Debug.Log("StartTime set to ["+currLevel.StarTime+"]  for level ["+currentLevel+"]");
	}    	
	


	public void startNewGame()
	{
        GameDataScript.resetOnGameOver();
		resetLevels();
		fadeOutAndLoadLevel(Level.LevelTypes.LEVEL_1);
	}


    public void loadLevel(Level.LevelTypes level)
    {
        Debug.Log("LoadLevel=" + level);

        lastLevel = currentLevel;
        currentLevel = level;
        //setup "Loading.." texture
        Application.LoadLevel(getlevelString(level)); // Load level
        // remove loading texture?
        //        Application.l
    }

	private float fadeTime = 1.2f;

    private void applyLevelFades()
    {
		
        Debug.Log("ApplyLevelFades for currentLevel [" + currentLevel + "]");
        switch (currentLevel)
        {
            case Level.LevelTypes.NONE:
                Debug.Log("do Nothing for level NONE");
                break;
            case Level.LevelTypes.INTRO_SPLASH:
                Debug.Log("FadeIn: "+currentLevel.ToString());
//                gameObject.SendMessage("startFadeIn", 2.0F);
                StartCoroutine(delayedFadeOut(3, Level.LevelTypes.MENU));
                break;
            case Level.LevelTypes.MENU:
                Debug.Log("FadeIn: "+currentLevel.ToString());
                gameObject.SendMessage("startFadeIn", fadeTime);
                break;
            case Level.LevelTypes.HIGHSCORES:
                Debug.Log("FadeIn: " + currentLevel.ToString());
                gameObject.SendMessage("startFadeIn", fadeTime);
                break;
            case Level.LevelTypes.LEVEL_1:
                Debug.Log("FadeIn: " + currentLevel.ToString());
//                gameObject.SendMessage("startFadeIn", 2.0F);
                break;
            case Level.LevelTypes.LEVEL_2:
                Debug.Log("FadeIn: " + currentLevel.ToString());
//                gameObject.SendMessage("startFadeIn", 2.0F);
                break;
            case Level.LevelTypes.LEVEL_POINTCOUNT:
                Debug.Log("FadeIn: " + currentLevel.ToString());
                gameObject.SendMessage("startFadeIn", fadeTime);
                break;
            default:
                break;

        }

    }
	
	public void loadNextLevelPart()
	{
	/*
		LevelPart part = Levels[currentLevel].getNextPart();
		if (part == null)
		{
			Debug.Log("NO PART FOR LEVEL FOUND!");
			return;
		}
		
		StartCoroutine(delayedFadeOut(0, currentLevel));
		*/

	}

    public void endCurrentLevelAndLoadNextLevel(Level.LevelTypes level)
    {
        StartCoroutine(delayedFadeOut(0, level));
//        StartCoroutine(EndLevelAndFadeout(0, level));
    }

	
	public void fadeOutAndLoadLevel(Level.LevelTypes level)
    {
        StartCoroutine(delayedFadeOut(0, level));
    }
	
	
	public void spawnPlayerShip()
	{
        GameObject newShip = null;

	}

    private IEnumerator EndLevelAndFadeout(int secs, Level.LevelTypes level)
    {
        AudioListener.pause = true;


		Instantiate(EndOfLevelInfo);
		
        yield return new WaitForSeconds(5);

//		Time.timeScale = savedTimeScale;
        AudioListener.pause = false;

		StartCoroutine(delayedFadeOut(0, level));
		
	}

    private IEnumerator delayedFadeOut(int secs, Level.LevelTypes level)
    {
//        Debug.Log("FadeOut in.." + secs + " secs");

        yield return new WaitForSeconds(secs);
//        Debug.Log("Runningrunning delayedFadeOut.. CONT");

        float fadeOutTime = fadeTime;
        gameObject.SendMessage("startFadeOut", fadeOutTime - 0.1f);
        yield return new WaitForSeconds(fadeOutTime);

		loadLevel(level);
    }



    public static bool levelCriterionMet()
    {
//        Debug.LogError("CurrentLevel = " + currentLevel);
        Level currLevel = Levels[currentLevel];
        if (currLevel == null)
        {
            Debug.LogError("No Level in map for currentLevel = " + currentLevel+". Levels.size = "+Levels.Count);

            foreach (KeyValuePair<Level.LevelTypes,Level> pair in Levels)
            {
                Debug.Log("["+pair.Key+","+pair.Value+"], type from Value = "+pair.Value.getLevelType());
            }

            return true;
        }
		
		Debug.Log("END OF LEVEL Entities ["+currLevel.Entities+"]. Killed ["+currLevel.EntitiesKilled+"]");
		
		bool levelDone = currLevel.levelFinishedCriterionMet();
		if (levelDone)
		{
			currLevel.TotalTime = Time.time - currLevel.StarTime;
			return true;
		}
		else
			return false;
    }

    private static string getlevelString(Level.LevelTypes level)
    {
        switch (level)
        {
            case Level.LevelTypes.LEVEL_1:
			return Levels[level].SceneName;
            case Level.LevelTypes.INTRO_SPLASH:
                return "gravityrun_intro_scene";
            case Level.LevelTypes.CREDITS:
                return "CreditsScene";
            case Level.LevelTypes.MENU:
                return "MainMenuScene";
            case Level.LevelTypes.HIGHSCORES:
                return "Highscores";
			case Level.LevelTypes.LEVEL_POINTCOUNT:
		        return "level_pointcount";
        }
        return "";
    }

    private Vector3 lastPlayerPosition;

    public void playerDied(GameObject spaceship, bool emptyFuel)
    {
        if (GameDataScript.lives < 0)
        {
            playerGameOver(spaceship);
            return;
        }

        lastPlayerPosition = spaceship.GetComponent<Rigidbody>().position;

        StartCoroutine(LifeLost(spaceship,emptyFuel));

    }



    private void playerGameOver(GameObject spaceship)
    {
        StartCoroutine("GameOver");
    }




    IEnumerator LifeLost(GameObject spaceship, bool emptyFuel)
    {
        if (!spaceship.GetComponent<NetworkView>().isMine)
        {
            Debug.Log("Not Mine. returning");
            yield return null;
        }

        Debug.Log("Life Lost. Empty Fuel = "+emptyFuel);
        GameDataScript.modifyFuel(-GameDataScript.getFuel());
		if (emptyFuel)
	        HUDScript.showNoMoreFuelYouDiedInfoText();
		else
	        HUDScript.showYouDiedInfoText();
			
        //        Instantiate(lifeLostText);

        GameObject exploder = null;
        if (Network.isClient || Network.isServer)
        {
            Network.Destroy(spaceship);
            exploder = Network.Instantiate(ShipExplodingPrefab, spaceship.transform.position, Quaternion.identity,0) as GameObject;
            GetComponent<Camera>().SendMessage("reAquireTarget", exploder);
            AudioManager.Play(AudioManager.Sounds.PLAYER_DIED_1);
//            AudioSource.PlayClipAtPoint(soundBoard.PlayerDied1, spaceship.transform.position);
        }
        else
        {
            GameObject.Destroy(spaceship);
            exploder = Instantiate(ShipExplodingPrefab, spaceship.transform.position, Quaternion.identity) as GameObject;
            GetComponent<Camera>().SendMessage("reAquireTarget", exploder);
            AudioManager.Play(AudioManager.Sounds.PLAYER_DIED_1);
			Debug.Log ("PLAY AUDIO PLEEEESE");
//            AudioSource.PlayClipAtPoint(soundBoard.PlayerDied1, spaceship.transform.position);
        }
		

		
        yield return new WaitForSeconds(1);

//		iTween.FadeTo(exploder, 0, 4);
			
        yield return new WaitForSeconds(4);

        GameDataScript.resetOnLifeLost();

        if (Network.isClient || Network.isServer)
        {
            Network.Destroy(exploder);
        }
        else
        {
            GameObject.Destroy(exploder);
        }
        yield return new WaitForSeconds(1);
		spawnPlayerShip();
        HUDScript.showGetReadyInfoText();
    }

    IEnumerator GameOver()
    {
        GameDataScript.modifyFuel(-GameDataScript.getFuel());
        HUDScript.showGameoverinfoText();
//        Instantiate(gameOverText);
        GetComponent<Camera>().SendMessage("PostHighscore");

        yield return new WaitForSeconds(8);
        GameDataScript.resetOnGameOver();
		resetLevels();
        GetComponent<Camera>().SendMessage("loadLevel", Level.LevelTypes.MENU);

        

        //		Application.LoadLevel(SceneControllerScript.LevelTypes.MENU); // Load start-level (main menu?)
    }
	
	
	private void resetLevels()
	{
		if (Levels.Count == 0)
			return;
		
		foreach (KeyValuePair<Level.LevelTypes,Level> pair in Levels)
		{
			pair.Value.reset();
		}
			
	}


//    Object[] PausedParticles = 
    public void PauseGame()
    {
        Object[] objects = FindObjectsOfType(typeof(ParticleEmitter));
        foreach (ParticleEmitter go in objects)
        {
            go.enabled = false;
        }        
    }

    public void UnpauseGame()
    {
        Object[] objects = FindObjectsOfType(typeof(ParticleEmitter));
        foreach (ParticleEmitter go in objects)
        {
            go.enabled = true;
        }
    }

	

}
