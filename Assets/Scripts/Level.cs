using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level
{
    public enum LevelTypes
    {
        NONE,
        INTRO_SPLASH,
        MENU,
        CREDITS,
        OPTIONS,
        HIGHSCORES,
        LEVEL_1_PRE_CUTSCENE,
        LEVEL_1_DESCENT,
        LEVEL_1_REACTOR_PRE_CUTSCENE,
        LEVEL_1_REACTOR,
        LEVEL_1_CHASE_PRE_CUTSCENE,
        LEVEL_1_CHASE,
        LEVEL_1_POST_CUTSCENE,
		LEVEL_1,

        LEVEL_2,
        LEVEL_3,
        LEVEL_4,
        LEVEL_5,
        END_SEQUENCE,
		LEVEL_POINTCOUNT
    }


    [HideInInspector]
	public int ShotsFired = 30;

	[HideInInspector]
	public int ShotsHit = 5;
	
	[HideInInspector]
	public int DamageCount = 34;
	
	[HideInInspector]
	public int ShotsTaken = 2;
	
	[HideInInspector]
	public int Entities = 40;
	
	[HideInInspector]
	public int EntitiesKilled = 25;
	
	[HideInInspector]
	public float TotalTime = 0;
	
	[HideInInspector]
	public float StarTime = 0;

	public readonly int CryptoLocksToUnlock = 2; // Standard number of cryptolocks to unlock

	[HideInInspector]
	public int CryptoLocksUnlocked = 0;

	public bool checkCryptoLocks = false;

	public readonly string Name;
	public readonly string SceneName;

	private LevelTypes levelType = LevelTypes.NONE;


	public Level(LevelTypes levelType, string Name, string SceneName)
	{
			this.levelType = levelType;
			this.Name = Name;
			this.SceneName = SceneName;
	}

    public LevelTypes getLevelType()
    {
        return levelType;
    }


	public bool levelFinishedCriterionMet()
	{
			if (checkCryptoLocks)
			{
					if (CryptoLocksUnlocked < CryptoLocksToUnlock)
					{
//							Debug.Log("levelFinishedCriterionMet == false for level part [" + Name + "]. Unlocked [" + CryptoLocksUnlocked + "/" + CryptoLocksToUnlock + "]");
							return false;
					}
			}

			Debug.Log("levelFinishedCriterionMet == true for level part ["+Name+"]");

			return true;
	}
	
	public void reset()
	{
		ShotsFired = 0;
		ShotsHit = 0;
		ShotsTaken = 0;
		DamageCount = 0;
		EntitiesKilled = 0;
		TotalTime = 0;
		StarTime=0;
		CryptoLocksUnlocked=0;
	}
	


    public override string ToString()
    {
        return "Level   [" + levelType + "]";
    }
}
