using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

    // HAVE TO CHANGE THE ASSET LOADING TO BUILD THE GAME
    // AND ADD THE UPGRADES SCRIPTABLE OBJECTS TO THE ASSETS/RESOURCES FOLDER   
    // still stuff to do here

public class UpgradesManager : MonoBehaviour
{   
    [Header("References")]
    [SerializeField] private Camera UpgradeCamera;
    [SerializeField] private GameObject UpgradesCanvas;
    public UpgradeMethods upgradeMethods;
    public Statistics statistics;
    [SerializeField] private GameObject pauseMan;
    public PauseManager pauseManager;
    public PlayerStats playerStats;
    public TimeManager timeManager;

    [Header("Upgrades UI")]
    [SerializeField] private Button[] upgradeButtons;
    [SerializeField] private TMP_Text[] upgradeTexts;
    [SerializeField] private List<UpgradeScriptableObject> UpgradesList = new(); 
    [SerializeField] private TMP_Text TooltipText;
    private List<string> AddedUpgrades = new();
    private UpgradeScriptableObject UpgradeToAdd;
    private bool flag1st = false;
    private bool flag2nd = false;
    private bool flag3rd = false;
    
    void Start()
    {
        ShuffleUpgrades();
        UpdateButtons();
    }

    public void ShuffleUpgrades() // shuffles the current upgrades list
    {
        int n = UpgradesList.Count;

        for (int i = 0; i < n - 1; i++)
        {
            int k = Random.Range(i, n);
            (UpgradesList[k], UpgradesList[i]) = (UpgradesList[i], UpgradesList[k]);
        }

        UpdateButtons();
    }

    public void UpdateButtons() // updates the text on the upgrade buttons
    {
        for (int i = 0; i < upgradeTexts.Length; i++)
        {
            if(i < UpgradesList.Count)
               upgradeTexts[i].text = UpgradesList[i].upgradeName;
            else // if there's not enough upgrades left it changes the text to "No Upgrade"
            {
                upgradeTexts[i].text = "No Upgrade";
                TMP_Text buttonText = upgradeTexts[i];
                
                // NEED TO ADD TO DISABLE AND ENABLE THE BUTTON DEPENDING IF THERE'S NO UPGRADES
            }  
        }
    }

    public void UpgradeChosen(int buttonIndex)
    {
        ApplyUpgrade(UpgradesList[buttonIndex].upgradeID, buttonIndex);  // applies the chosen upgrade's effect 
        AddUpgradeTree(UpgradesList[buttonIndex].upgradeID); // adds new upgrades to the list based on which upgrade was chosen
        
        if(UpgradesList[buttonIndex].uniqueUpgrade)
            UpgradesList.RemoveAt(buttonIndex); // removes the chosen upgrade from the list

        ShuffleUpgrades();
        UpdateButtons();

        UpgradeCamera.enabled = false;
        UpgradesCanvas.SetActive(false);
        Time.timeScale = timeManager.currentTimeScale;
        playerStats.isInUpgrade = false;
        pauseManager.paused = false;
        pauseMan.SetActive(true);
        statistics.StatUpgradesGotten();
    }

    public void UpdateUpgradeTooltip(int buttonIndex)
    {
        if(buttonIndex == 69)
            TooltipText.text = "Shuffles the upgrades";   
        else
            TooltipText.text = UpgradesList[buttonIndex].description;
    }

    public void UpdateUpgradeTooltipExit()
    {
        TooltipText.text = "Hover an upgrade to see its description.";
    }

