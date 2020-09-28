using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsDisplay : MonoBehaviour
{
    public int points;
    Vector2 nativeSize = new Vector2(340, 180);
    public void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUIStyle style = new GUIStyle();
        style.fontSize = (int)(20.0f * ((float)Screen.width / (float)nativeSize.x));
        GUI.Label(new Rect(20, 20, 100, 100), "Points: " + PlayerPrefs.GetInt("Points", 0), style); //It displays the amount of coins that the player has collected through the entire duration that he has been playing this game.
        //It is like a storage that will keep increasing even if you close your computer.
    }
}
