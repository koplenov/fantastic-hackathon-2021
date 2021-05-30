using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DailyQuest : MonoBehaviour
{
    private bool _isOpen;
    
    public GameObject dailys;
    
    public Text description1; 
    public Text progress1;
    
    public Text description2; 
    public Text progress2;
    
    public Text description3; 
    public Text progress3;

    public static DailyStruct curentDaily1;
    public static DailyStruct curentDaily2;
    public static DailyStruct curentDaily3;
    
    //Дейлики
    public DailyStruct[] dailyStructs;

    private void Awake()
    {
        int first = Random.Range(4, 13);
        int second = Random.Range(4, 15);
        int third = Random.Range(200, 1280);
        int fourd = Random.Range(4, 8);
        
        
        dailyStructs =  new []
        {
            new DailyStruct("Убейте " + first + " мобов", 0, 0, first),
            new DailyStruct("Соберите " + second + " монеток", 0, 1, second),
            new DailyStruct("Пройти " + third + " метров", 0, 2, third),
            new DailyStruct("Проведите в игре некоторое время", 0, 3, fourd),
            new DailyStruct("Найдите легендарный предмет", 0, 4, 0),
            new DailyStruct("Прокачайте персонажа до 7го уровня", 0, 5, 7),
        };
        
        
        DataHolder.ClearValues();
        
        RandomDaily();
        
        ShowDaily();
    }

    private void RandomDaily()
    {
        //Создание объекта для генерации чисел
        System.Random rnd = new System.Random();
 
        //Получить случайное число (в диапазоне от 0 до 10)
        int index = rnd.Next(0, dailyStructs.Length);

        switch (index)
        {
            case 0: // 5  0  1
                curentDaily1 = dailyStructs[5];
                description1.text = curentDaily1.description;
                progress1.text = curentDaily1.progress.ToString();
                
                curentDaily2 = dailyStructs[0];
                description2.text = curentDaily2.description;
                progress2.text = curentDaily2.progress.ToString();
                
                curentDaily3 = dailyStructs[1];
                description3.text = curentDaily3.description;
                progress3.text = curentDaily3.progress.ToString();
                break;
            
            case 1: // 5 1 2
                curentDaily1 = dailyStructs[5];
                description1.text = curentDaily1.description;
                progress1.text = curentDaily1.progress.ToString();
                
                curentDaily2 = dailyStructs[1];
                description2.text = curentDaily2.description;
                progress2.text = curentDaily2.progress.ToString();
                
                curentDaily3 = dailyStructs[2];
                description3.text = curentDaily3.description;
                progress3.text = curentDaily3.progress.ToString();
                break;
            
            case 2: // 3 2 4
                curentDaily1 = dailyStructs[3];
                description1.text = curentDaily1.description;
                progress1.text = curentDaily1.progress.ToString();
                
                curentDaily2 = dailyStructs[2];
                description2.text = curentDaily2.description;
                progress2.text = curentDaily2.progress.ToString();
                
                curentDaily3 = dailyStructs[4];
                description3.text = curentDaily3.description;
                progress3.text = curentDaily3.progress.ToString();
                break;
            
            case 3: // 5 4 0
                curentDaily1 = dailyStructs[5];
                description1.text = curentDaily1.description;
                progress1.text = curentDaily1.progress.ToString();
                
                curentDaily2 = dailyStructs[4];
                description2.text = curentDaily2.description;
                progress2.text = curentDaily2.progress.ToString();
                
                curentDaily3 = dailyStructs[0];
                description3.text = curentDaily3.description;
                progress3.text = curentDaily3.progress.ToString();
                break;   
            
            case 4: // 1  4  0
                curentDaily1 = dailyStructs[1];
                description1.text = curentDaily1.description;
                progress1.text = curentDaily1.progress.ToString();
                
                curentDaily2 = dailyStructs[4];
                description2.text = curentDaily2.description;
                progress2.text = curentDaily2.progress.ToString();
                
                curentDaily3 = dailyStructs[0];
                description3.text = curentDaily3.description;
                progress3.text = curentDaily3.progress.ToString();
                break;   
            
            case 5: // 0  3  5
                curentDaily1 = dailyStructs[0];
                description1.text = curentDaily1.description;
                progress1.text = curentDaily1.progress.ToString();
                
                curentDaily2 = dailyStructs[3];
                description2.text = curentDaily2.description;
                progress2.text = curentDaily2.progress.ToString();
                
                curentDaily3 = dailyStructs[5];
                description3.text = curentDaily3.description;
                progress3.text = curentDaily3.progress.ToString();
                break;
            
        }

        StartCoroutine(UpdateDaily());
    }


    #region stats

    public Text killedEnemy;
    public Text walked;
    public Text time;

    #endregion
    
    public void CheckDailyProgress()
    {
        killedEnemy.text = "Аннигилировано мобов: " + DataHolder.killedEnemy; 
        walked.text = "Пройдено: " + DataHolder.walkedDistance + " метров"; 
        time.text = "Текущая сессия: " + (DateTime.Now - DataHolder.startTime).Minutes + " минут"; 
        
        switch (curentDaily1.type)
        {
            case 0: /// 0 - убить мобов
                if (DataHolder.killedEnemy >= curentDaily1.need)
                {
                    progress1.text = "Выполнено!";
                }
                else
                    progress1.text = DataHolder.killedEnemy.ToString();
                break;
            
            case 1: /// 1 - собрать n монеток
                if (DataHolder.gold >= curentDaily1.need)
                {
                    progress1.text = "Выполнено!";
                }
                else
                    progress1.text = "Собрано " + DataHolder.gold + Numeric(DataHolder.gold) + " из " + curentDaily1.need;
                break;
            
            case 2: /// 2 - Пройдите n метров
                if (DataHolder.walkedDistance >= curentDaily1.need)
                {
                    progress1.text = "Выполнено!";
                }
                else
                    progress1.text = "Пройдено:" + (int)DataHolder.walkedDistance + " метров";
                break;
            
            case 3: /// 3 - Проведите в игре более n минут
                if ((DateTime.Now - DataHolder.startTime).Minutes >= curentDaily1.need)
                {
                    progress1.text = "Выполнено!";
                }
                else
                    progress1.text = "Прошло " + (DateTime.Now - DataHolder.startTime).Minutes + " минут из " + curentDaily1.need;
                break;
            
            case 4: /// 4 - Найдите легендарный предмет
                progress1.text = "???";
                break;
            
            case 5: /// 5 - Прокачайте персонажа до n го уровня
                progress1.text = (DataHolder.killedEnemy * 10) + " опыта получено" ;
                break;
        }
        switch (curentDaily2.type)
        {
            case 0: /// 0 - убить мобов
                if (DataHolder.killedEnemy >= curentDaily2.need)
                {
                    progress2.text = "Выполнено!";
                }
                else
                    progress2.text = DataHolder.killedEnemy.ToString();
                break;
            
            case 1: /// 1 - собрать n монеток
                if (DataHolder.gold >= curentDaily2.need)
                {
                    progress2.text = "Выполнено!";
                }
                else
                    progress2.text = "Собрано " + DataHolder.gold + Numeric(DataHolder.gold) + " из " + curentDaily2.need;

                break;
            case 2: /// 2 - Пройдите n метров
                if (DataHolder.walkedDistance >= curentDaily2.need)
                {
                    progress2.text = "Выполнено!";
                }
                else
                    progress2.text = "Пройдено:" + (int)DataHolder.walkedDistance + " метров";
                break;
            
            case 3: /// 3 - Проведите в игре более n минут
                if ((DateTime.Now - DataHolder.startTime).Minutes >= curentDaily2.need)
                {
                    progress2.text = "Выполнено!";
                }
                else
                    progress2.text = "Прошло " + (DateTime.Now - DataHolder.startTime).Minutes + " минут из " + curentDaily2.need;
                break;
            
            case 4: /// 4 - Найдите легендарный предмет
                progress2.text = "???";
                break;
            
            case 5: /// 5 - Прокачайте персонажа до n го уровня
                progress2.text = (DataHolder.killedEnemy * 10) + " опыта получено" ;
                break;
        }
        switch (curentDaily3.type)
        {
            case 0: /// 0 - убить мобов
                if (DataHolder.killedEnemy >= curentDaily3.need)
                {
                    progress3.text = "Выполнено!";
                }
                else
                    progress3.text = DataHolder.killedEnemy.ToString();
                break;
            
            case 1: /// 1 - собрать n монеток
                if (DataHolder.gold >= curentDaily3.need)
                {
                    progress3.text = "Выполнено!";
                }
                else
                    progress3.text = "Собрано " + DataHolder.gold + Numeric(DataHolder.gold) + " из " + curentDaily3.need;
                break;
            
            case 2: /// 2 - Пройдите n метров
                if (DataHolder.walkedDistance >= curentDaily3.need)
                {
                    progress3.text = "Выполнено!";
                }
                else
                    progress3.text = "Пройдено:" + (int)DataHolder.walkedDistance + " метров";
                break;
            
            case 3: /// 3 - Проведите в игре более n минут
                if ((DateTime.Now - DataHolder.startTime).Minutes >= curentDaily3.need)
                {
                    progress3.text = "Выполнено!";
                }
                else
                    progress3.text = "Прошло " + (DateTime.Now - DataHolder.startTime).Minutes + " минут из " + curentDaily3.need;
                break;
            
            case 4: /// 4 - Найдите легендарный предмет
                progress3.text = "???";
                break;
            case 5: /// 5 - Прокачайте персонажа до n го уровня
                progress3.text = (DataHolder.killedEnemy * 10) + " опыта получено" ;
                break;
        }

    }

    string Numeric(int number)
    {
        switch (number)
        {
            case 0:
                return " монет";
            case 1:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                return " монет";
            case 2:
            case 3:
            case 4:
                return " монеты";
            default:
                return "";
        }
    }

    IEnumerator UpdateDaily()
    {
        while(true)
        {
            CheckDailyProgress();
            yield return new WaitForSeconds(1f);
        }
    }

    #region UI
    public void ShowOrHideDaily()
    {
        if (_isOpen)
            HideDaily();
        else
            ShowDaily();
    }
    void ShowDaily()
    {
        _isOpen = true;
        dailys.SetActive(true);
    }
    void HideDaily()
    {
        _isOpen = false;
        dailys.SetActive(false);
    }
    #endregion
}

/// <summary>
/// 0 - убить мобов
/// 1 - собрать n монеток
/// </summary>
public class DailyStruct
{
    public string description; 
    public int progress;
    public int type; 
    public int need;
    public DailyStruct(string description, int progress, int type, int need)
    {
        this.description = description;
        this.progress = progress;
        this.type = type;
        this.need = need;
    }
}
