using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUDScript : MonoBehaviour {

    public GUIText InfoTextPrefab;

    public Texture HealthbarTexture;

    public Texture InfobarLeft;
    public Texture InfobarLeftTile;
    public Texture InfobarCenter;
    public Texture InfobarRight;
    public Texture InfobarRightTile;
    public Texture LivesTexture;


    private int FuelAndHealthbarWidth = 270;
    public GUISkin guiskin;  

    public GameObject GetReadyAnim;

    // Info text stuff
    private static bool showInfo = false;
    private static double showInfoTimestamp = -1;
    private GUIText showInfoGuiText = null;
    private static string showInfoTextString = "";
	private static bool quickInfo = false;


    // InfoTexts
    private const string GETREADY_INFO_TXT = "GET READY";
    private const string GAMEOVER_INFO_TXT = "GAME OVER";
    private const string YOUDIED_INFO_TXT = "YOU DIED.. HOW UNCOOL!";
    private const string NO_MORE_FUEL_YOUDIED_INFO_TXT = "NO MORE FUEL.. HAHA! YOU DIED.";
    private const string CRYPTOLOCK_INFO_TXT = "All cryptolocks must be unlocked!";
    private const string REFUELING_INFO_TXT = "..:Refueling:..";
    private const string AREA_COMPLETE_INFO_TXT = "..:Area Complete:..";




	// Use this for initialization
	void Start () {

        if (InfoTextPrefab == null)
        {
            Debug.LogError("HUD needs infotext prefab!");
            return;
        }

//        if (GetReadyAnim != null)
        {
            showGetReadyInfoText();
        }

    }

	// Update is called once per frame
	void Update () {
    }

    void OnGUI()
    {
        //UpdateGuiBackground();
        UpdateHudBackgroundGraphics();
        UpdateHealthGraphics();
        UpdateLivesGraphics();

        UpdateScoreText();
        UpdateCryptolockText();
		UpdateTimeText();

//		UpdateBoostBar();

        checkInfoText();
		
    }

    public int ProgressbarWidth = 120;
    public int ProgressbarHeight = 20;
    public Texture ProgressbarTexture;
    public Texture ProgressbarBKGTexture;


	
	void UpdateBoostBar()
	{
		if (GameDataScript.BOOST_TIME <=0)
			return;
		
		
        GUI.Label(new Rect(15, 20, 200, 20), "charge:", guiskin.customStyles[2]);

		
        if (ProgressbarBKGTexture == null || ProgressbarTexture == null)
            return;


        int percent = (int)((GameDataScript.BOOST_TIME / GameDataScript.BOOST_TIME_MAX) * ProgressbarWidth);

        int posX = 110;
        int posY = 25;

        GUI.DrawTexture(new Rect(posX-1, posY-1, ProgressbarWidth + 2, ProgressbarHeight + 2), ProgressbarBKGTexture, ScaleMode.ScaleAndCrop, true, 0.0F);

        GUI.BeginGroup(new Rect(posX, posY, percent, 20));
        GUI.DrawTexture(new Rect(0, 0, ProgressbarWidth, ProgressbarHeight), ProgressbarTexture, ScaleMode.ScaleAndCrop, true, 0.0F);
        GUI.EndGroup();


	}


    void UpdateScoreText()
    {
        int tempscore = GameDataScript.score;
        int offset = 0;
        for (int i = 0; i < 10;i++)
        {
            tempscore = tempscore / 10;
            if (tempscore >= 10)
            {
                offset += 16;
            }
        }

        GUI.Label(new Rect(Screen.width / 2 - offset, Screen.height - 32, 200, 32), "" + GameDataScript.score, guiskin.customStyles[0]);
    }

    void UpdateCryptolockText()
    {
        int unlocked = SceneControllerScript.getCurrentLevelCryptolocksUnlocked();
        int toUnlock = SceneControllerScript.getCurrentLevelCryptolocksToUnlock();
        


        GUI.Label(new Rect(310, Screen.height - 32, 200, 32), "" + unlocked + "/"+toUnlock , guiskin.customStyles[0]);
    }

    public static void showRefuleingInfoText()
    {
        showInfoTextString = REFUELING_INFO_TXT;
        triggerShowInfo();
		quickInfo = true;
    }

    public static void showCryptolockInfoText()
    {
        showInfoTextString = CRYPTOLOCK_INFO_TXT;
        triggerShowInfo();
    }

    public static void showGetReadyInfoText()
    {
        showInfoTextString = GETREADY_INFO_TXT;
        triggerShowInfo();
    }

    public static void showGameoverinfoText()
    {
        showInfoTextString = GAMEOVER_INFO_TXT;
        triggerShowInfo();
    }

    public static void showYouDiedInfoText()
    {
        showInfoTextString = YOUDIED_INFO_TXT;
        triggerShowInfo();
    }

    public static void showNoMoreFuelYouDiedInfoText()
    {
        showInfoTextString = NO_MORE_FUEL_YOUDIED_INFO_TXT;
        triggerShowInfo();
    }


	public static void showAreaCompleteInfoText()
    {
        showInfoTextString = AREA_COMPLETE_INFO_TXT;
        triggerShowInfo();
    }

	public static void showWeaponDowngradedInfoText()
    {
        showInfoTextString = "Weapons discharged";
        triggerShowInfo();
    }

	public static void showWeaponUpgradedInfoText()
    {
		GameDataScript.WeaponTypes wt = GameDataScript.getWeaponType();
		string upgrade = "0";
		switch (wt)
		{
		case GameDataScript.WeaponTypes.UPGRADE1:
				upgrade = "1";
				break;
		case GameDataScript.WeaponTypes.UPGRADE2:
				upgrade = "2";
				break;
		case GameDataScript.WeaponTypes.UPGRADE3:
				upgrade = "3";
				break;
		}

        showInfoTextString = "Weapons upgraded to Level "+upgrade;
        triggerShowInfo();
    }

    private static void triggerShowInfo()
    {
        if (showInfo)
        {
            showInfoTimestamp = -1;
			quickInfo = false;
        }
        else
        {
            showInfo = true;
        }
    }


    void checkInfoText()
    {
        if (!showInfo)
            return;

        if (showInfoTimestamp == -1)
        {
            //// Instatiate new text, and set timestamp
            if (showInfoGuiText == null)
            {
                showInfoGuiText = Instantiate(InfoTextPrefab) as GUIText;
            }
            showInfoGuiText.anchor = TextAnchor.MiddleCenter;
            showInfoGuiText.alignment = TextAlignment.Center;
            showInfoGuiText.pixelOffset = new Vector2(0, 0);
            showInfoGuiText.transform.position = new Vector3(0.5f, 0.5f, 1);
            showInfoGuiText.text = showInfoTextString;
            showInfoTimestamp = Time.time;
//			Debug.Log("ShowInfo = "+showInfoTextString+", quickInfo="+quickInfo);
        }
		
		double stayTime = 2;
		if (quickInfo)
			stayTime = 0.2;
		
        if (showInfoTimestamp + stayTime < Time.time)
        {
            showInfo = false;
			quickInfo = false;
			
            showInfoTimestamp = -1;
            Destroy(showInfoGuiText);
            showInfoGuiText = null;
            return;
        }
        //else
        //{
        //    GetReadyGuiText.text = GETREADY_INFO_TXT + "[" + Time.time + "]";
        //}


    }

    
    
    
    
    void UpdateHudBackgroundGraphics()
    {
        int barWidth = 411;
        int centerWidth = 195;
        GUI.DrawTexture(new Rect((Screen.width - centerWidth) / 2, Screen.height - 64, 256, 64), InfobarCenter, ScaleMode.ScaleAndCrop, true, 0.0F);
        GUI.DrawTexture(new Rect(0, Screen.height - 128, 512, 128), InfobarLeft, ScaleMode.ScaleAndCrop, true, 0.0F);
        GUI.DrawTexture(new Rect(Screen.width - barWidth, Screen.height - 128, 512, 128), InfobarRight, ScaleMode.ScaleAndCrop, true, 0.0F);

        float width = 1+ ((Screen.width - centerWidth) / 2) - barWidth;
        if (width > 0)
        {
//            Debug.Log("width = " + width);

            GUI.DrawTexture(new Rect(barWidth, Screen.height - 32, width, 32), InfobarLeftTile, ScaleMode.StretchToFill, true, 0.0F);

            GUI.DrawTexture(new Rect(((Screen.width + centerWidth) / 2), Screen.height - 32, width, 32), InfobarRightTile, ScaleMode.StretchToFill, true, 0.0F);
        }

    
    }

    void UpdateHealthGraphics()
    {
        if (HealthbarTexture == null)
            return;

        int percent = (int)(FuelAndHealthbarWidth * ((float)GameDataScript.getHealth() / (float)GameDataScript.DEFAULT_HEALTH));

        GUI.BeginGroup(new Rect(Screen.width - FuelAndHealthbarWidth-8, Screen.height - 64, percent, 64));
        GUI.DrawTexture(new Rect(0,0, 512, 64), HealthbarTexture, ScaleMode.ScaleAndCrop, true, 0.0F);
        GUI.EndGroup();

    }

    void UpdateLivesGraphics()
    {
        if (GameDataScript.lives <= 0)
            return;

        float startPos = Screen.width - 411 + 32;

        for (int i = 0; i < GameDataScript.lives; i++)
        {
            GUI.DrawTexture(new Rect(startPos, Screen.height - 32, 32, 32), LivesTexture, ScaleMode.ScaleAndCrop, true, 0.0F);
            startPos += 20;
        }

    }

	void UpdateTimeText()
    {

		Level level = SceneControllerScript.getCurrentLevel();
		float totaltime = 0;
		if (level.TotalTime != 0)
		{
			totaltime = level.TotalTime;
		}
		else
		{
			totaltime = Time.time - level.StarTime;
		}

		int minutes = Mathf.FloorToInt(totaltime / 60F);
		int seconds = Mathf.FloorToInt(totaltime - minutes * 60);
		string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);


//		Debug.Log("Totaltime = "+totaltime+", nicestring = "+niceTime+", currentLevel = "+level+", time.time = "+Time.time+", LevelStartTime  ="+level.StarTime);

		GUI.Label(new Rect(Screen.width / 2 - 100, 20, 200, 32), "TIME "+niceTime, guiskin.customStyles[1]);
    }

}
