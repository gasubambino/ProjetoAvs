using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_button : MonoBehaviour
{
    public LevelManager level;
    public UIManager manager;
    [SerializeField] private Upgrades Upgrades_script;
    public void Upgrade()
    {
        string Upgrade_chosen = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
        Upgrades_script.UpgradeChosen(Upgrade_chosen);
        Upgrades_script.ButtonsSet();
        manager.UpgradeDeactivate();
    }
}
