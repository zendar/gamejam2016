using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDataScript : MonoBehaviour {

	public static bool HelpEnabled = true;

	public const int DEFAULT_DAMAGE = 5;
	public const int TURRET_DAMAGE = 6;
	
	public const int DEFAULT_SCORE = 0;
	public const float DEFAULT_FUEL = 4000; //1000;
	public const int DEFAULT_HEALTH = 300; //100;
	public const int DEFAULT_LIVES = 3;
	
	public static int score = DEFAULT_SCORE;
	private static float health = DEFAULT_HEALTH;
    public static int lives = DEFAULT_LIVES;
    public enum WeaponTypes
    {
        NONE,
        NORMAL,
        UPGRADE1,
        UPGRADE2,
        UPGRADE3,
		WEAPONBOOST
    };

    private static int WEAPON_DAMAGE_NORMAL = 10;
    private static int WEAPON_DAMAGE_UPGRADE1 = 10;
    private static int WEAPON_DAMAGE_UPGRADE2 = 6;
    private static int WEAPON_DAMAGE_UPGRADE3 = 60;

    private static int WeaponDamage = WEAPON_DAMAGE_NORMAL;


    private static WeaponTypes WeaponType = WeaponTypes.NORMAL;
	public static float BOOST_TIME; 
	public const float BOOST_TIME_MAX = 5; 

    public static int cryptoLocks = 0;
	
	public static bool shieldOn = false; // If true then ship does not take damage
	
	public static bool checkForHighscore = false;
	
	
	public static GameObject PlayerShip;


    public static PlayerStates PlayerState;

    public enum PlayerStates
    {
        PLAYING,
        PAUSED,
        OUT_OF_FUEL,
        DEAD,
        GAME_OVER
    };
	
	
	public static void registerPlayerShip(GameObject pShip)
	{
		PlayerShip = pShip;
		Debug.Log("Registering PlayerShip");
	}

    public static WeaponTypes getWeaponType()
    {
        return WeaponType;
    }

    public static void setWeaponType(WeaponTypes wType)
    {
        WeaponType = wType;

        switch (WeaponType)
        {
            case WeaponTypes.NORMAL:
                WeaponDamage = WEAPON_DAMAGE_NORMAL;
                break;
            case WeaponTypes.UPGRADE1:
                WeaponDamage = WEAPON_DAMAGE_UPGRADE1;
                break;
            case WeaponTypes.UPGRADE2:
                WeaponDamage = WEAPON_DAMAGE_UPGRADE2;
                break;
            case WeaponTypes.UPGRADE3:
                WeaponDamage = WEAPON_DAMAGE_UPGRADE3;
                break;
            default:
                Debug.LogError("WeaponDamage ["+WeaponType+"] not supported. Using normal damage");
                WeaponDamage = WEAPON_DAMAGE_NORMAL;
                break;
        }
    }

    public static int getWeaponDamage()
    {
        return WeaponDamage;
    }



	
	public static int getHealth()
	{
		return (int)health;
	}
	
	public static void modifyHealth(float deltaHealth)
	{
		if (shieldOn && deltaHealth < 0)
		{
			// If shield on, then no damage taken
			return;
		}
		
		health+=deltaHealth;
		if (health <0)
		{
			health = 0;
		}
		
		if (health > DEFAULT_HEALTH)
		{
			health = DEFAULT_HEALTH;
		}
	}


	public static void resetOnLifeLost()
	{
		health = DEFAULT_HEALTH;
	}

	public static void resetOnGameOver()
	{
		health = DEFAULT_HEALTH;
		score = DEFAULT_SCORE;
		lives = DEFAULT_LIVES;
        cryptoLocks = 0;
		WeaponType = WeaponTypes.NORMAL;
		BOOST_TIME = 0;
	}
}