    public void AddUpgradeTree(float ID) // grabs the upgrade ID to select which upgrades should be added
    {
        switch (ID)
        {   
        // -------------------------------------------------------------------------------------
            // FIRST FORMAT = DIAMOND FORMAT
            case 1: // if the player chooses the upgrada1 it adds the upgrades 1.1 and 1.2
                //UpgradeToAdd = AssetDatabase.LoadAssetAtPath<UpgradeScriptableObject>("Assets/Resources/Upgrades/Upgrade1.1.asset"); // CHANGE TO BUILD THE GAME 
                UpgradeToAdd = Resources.Load<UpgradeScriptableObject>("Upgrades/Upgrade1.1");
                UpgradesList.Add(UpgradeToAdd); 
                AddedUpgrades.Add("Upgrade1.1");

                // UpgradeToAdd = AssetDatabase.LoadAssetAtPath<UpgradeScriptableObject>("Assets/Resources/Upgrades/Upgrade1.2.asset"); // CHANGE TO BUILD THE GAME
                UpgradeToAdd = Resources.Load<UpgradeScriptableObject>("Upgrades/Upgrade1.2");
                AddedUpgrades.Add("Upgrade1.2");
                UpgradesList.Add(UpgradeToAdd); 
                break;

            case 1.1f:
            case 1.2f: 
                if(flag1st == false) // if the upgrades 1.1 or 1.2 were chosen previously it does not add another 1.3
                {
                    //UpgradeToAdd = AssetDatabase.LoadAssetAtPath<UpgradeScriptableObject>("Assets/Resources/Upgrades/Upgrade1.3.asset"); // CHANGE TO BUILD THE GAME
                    UpgradeToAdd = Resources.Load<UpgradeScriptableObject>("Upgrades/Upgrade1.3");
                    AddedUpgrades.Add("Upgrade1.3");
                    UpgradesList.Add(UpgradeToAdd); 
                }
                flag1st = true;
                break;

        // -------------------------------------------------------------------------------------

            case 2: // if the player chooses the upgrada1 it adds the upgrades 2.1 or 2.2
                //UpgradeToAdd = AssetDatabase.LoadAssetAtPath<UpgradeScriptableObject>("Assets/Resources/Upgrades/Upgrade2.1.asset"); // CHANGE TO BUILD THE GAME 
                UpgradeToAdd = Resources.Load<UpgradeScriptableObject>("Upgrades/Upgrade2.1");
                UpgradesList.Add(UpgradeToAdd); 
                AddedUpgrades.Add("Upgrade2.1");

                //UpgradeToAdd = AssetDatabase.LoadAssetAtPath<UpgradeScriptableObject>("Assets/Resources/Upgrades/Upgrade2.2.asset"); // CHANGE TO BUILD THE GAME
                UpgradeToAdd = Resources.Load<UpgradeScriptableObject>("Upgrades/Upgrade2.2");
                AddedUpgrades.Add("Upgrade2.2");
                UpgradesList.Add(UpgradeToAdd); 
                break;

            case 2.1f:
            case 2.2f: 
                if(flag2nd == false) // if the upgrades 1.1 or 1.2 were chosen previously it does not add another 2.3
                {
                    //UpgradeToAdd = AssetDatabase.LoadAssetAtPath<UpgradeScriptableObject>("Assets/Resources/Upgrades/Upgrade2.3.asset"); // CHANGE TO BUILD THE GAME
                    UpgradeToAdd = Resources.Load<UpgradeScriptableObject>("Upgrades/Upgrade2.3");
                    AddedUpgrades.Add("Upgrade2.3");
                    UpgradesList.Add(UpgradeToAdd); 
                }
                flag2nd = true;
                break;

        // -------------------------------------------------------------------------------------

            case 5: // if the player chooses the upgrada1 it adds the upgrades 5.1 or 5.2
                //UpgradeToAdd = AssetDatabase.LoadAssetAtPath<UpgradeScriptableObject>("Assets/Resources/Upgrades/Upgrade5.1.asset"); // CHANGE TO BUILD THE GAME 
                UpgradeToAdd = Resources.Load<UpgradeScriptableObject>("Upgrades/Upgrade5.1");
                UpgradesList.Add(UpgradeToAdd); 
                AddedUpgrades.Add("Upgrade5.1");

                //UpgradeToAdd = AssetDatabase.LoadAssetAtPath<UpgradeScriptableObject>("Assets/Resources/Upgrades/Upgrade5.2.asset"); // CHANGE TO BUILD THE GAME
                UpgradeToAdd = Resources.Load<UpgradeScriptableObject>("Upgrades/Upgrade5.2");
                AddedUpgrades.Add("Upgrade5.2");
                UpgradesList.Add(UpgradeToAdd); 
                break;

            case 5.1f:
            case 5.2f: 
                if(flag3rd == false) // if the upgrades 5.1 or 5.2 were chosen previously it does not add another 5.3
                {
                    //UpgradeToAdd = AssetDatabase.LoadAssetAtPath<UpgradeScriptableObject>("Assets/Resources/Upgrades/Upgrade5.3.asset"); // CHANGE TO BUILD THE GAME
                    UpgradeToAdd = Resources.Load<UpgradeScriptableObject>("Upgrades/Upgrade5.3");
                    AddedUpgrades.Add("Upgrade5.3");
                    UpgradesList.Add(UpgradeToAdd); 
                }
                flag3rd = true;
                break;
            default:
                break;
        }
    }

