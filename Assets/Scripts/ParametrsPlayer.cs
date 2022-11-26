using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametrsPlayer : MonoBehaviour
{

    public int HealthPlayer
    {
        get
        {
            return health;
        }

        set
        {
            health += value;
        }
    }

    public int ExpPlayer
    {
        get
        {
            return expPlayer;
        }

        set
        {
            if (value > 0)
            {
                expPlayer += value;

                if(orderLvl == allLevels.Count)
                {
                    orderLvl -= 1;
                    lvlMax = true;
                }
                else if (expPlayer > allLevels[orderLvl] && lvlMax != true)
                {
                    expPlayer = 0;
                    lvlPlayer++;
                    orderLvl++;
                    lvlUP = true;
                }
            }
        }
    }

    public float speedPlayer
    {
        get
        {
            return speed;
        }
        set
        {
            if (value > 0)
                speed += value;
        }
    }

    public int evasionPlayer
    {
        get
        {
            return evasion;
        }
        set
        {
            if (value > 0)
                evasion += value;
        }
    }

    public int currentExpLvl
    {
        get
        {
            return allLevels[orderLvl];
        }
    }

    public int DamagePlayer
    {
        get
        {
            return damage;
        }

        set
        {
            if (value > 0)
                damage += value;
        }
    }

    public int ArmorPlayer
    {
        get
        {
            return armor;
        }

        set
        {
            if (value > 0)
                armor += value;
        }
    }

    public int LVLPlayer
    {
        get
        {
            return lvlPlayer;
        }

        set
        {
            if (value > 0 && value < 2)
                lvlPlayer = value;
        }
    }

    public bool LVLMax
    {
        get
        {
            return lvlMax;
        }
    }

    public static bool lvlUP; // Главное поле для остановки игры
    public static int currentLvlPlayer;
    public SettingsGame settingsGame;
    PlayerController playerController;
    UIPlayer uIPlayer;
    float speed = 2f;
    public ChoseSkill choseSkill;
    int health, expPlayer, damage, lvlPlayer, orderLvl, evasion, armor;
    List<int> allLevels = new List<int> { 100, 200, 300,400,500,600,700,800,900,1000 }; // первый уровень нужно вернуть 100 значение, вместо 10
    bool lvlMax;

    void Awake()
    {
        StartState();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Уровень игрока = " + lvlPlayer);
        currentLvlPlayer = orderLvl;

        if (lvlUP == true)
        {
            // Здесь вызов функции, либо тут же, ждать пока пользователь выберет навык
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            expPlayer += 100;
            ExpPlayer = expPlayer;
        }
    }

    void StartState()
    {
        speed = 2f;
        orderLvl = 0;
        health = 5;
        expPlayer = 0;
        lvlPlayer = 0;
        damage = 5;
        evasion = 0;
    }
}
