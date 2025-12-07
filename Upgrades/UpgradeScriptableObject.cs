using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/Upgrade Template")]
public class UpgradeScriptableObject : ScriptableObject
{
    public float upgradeID;
    public string upgradeName;
    [Tooltip("Tooltip upgrade description")] public string description;
    public float value1;
    public float value2;
    public float value3;
    [Tooltip("If it's unique, it'll be removed from the list after it gets chosen")] public bool uniqueUpgrade;
}
