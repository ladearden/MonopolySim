using UnityEngine;
using System.Collections;

/**
 * Dice are rolled by the player
 * Dice have the value between 1 and 6
 **/ 

public class Dice : MonoBehaviour {

    private int iDiceNumber = 0;
    private float fDiceTimer = 0f;
    private float fDiceRate = 0.08f;
    public Sprite[] oDiceTextures;
    private bool bRollDice = false;
    public bool g_bRollDice { get { return bRollDice; } set { bRollDice = value; } }
    public int g_iDiceNumber { get { return iDiceNumber; } set { iDiceNumber = value; } }
    private string sControl = "";
    public string g_sControl { get { return sControl; } set { sControl = value; } }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        bRollDice = g_bRollDice;

        if (bRollDice == true)
        {
            fDiceTimer += Time.deltaTime;
            if (fDiceTimer > fDiceRate)
            {
                fDiceTimer = 0;
                iDiceNumber = Random.Range(1, 7);
                g_iDiceNumber = iDiceNumber;


                if (iDiceNumber == 1)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = oDiceTextures[0];
                }
                if (iDiceNumber == 2)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = oDiceTextures[1];
                }
                if (iDiceNumber == 3)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = oDiceTextures[2];
                }
                if (iDiceNumber == 4)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = oDiceTextures[3];
                }
                if (iDiceNumber == 5)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = oDiceTextures[4];
                }
                if (iDiceNumber == 6)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = oDiceTextures[5];
                }
            }
        }
	}
}
