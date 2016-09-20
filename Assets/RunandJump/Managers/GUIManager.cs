using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
	
	private static GUIManager instance;
    public static bool canStart, canOver;
    private bool gameStarted;
	public Text boostsText, distanceText, gameOverText, instructionsText, runnerText;
	
	void Start () {
		instance = this;
		//GameEventManager.GameStart += GameStart;
		//GameEventManager.GameOver += GameOver;
		gameOverText.enabled = false;

        canStart = false;
        canOver = false;
        gameStarted = false;
	}

	void Update () {
        if (canStart == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //GameEventManager.TriggerGameStart();
                gameStarted = true;
                canStart = true;

                gameOverText.enabled = false;
                instructionsText.enabled = false;
                runnerText.enabled = false;
                PlatformManager.canStart = true;
                SkylineManager.canStart = true;
                Runner.canStart = true;
                Runner.canOver = false;
                
            }
        }
        
        if(gameStarted == false)
        {
            gameOverText.enabled = true;
            instructionsText.enabled = true;
            runnerText.enabled = true;
        }
        if(gameStarted == true)
        {
            
            gameOverText.enabled = false;
            instructionsText.enabled = false;
            runnerText.enabled = false;
        }
        if(canOver == true)
        {
            gameStarted = false;
            canStart = false;
            canOver = false;
        }
	}
	
	private void GameStart () {
        /*
        gameOverText.enabled = false;
		instructionsText.enabled = false;
		runnerText.enabled = false;
		enabled = false;
        */
	}
	
	private void GameOver () {
        /*
        gameOverText.enabled = true;
		instructionsText.enabled = true;
		enabled = true;
        */
	}
	
	public static void SetBoosts(int boosts){
		instance.boostsText.text = boosts.ToString();
	}

	public static void SetDistance(float distance){
		instance.distanceText.text = distance.ToString("f0");
	}
}