using System;
using UnityEngine.SceneManagement;

public static class DataHolder
{
    public static Item[] items;

    /*
    private static int prGold;

    public static int gold
    {
        get => prGold;
        set => prGold = value;
    }
    */

    public static int gold;
    public static int killedEnemy;
    
    public static float walkedDistance;
    public static DateTime startTime;

    public static void LoadStore()
    {
        SceneManager.LoadSceneAsync("Scenes/Store", LoadSceneMode.Single);
    }
    
    public static void LoadGameplay()
    {
        SceneManager.LoadSceneAsync("Scenes/Gameplay", LoadSceneMode.Single);
    }

    public static void ClearValues()
    {
        gold = 0;
        killedEnemy = 0;
        items = null;
        walkedDistance = 0;
        startTime = DateTime.Now;
    }
}