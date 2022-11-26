using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    // Damage 
    // Speed
    // Health
    // Evasion(уклонение %)
    // Armor

    Dictionary<string, int> listDamage = new Dictionary<string, int>()
{
    {"Damage_1", 1},
    {"Damage_2", 2},
    {"Damage_3", 3}
};

    Dictionary<string, int> listSpeed = new Dictionary<string, int>()
{
    {"Speed_1", 1},
    {"Speed_2", 2},
    {"Speed_3", 3}
};

    Dictionary<string, int> listHealth = new Dictionary<string, int>()
{
    {"Health_1", 2},
    {"Health_2", 4},
    {"Health_3", 6}
};

    Dictionary<string, int> listEvasion = new Dictionary<string, int>()
{
    {"Evasion_1", 10},
    {"Evasion_2", 20},
    {"Evasion_3", 30}
};

    Dictionary<string, int> listArmor = new Dictionary<string, int>()
{
    {"Armor_1",1},
    {"Armor_2",2},
    {"Armor_3",3}
};
    //List<int> listDamage = new List<int> { 1, 2, 3 };
    //List<int> listSpeed = new List<int> { 1, 2, 3 };
    //List<int> listHealth = new List<int> { 2, 4, 6 };
    //List<int> listEvasion = new List<int> { 10, 20, 40 };
    //List<int> listArmor = new List<int> { 1, 2, 3};
    public List<Dictionary<string, int>> listSkills = new List<Dictionary<string,int>>();

    void Start()
    {
        listSkills.Add(listDamage);
        listSkills.Add(listSpeed);
        listSkills.Add(listHealth);
        listSkills.Add(listEvasion);
        listSkills.Add(listArmor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
