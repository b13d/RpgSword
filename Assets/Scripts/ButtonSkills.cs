using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using System.Linq;



public class ButtonSkills : MonoBehaviour
{

    ParametrsPlayer parametrsPlayer;
    GameObject windowSkills;

    private void Start()
    {
        parametrsPlayer = transform.parent.parent.GetComponent<ChoseSkill>().player;
        windowSkills = transform.parent.parent.gameObject;
    }

    public void OnMouseEnter()
    {
        GetComponent<Animator>().SetBool("onHover", true);
    }

    public void OnMouseExit()
    {
        GetComponent<Animator>().SetBool("onHover", false);
    }

    public void SubmitButton()
    {


        var text = transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text;
        //var keyText = transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>().text.ToLower();

        //keyText = Regex.Replace(text, @"[ \r\n\t]", " ");
        text = Regex.Replace(text, @"[ \r\n\t]", " ");

        int index = 0;

/*        keyText = keyText.Replace("+", "");
        var keyTexts = keyText.Split(" ");*/
        

        text = text.Replace("+", "");
        var keyText = text.Split(" ");
        text = text.ToLower();
        text = text.Replace("_1", "");
        text = text.Replace("_2", "");
        text = text.Replace("_3", "");
        var allText = text.Split(" ");

        if (allText[0] == "evasion")
        {
            index = 3;
            parametrsPlayer.evasionPlayer = int.Parse(allText[1]);
        }
        else if (allText[0] == "damage")
        {
            index = 0;
            parametrsPlayer.DamagePlayer = int.Parse(allText[1]);
        }
        else if (allText[0] == "health")
        {
            index = 2;
            parametrsPlayer.HealthPlayer = int.Parse(allText[1]);
        }
        else if (allText[0] == "armor")
        {
            index = 4;
            parametrsPlayer.ArmorPlayer = int.Parse(allText[1]);
        }
        else if (allText[0] == "speed")
        {
            index = 1;
            parametrsPlayer.speedPlayer = int.Parse(allText[1]);
        }


        if (transform.parent.name == "Skills_0")
        {
                parametrsPlayer.choseSkill.skills.listSkills.ElementAt(index).Remove(keyText[0]);
        }
        else if (transform.parent.name == "Skills_1")
        {
            parametrsPlayer.choseSkill.skills.listSkills.ElementAt(index).Remove(keyText[0]);


        }
        else if(transform.parent.name == "Skills_2")
        {
            parametrsPlayer.choseSkill.skills.listSkills.ElementAt(index).Remove(keyText[0]);


        }

        
        
        
        parametrsPlayer.choseSkill.skillsShow.Clear();
        parametrsPlayer.choseSkill.listUses.Clear();
        parametrsPlayer.choseSkill.itemUses.Clear();
        parametrsPlayer.choseSkill.skillsAdd.Clear();
        windowSkills.SetActive(false);
        ParametrsPlayer.lvlUP = false;
    }
}
