using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIPlayer : MonoBehaviour
{


    public int CountEnemy
    {
        set
        {
            countEnemy = value;   // устанавливаем новое значение свойства
        }
    }

    int countEnemy = 0, maxHealth = 5;
    public ParametrsPlayer player;
    public Slider sliderHealthPlayer;
    public TextMeshProUGUI textHealth;
    public GameObject heartImage;
    bool isWindowPlayer;


    private void Update()
    {
        if (player.HealthPlayer > maxHealth)
        {
            maxHealth = player.HealthPlayer;
            sliderHealthPlayer.maxValue = maxHealth;
            sliderHealthPlayer.value = maxHealth;
            textHealth.text = sliderHealthPlayer.value + " / " + "" + maxHealth;
        }

        if (ParametrsPlayer.lvlUP == true && (!player.LVLMax))
        {
            SkillsActive();
        }

        if (isWindowPlayer)
        {
            Debug.Log("СОЗДАТЕЛЬ ТЫ ИЗМЕНИЛ ИЕРАРХИЮ ОБЪЕКТОВ И ТЕПЕРЬ ОКНО ИГРОКА НЕ ПОКАЗЫВАЕТСЯ НА ТАБ");
        }

        Debug.Log(player.ExpPlayer);
    }

    private void Start()
    {
        sliderHealthPlayer.value = player.HealthPlayer;
        textHealth.text = sliderHealthPlayer.value + " / " + "" + maxHealth; 
    }

    public void TakeDamagePlayer()
    {
        sliderHealthPlayer.value -= 1;
        player.HealthPlayer = (int)sliderHealthPlayer.value;
        textHealth.text = sliderHealthPlayer.value + " / " + "" + maxHealth;
    }



    public void ShowInfoPlayer()
    {
        var infoPlayer = transform.GetChild(2);




        if (infoPlayer.name != "InfoPlayer")
        {
            isWindowPlayer = true;
        }
        else
        {
            infoPlayer.gameObject.SetActive(true);

            var textHealth = infoPlayer.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Количество здоровья: " + player.HealthPlayer + "\n" + 
                "Уровень: " + player.LVLPlayer + "  " + player.ExpPlayer + " / " + player.currentExpLvl + "\n" + "Количество врагов: " + countEnemy + "\n" +
                "Урон: " + player.DamagePlayer + "\n" +
                "Защита: " + player.ArmorPlayer + "\n" +
                "Уклонение: " + player.evasionPlayer; // Здоровье
/*            var textExp = infoPlayer.GetChild(1).GetComponent<TextMeshProUGUI>().text = ; // Опыт
            var textCountEnemy = infoPlayer.GetChild(2).GetComponent<TextMeshProUGUI>().text = ; // Количество противников на сцене
            var textDamage = infoPlayer.GetChild(3).GetComponent<TextMeshProUGUI>().text = ; // Урон который наносит игрок врагам*/
        }

    }

    public void AddExp(int exp)
    {
        transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "" + exp;
    }

    public void HideInfoPlayer()
    {
        var infoPlayer = transform.GetChild(2);


        if (infoPlayer.name != "InfoPlayer")
        {
            isWindowPlayer = true;
        }
        else
        {
            infoPlayer.gameObject.SetActive(false);
        }
        
    }

    void SkillsActive()
    {
        transform.GetChild(4).gameObject.SetActive(true);
    }
}
