using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vars : MonoBehaviour
{   
    public static int currentMenu = 0;//0 - main menu, 1 - gameplay menu, 2 - restart
    public static int mode = 0;//0 - standard mode, 1 - time mode
    public static int pause = 0;//1 - paused
    public static int numberOfRows = 20;
    public static int numberOfColumns = 10;
    public static int numberOfTiles = 0;
    public static bool canDestoryTiles = true;
    public static int combo = 0;
    public static int score = 0;
    public static int level = 0;
    public static int color = 3;
    public static int restart = 0;

    
    public static void RestartVariables() {
        pause = 0;
        numberOfRows = 20;
        numberOfColumns = 10;
        canDestoryTiles = true;
        combo = 0;
        score = 0;
        level = 0;
        color = 3;
    }
}
