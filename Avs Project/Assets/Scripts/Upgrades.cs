using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Upgrades : MonoBehaviour
{
    // DEFINE LIST WITH UPGRADES
    Upgrade[] _Upgrades = new Upgrade[]
    {
        new Upgrade { Name = "Velocidade de Ataque", Description = "Aumenta a velocidade de ataque", Increase = 12 },
        new Upgrade { Name = "Bananas Pesadas", Description = "Aumenta o dano das bananas em X", Increase = 2 },
        new Upgrade { Name = "Bananas Afiadas", Description = "Bananas podem atravessar mais X inimigo", Increase = 1 },
        new Upgrade { Name = "Chance de Crítico", Description = "Aumenta a chance de causar dano crítico em X%", Increase = 10 },
        new Upgrade { Name = "Dano Crítico", Description = "Aumenta o multiplicador de dano crítico em X%", Increase = 10 },
        new Upgrade { Name = "Pés Ligeiros", Description = "Aumenta a sua velocidade de movimento", Increase = 10 },
        new Upgrade { Name = "Vida", Description = "Te dá mais X de vida", Increase = 1 },
    };


    [SerializeField] private Button Upgrade_button1;
    [SerializeField] private Button Upgrade_button2;
    [SerializeField] private Button Upgrade_button3;
    [SerializeField] private Button Upgrade_button4;

    [SerializeField] private TextMeshProUGUI Upgrade_DescriptionText1;
    [SerializeField] private TextMeshProUGUI Upgrade_DescriptionText2;
    [SerializeField] private TextMeshProUGUI Upgrade_DescriptionText3;
    [SerializeField] private TextMeshProUGUI Upgrade_DescriptionText4;


    private void Start()
    {
        ButtonsSet();
    }

    public void ButtonsSet()
    {
        // CHOOSING UPGRADE FROM UPGRADE ARRAY
        List<int> availableUpgrades = new List<int>();
        for (int i = 0; i < _Upgrades.Length; i++)
        {
            availableUpgrades.Add(i);
        }

        ShuffleList(availableUpgrades);
        Upgrade Upgrade_1 = _Upgrades[availableUpgrades[0]];
        Upgrade Upgrade_2 = _Upgrades[availableUpgrades[1]];
        Upgrade Upgrade_3 = _Upgrades[availableUpgrades[2]];
        Upgrade Upgrade_4 = _Upgrades[availableUpgrades[3]];

        // Setting text
        Upgrade_button1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Upgrade_1.Name;
        Upgrade_button2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Upgrade_2.Name;
        Upgrade_button3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Upgrade_3.Name;
        Upgrade_button4.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Upgrade_4.Name;

        // Replacing the X with increase value
        Upgrade_DescriptionText1.text = Upgrade_1.Description.Replace("X", Upgrade_1.Increase.ToString());
        Upgrade_DescriptionText2.text = Upgrade_2.Description.Replace("X", Upgrade_2.Increase.ToString());
        Upgrade_DescriptionText3.text = Upgrade_3.Description.Replace("X", Upgrade_3.Increase.ToString());
        Upgrade_DescriptionText4.text = Upgrade_4.Description.Replace("X", Upgrade_4.Increase.ToString());

    }

    // UPGRADES
    public void UpgradeChosen(string Upgrade_chosen)
    {
        if (Upgrade_chosen == "Velocidade de Ataque")
        {
            GameManager.Instance.attackSpd -= 0.06f;
        }
        else if (Upgrade_chosen == "Bananas Pesadas")
        {
            GameManager.Instance.bulletDamage += 2;
        }
        else if (Upgrade_chosen == "Bananas Afiadas")
        {
            GameManager.Instance.bulletPierce += 1;
        }
        else if (Upgrade_chosen == "Chance de Crítico")
        {
            GameManager.Instance.criticalChance += 10;
        }
        else if (Upgrade_chosen == "Dano Crítico")
        {
            GameManager.Instance.criticalDamage += GameManager.Instance.criticalDamage * 10/100;
        }
        else if (Upgrade_chosen == "Pés Ligeiros")
        {
            GameManager.Instance.playerMoveSpd += 0.4f; 
        }
        else if (Upgrade_chosen == "Vida")
        {
            GameManager.Instance.playerHealth += 1; 
        }
    }

    // SHUFFLE LIST
    public void ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            int temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public class Upgrade
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Increase { get; set; }
    }
}