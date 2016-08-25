using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
/**
 * A Player moves around the board according to their dice roll
 * A Player has money
 * A Player may buy a property
 **/

public class Player : MonoBehaviour {

    private int iPlayerRolled = 0;
    private int iCurrentPosition = 0;
    private int iTargetPosition = 0;
    private GameObject oDice1;
    private GameObject oDice2;
    private bool bMyTurn = false;
    public bool g_bTurn { get { return bMyTurn; } set { bMyTurn = value; } }
    private float fRollTimer = 0f;
    private float fRollRate = 1f;
    private Transform oMyTransform;
    private List<Transform> aMyProperties = new List<Transform>();
    private GameObject oBoardSpaces;
    private float fTurnTimer = 0f;
    private float fTurnRate = 2f;
    private int iMoney = 1500;
    private int iDiceRollCounter = 0;
    private int iTrips = 0;
    public int g_iTrips { get { return iTrips; } set { iTrips = value; } }
    private bool bPastGo = false;
    private string sPlayerStats = "";
    public string g_sPlayerStats { get { return sPlayerStats; } }
    private System.Text.StringBuilder sbPlayerResults = new System.Text.StringBuilder();
    public System.Text.StringBuilder g_sbPlayerResults { get { return sbPlayerResults; } }
    private System.Text.StringBuilder sbDiceResults = new System.Text.StringBuilder();
    private System.Text.StringBuilder sbPropertyResults = new System.Text.StringBuilder();
    private bool bSaveResults = false;
    public bool g_bSaveResults { get { return bSaveResults; } set { bSaveResults = value; } }
    private bool bRollDice = false;
    public bool g_bRollDice { get { return bRollDice; } set { bRollDice = value; } }


    void Start () {

        // Players start on the Go spot

        // Players start with $1500 money

        // Player with the highest roll starts first

        sbPlayerResults.Append(gameObject.name + "\n");
        sbDiceResults.Append("Dice:\t");
        sbPropertyResults.Append("Properties:\t");

        oDice1 = GameObject.Find("Dice1");
        oDice2 = GameObject.Find("Dice2");

        

        oMyTransform = gameObject.transform;

        oBoardSpaces = GameObject.Find("BoardSpaces");
   
    }

    private void checkIfNearGo()
    {
        if (iCurrentPosition >= 29 || iCurrentPosition <= 39)
        {
            if (iTargetPosition > 39)
            {
                iTargetPosition = iTargetPosition - 40;

                bPastGo = true;
            }
        }
    }

    // Change this so that the game object decides whose turn it is
    // Wait for sometime to pass then go
    private void turnSimulator()
    {
        fTurnTimer += Time.deltaTime;
        if (fTurnTimer > fTurnRate)
        {
            fTurnTimer = 0;

        }
    }

    private void rollSimulator()
    {
        fRollTimer += Time.deltaTime;
        if (fRollTimer > fRollRate)
        {

            fRollTimer = 0;

            iPlayerRolled = oDice1.GetComponent<Dice>().g_iDiceNumber + oDice2.GetComponent<Dice>().g_iDiceNumber;
            iTargetPosition = iCurrentPosition + iPlayerRolled;

            GameObject.Find("DebugRolled").GetComponent<Text>().text = gameObject.name + " rolled: " + iPlayerRolled;

            // Check to see if player is near Go 
            checkIfNearGo();

            Debug.Log("iTargetPosition " + iTargetPosition);
            //GameObject.Find("DebugTarget").GetComponent<Text>().text = "iTargetPosition " + iTargetPosition;
        }
    }

    private void move()
    {
        if (iPlayerRolled > 0)
        {
            float step = 10 * Time.deltaTime;

            oMyTransform.position = Vector3.MoveTowards(oMyTransform.position, oBoardSpaces.transform.GetChild(iTargetPosition).position, step);
            if (Vector3.Distance(oMyTransform.position, oBoardSpaces.transform.GetChild(iTargetPosition).position) <= 0.5)
            {
                //bMyTurn = false;
                bRollDice = false;

                // Update current position
                iCurrentPosition += iPlayerRolled;
                if (iCurrentPosition > 39)
                    iCurrentPosition = iTargetPosition;
                sbDiceResults.Append(iPlayerRolled + "\t" );
                iPlayerRolled = 0;
                //GameObject.Find("DebugCurrent").GetComponent<Text>().text = "iCurrentPosition " + iCurrentPosition;

                if (bPastGo == true)
                {
                    bPastGo = false;
                    // $200 Salary for passing Go
                    iMoney += 200;
                    iTrips++;
                }

                // Check if the player is on a property
                if (oBoardSpaces.transform.GetChild(iTargetPosition).GetComponent<Property>())
                {
                    // Check if the property does not have an owner
                    if (oBoardSpaces.transform.GetChild(iTargetPosition).GetComponent<Property>().g_sOwnedBy == "")
                    {
                        // Buy property if not owned and if player has enough money
                        if (iMoney - oBoardSpaces.transform.GetChild(iTargetPosition).GetComponent<Property>().g_iValue > 0)
                        {
                            iMoney -= oBoardSpaces.transform.GetChild(iTargetPosition).GetComponent<Property>().g_iValue;
                            oBoardSpaces.transform.GetChild(iTargetPosition).GetComponent<Property>().g_sOwnedBy = gameObject.name;
                            sbPropertyResults.Append(oBoardSpaces.transform.GetChild(iTargetPosition).GetComponent<Property>().name + "\t");

                        }
                    }
                    else
                    {

                    }
                }
            }
        }

    }


    void Update () {

        if (iTrips == 2)   // Save results to string
        {
            //GameObject.Find("Ticks").GetComponent<Text>().text = "iTrips " + iTrips;
            GameObject.Find(gameObject.name + "Button").GetComponent<Button>().interactable = false;
            iTrips++;
            sbPlayerResults.AppendLine(sbDiceResults.ToString());
            sbPlayerResults.AppendLine(sbPropertyResults.ToString());
            sbPlayerResults.AppendLine("Remaining Money:\t" + iMoney.ToString());
        }

        // If simulation is running player can roll the dice
        // If it is the players turn then roll dice
    
        if (bRollDice == true)
        {
            //GameObject.Find("Ticks").GetComponent<Text>().text = "iMoney " + iMoney;
            rollSimulator();
            // Move player x spaces on the game board
            move();
        }

        Debug.Log("iCurrentPosition " + iCurrentPosition);
        Debug.Log("iPlayerRolled " + iPlayerRolled);

    }
}
