using UnityEngine;
using System.Collections;

/**
 * Properties have different names
 * Properties have different values
 *
 **/

public class Property : MonoBehaviour {

    private string sOwnedBy = "";
    public string g_sOwnedBy { get { return sOwnedBy; } set { sOwnedBy = value; } }

    private int iValue = 0;
    public int g_iValue { get { return iValue; } }

    void Start()
    {
        if (gameObject.name == "Mediterranean Avenue")
            iValue = 60;
        if (gameObject.name == "Baltic Avenue")
            iValue = 60;

        if (gameObject.name == "Reading Railroad")
            iValue = 200;

        if (gameObject.name == "Oriental Avenue")
            iValue = 100;
        if (gameObject.name == "Vermont Avenue")
            iValue = 100;
        if (gameObject.name == "Connecticut Avenue")
            iValue = 120;

        if (gameObject.name == "St. Charles Place")
            iValue = 140;

        if (gameObject.name == "Electric Company")
            iValue = 150;

        if (gameObject.name == "States Avenue")
            iValue = 140;
        if (gameObject.name == "Virginia Avenue")
            iValue = 160;

        if (gameObject.name == "Pennsylvania Railroad")
            iValue = 200;

        if (gameObject.name == "St. James Place")
            iValue = 180;
        if (gameObject.name == "Tennessee Avenue")
            iValue = 180;
        if (gameObject.name == "New York Avenue")
            iValue = 200;

        if (gameObject.name == "Kentucky Avenue")
            iValue = 220;
        if (gameObject.name == "Indiana Avenue")
            iValue = 220;
        if (gameObject.name == "Illinois Avenue")
            iValue = 240;

        if (gameObject.name == "B. & O. Railroad")
            iValue = 200;

        if (gameObject.name == "Atlantic Avenue")
            iValue = 260;
        if (gameObject.name == "Ventnor Avenue")
            iValue = 260;

        if (gameObject.name == "Water Works")
            iValue = 150;

        if (gameObject.name == "Marvin Gardens")
            iValue = 300;

        if (gameObject.name == "Pacific Avenue")
            iValue = 300;
        if (gameObject.name == "North Carolina Avenue")
            iValue = 300;
        if (gameObject.name == "Pennsylvania Avenue")
            iValue = 320;

        if (gameObject.name == "Short Line")
            iValue = 200;

        if (gameObject.name == "Park Place")
            iValue = 350;
        if (gameObject.name == "Boardwalk")
            iValue = 400;
    }
}
