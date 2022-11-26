using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;


public class ChoseSkill : MonoBehaviour
{
    [SerializeField]
    public Skills skills;
    public List<string> skillsAdd = new List<string>();
    public List<KeyValuePair<string, int>> skillsShow = new List<KeyValuePair<string, int>>();
    public Dictionary<string, int> listUses = new Dictionary<string, int>();
    public List<Dictionary<string, int>> itemUses = new List<Dictionary<string, int>>();

    bool existsSkill;
    int counter = 0, j = 0;
    public ParametrsPlayer player;



    void Update()
    {
        if (ParametrsPlayer.lvlUP == true && transform.tag == "skills" && skillsAdd.Count != 3)
        {
            SkillsShow();
        }
    }

    void SkillsShow()
    {
            skills = transform.GetComponent<Skills>();

            List<Dictionary<int, string>> selectedSkills = new List<Dictionary<int, string>>();

            var lvl = ParametrsPlayer.currentLvlPlayer;

        if (lvl < 3)
        {
            var randomNumber = Random.Range(0, 5);
            var allSkills = (skills.listSkills[randomNumber]);
            if(allSkills.Count < 3)
            {
                for(int i = 3; i > allSkills.Count;)
                {
                    randomNumber = Random.Range(0, 5);
                    allSkills = (skills.listSkills[randomNumber]);
                }
            }
            foreach (KeyValuePair<string, int> kvp in allSkills)
            {
                if (counter > 0)
                    break;
                for (int i = 0; i < skillsAdd.Count; i++)
                {
                    if (skillsAdd[i] == kvp.Key)
                    {
                        existsSkill = true;
                        break;
                    }
                }
                if (existsSkill)
                    break;
                listUses.Add(kvp.Key, kvp.Value);
                var qq = new Dictionary<string, int>(listUses);
                itemUses.Add(qq);
                listUses.Clear();
                skillsAdd.Add(kvp.Key);
                skillsShow.Add(kvp);
                if (skillsAdd.Count == 3)
                {
                    transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = skillsAdd[0] + "\n+" + skillsShow[0].Value;
                    transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = skillsAdd[1] + "\n+" + skillsShow[1].Value;
                    transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text = skillsAdd[2] + "\n+" + skillsShow[2].Value;
                }
                counter++;
                j++;
            }
            existsSkill = false;
            counter = 0;
        }

        if (lvl > 2 && lvl < 7)
        {
            var randomNumber = Random.Range(0, 5);
            var allSkills = (skills.listSkills[randomNumber]);
            if (allSkills.Count < 2)
            {
                for (int i = 2; i > allSkills.Count;)
                {
                    randomNumber = Random.Range(0, 5);
                    allSkills = (skills.listSkills[randomNumber]);
                }
            }
            foreach (KeyValuePair<string, int> kvp in allSkills)
            {
                if (counter > 0)
                    break;
                for (int i = 0; i < skillsAdd.Count; i++)
                {
                    if (skillsAdd[i] == kvp.Key)
                    {
                        existsSkill = true;
                        break;
                    }
                }
                if (existsSkill)
                    break;
                listUses.Add(kvp.Key, kvp.Value);
                var qq = new Dictionary<string, int>(listUses);
                itemUses.Add(qq);
                listUses.Clear();
                skillsAdd.Add(kvp.Key);
                skillsShow.Add(kvp);
                if (skillsAdd.Count == 3)
                {
                    transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = skillsAdd[0] + "\n+" + skillsShow[0].Value;
                    transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = skillsAdd[1] + "\n+" + skillsShow[1].Value;
                    transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text = skillsAdd[2] + "\n+" + skillsShow[2].Value;
                }
                counter++;
                j++;
            }
            existsSkill = false;
            counter = 0;
        }

        if (lvl > 6 && lvl < 11)
        {
            var randomNumber = Random.Range(0, 5);
            var allSkills = (skills.listSkills[randomNumber]);
            if (allSkills.Count < 1) // меняю только тут, если другой уровень
            {
                for (int i = 1; i > allSkills.Count;) // меняю только тут, если другой уровень
                {
                    randomNumber = Random.Range(0, 5);
                    allSkills = (skills.listSkills[randomNumber]);
                }
            }
            foreach (KeyValuePair<string, int> kvp in allSkills)
            {
                if (counter > 0)
                    break;
                for (int i = 0; i < skillsAdd.Count; i++)
                {
                    if (skillsAdd[i] == kvp.Key)
                    {
                        existsSkill = true;
                        break;
                    }
                }
                if (existsSkill)
                    break;
                listUses.Add(kvp.Key, kvp.Value);
                var qq = new Dictionary<string, int>(listUses);
                itemUses.Add(qq);
                listUses.Clear();
                skillsAdd.Add(kvp.Key);
                skillsShow.Add(kvp);
                if (skillsAdd.Count == 3)
                {
                    transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = skillsAdd[0] + "\n+" + skillsShow[0].Value;
                    transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = skillsAdd[1] + "\n+" + skillsShow[1].Value;
                    transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>().text = skillsAdd[2] + "\n+" + skillsShow[2].Value;
                }
                counter++;
                j++;
            }
            existsSkill = false;
            counter = 0;
        }
    }
}
