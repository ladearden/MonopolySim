using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine.UI;

/**
 * This is a simulated game of Monopoly
 * This game has 2 players and 2 dice.
 * This game has 28 properties
 * 
 **/

public class Game : MonoBehaviour {

    private GameObject oDice1;
    private GameObject oDice2;
    private string sPath = "";
    private float fTurnTimer = 0f;
    private float fTurnRate = 2f;
    private float fPlayer2TurnWindow = 10f;
    public enum Turn { Player1, Player2, End };
    private Turn eTurn;
    public Turn g_eTurn { get { return eTurn; } set { eTurn = value; } }
    private bool bDiceRolled = true;
    private float fRollTimer = 0f;
    private float fRollRate = 1f;


    void Start()
    {

        oDice1 = GameObject.Find("Dice1");
        oDice2 = GameObject.Find("Dice2");

        oDice1.GetComponent<Dice>().g_bRollDice = true;
        oDice2.GetComponent<Dice>().g_bRollDice = true;

   
        sPath = Application.dataPath + "\\Results.txt";

        if (!File.Exists(sPath))
        {
            File.WriteAllText(sPath, "Monopoly Simulation Results \n");
        }

        GameObject.Find("SaveButton").GetComponent<Button>().interactable = false;
        GameObject.Find("Player2Button").GetComponent<Button>().interactable = false;
    }

    public void SaveResults()
    {
        // Write results to file
        File.AppendAllText(sPath, gameObject.transform.GetChild(0).GetComponent<Player>().g_sbPlayerResults.ToString());
        File.AppendAllText(sPath, gameObject.transform.GetChild(1).GetComponent<Player>().g_sbPlayerResults.ToString());
        File.AppendAllText(sPath, "\n\n");
    }

    

    void rollDice(bool b)
    {
        oDice1.GetComponent<Dice>().g_bRollDice = b;
        oDice2.GetComponent<Dice>().g_bRollDice = b;
    }

    public void Player1()
    {
        gameObject.transform.GetChild(0).GetComponent<Player>().g_bRollDice = true;
        GameObject.Find("Player1Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Player2Button").GetComponent<Button>().interactable = true;
    }

    public void Player2()
    {
        gameObject.transform.GetChild(1).GetComponent<Player>().g_bRollDice = true;
        GameObject.Find("Player2Button").GetComponent<Button>().interactable = false;
        GameObject.Find("Player1Button").GetComponent<Button>().interactable = true;
    }

    void Update () {

        fTurnTimer += Time.deltaTime;
        if (fTurnTimer > 5)
        {
            fTurnTimer = 0;
            bDiceRolled = !bDiceRolled;
            gameObject.transform.GetChild(bDiceRolled ? 1 : 0).GetComponent<Player>().g_bRollDice = true;
        }


        if (gameObject.transform.GetChild(0).GetComponent<Player>().g_bRollDice == true)
        {
            GameObject.Find("Player2Button").GetComponent<Button>().interactable = false;
            GameObject.Find("Player1Button").GetComponent<Button>().interactable = true;
            rollDice(false);
        }
        else if (gameObject.transform.GetChild(1).GetComponent<Player>().g_bRollDice == true)
        {
            GameObject.Find("Player1Button").GetComponent<Button>().interactable = false;
            GameObject.Find("Player2Button").GetComponent<Button>().interactable = true;
            rollDice(false);
        }
        else
        {
            rollDice(true);
        }

        if (gameObject.transform.GetChild(0).GetComponent<Player>().g_iTrips >= 2
            && gameObject.transform.GetChild(1).GetComponent<Player>().g_iTrips >= 2)
        {
            gameObject.transform.GetChild(0).GetComponent<Player>().g_bRollDice = false;
            gameObject.transform.GetChild(1).GetComponent<Player>().g_bRollDice = false;
            GameObject.Find("SaveButton").GetComponent<Button>().interactable = true;
            rollDice(false);
        }


    }
}