    private void ApplyUpgrade(float ID, int buttonIndex) // grabs the upgrade ID to know which effect to apply
    {
        switch (ID)
        {
        // -------------------------------------------------------------------------------------
            case 1: // HEALTH BUFF
                upgradeMethods.AddMaxHealth(UpgradesList[buttonIndex].value1); 
                break;

            case 1.1f: // HEALTH BUFF
                upgradeMethods.AddMaxHealth(UpgradesList[buttonIndex].value1);
                break;

            case 1.2f: // HEALTH REGEN BUFF
                upgradeMethods.AddHealthRegen(UpgradesList[buttonIndex].value1);
                break;

            case 1.3f: // HEALTH AND HEALTH REGENBUFF
                upgradeMethods.AddMaxHealth(UpgradesList[buttonIndex].value1);
                upgradeMethods.AddHealthRegen(UpgradesList[buttonIndex].value2);
                break;

        // -------------------------------------------------------------------------------------

            case 2: // FIRE RATE INCREASE
                upgradeMethods.AddRateOfFire(UpgradesList[buttonIndex].value1);
                break;

            case 2.1f: // FIRE RATE AND RELOAD SPEED
                upgradeMethods.AddRateOfFire(UpgradesList[buttonIndex].value1);
                upgradeMethods.LessReloadTime(UpgradesList[buttonIndex].value2);
                break;

            case 2.2f:
                upgradeMethods.AddWeaponDamage(UpgradesList[buttonIndex].value1);
                upgradeMethods.LessReloadTime(UpgradesList[buttonIndex].value2);
                break;

            case 2.3f:
                upgradeMethods.AddChanceToGetBulletBack(UpgradesList[buttonIndex].value1);
                break;

        // -------------------------------------------------------------------------------------

            case 3:
                upgradeMethods.AddCurrentHealth(UpgradesList[buttonIndex].value1);
                break;

        // -------------------------------------------------------------------------------------

            case 4:
                upgradeMethods.AddCurrentHealth(UpgradesList[buttonIndex].value1);
                break;

        // -------------------------------------------------------------------------------------
            
            case 5:
                upgradeMethods.AddCritChance(UpgradesList[buttonIndex].value1);
                break;
            
            case 5.1f:
                upgradeMethods.AddCritDamage(UpgradesList[buttonIndex].value1);
                break;

            case 5.2f:
                upgradeMethods.AddCritChance(UpgradesList[buttonIndex].value1);
                break;
            
            case 5.3f:
                upgradeMethods.AddCritChance(UpgradesList[buttonIndex].value1);
                upgradeMethods.AddCritDamage(UpgradesList[buttonIndex].value2);
                break;
            default:
                break;
        }
    }    
    
}
