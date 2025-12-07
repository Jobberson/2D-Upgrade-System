using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class UpgradeMethods : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerStats playerStats;
    public UImanager uiManager;
    public ItemsActivator itemsActivator;
    [Space]
    [SerializeField] private List<WeaponData> weaponData = new();
    private int index;
    
    private void Awake() 
    {
        index = System.Convert.ToInt32(ItemsEquippedManager.weapon1);
    }

    private void Start()
    {
        InitValues();
    }

    #region Setters
        public void LifeSteal()
        {
            float local;
            if(weaponData[index].critChanceValue > weaponData[index].critValue)
            {
                local = weaponData[index].lifeStealPercentageValue * 2 / 100 * weaponData[index].damageWithCritValue;
                AddCurrentHealth(local);
            }
            else
            {
                local = weaponData[index].lifeStealPercentageValue / 100 * weaponData[index].damageWithCritValue;
                AddCurrentHealth(local);
            }
        }   

    #endregion
    
    #region WeaponData

    // random
    public void FireRateHalfLifeOn()
    {
       weaponData[index].isFireRateHalfLifeOn = true;
    }

    public void FireRateHalfLifeOff()
    {
        weaponData[index].isFireRateHalfLifeOn = false;
    }

    // weapon
    public void AddRateOfFire(float MoreFireRate)
    {
        weaponData[index].fireRateValue += MoreFireRate;
    }

    public void AddSpread(float MoreSpread)
    {
        if(weaponData[index].isAuto)
            weaponData[index].maxSpreadValue += MoreSpread;
    }

    public void LessReloadTime(float LessReload)
    {
        weaponData[index].reloadTimeValue -= LessReload;
    }

    public void AddMaxAmmo(float MoreAmmo)
    {
        weaponData[index].maxAmmoValue += MoreAmmo;
        weaponData[index].currentAmmo = weaponData[index].maxAmmoValue;
    }

    public void AddCurrAmmo(float MoreCurrAmmo)
    {
        weaponData[index].currentAmmo += MoreCurrAmmo;
    }

    public void AddMultiBullet(float MoreMultiBullet)
    {
        weaponData[index].isMultiBulletValue += MoreMultiBullet;
    }
    // bullet 
    public void AddBulletSpeed(float MoreBulletSpeed)
    {
        weaponData[index].bulletSpeedValue += MoreBulletSpeed;
    }

    public void AddBulletDistance(float MoreBulletDistance)
    {
        weaponData[index].maxDistance += MoreBulletDistance;
    }

    public void AddWeaponDamage(float MoreDamage)
    {
        weaponData[index].damageValue += MoreDamage;
    }

    public void AddCritChance(float MoreCritChance)
    {
        weaponData[index].critChanceValue += MoreCritChance;
    }

    public void AddCritDamage(float MoreCritDamage)
    {
        weaponData[index].critDamageValue += MoreCritDamage;
    }

    // UPGRADES
    public void AddChanceToGetBulletBack(float MoreChanceToGetBulletBack)
    {
        weaponData[index].chanceToGetBulletBackValue += MoreChanceToGetBulletBack;
    }

    public void AddDamageMultiplierBasedOnMissingHealth()
    {
        weaponData[index].isDamageMultiplying = true;
    }

    public void UneqipDamageMultiplierBasedOnMissingHealth()
    {
        weaponData[index].isDamageMultiplying = false;
    }

    public void AddLastBulletMissile()
    {
        weaponData[index].isLastBulletMissile = true;
    }

    public void UnequipMissileBullet()
    {
        weaponData[index].isLastBulletMissile = false;
    }

    #endregion

    #region PlayerStats

    // PLAYER STATS
    // random

    public void SetMagnetUpgradeOn()
    {
        playerStats.isUltraMagnetOn = true;
    }

    public void HealthToShield()
    {
        playerStats.MaxShield = playerStats.MaxHealth;
        playerStats.MaxHealth = 1f;
    }

    public void AddDodgeChance(float newDodgeChance)
    {
        playerStats.dodgeChance += newDodgeChance;
    }

    // HEALTH
    public void AddMaxHealth(float MoreMaxHealth)
    {
        playerStats.MaxHealth += MoreMaxHealth;
        if((playerStats.currHealth + MoreMaxHealth) < playerStats.MaxHealth)
            playerStats.currHealth += MoreMaxHealth;
        else 
            playerStats.currHealth = playerStats.MaxHealth;

        uiManager.SetMaxHealth(playerStats.MaxHealth, playerStats.currHealth);
    }

    public void AddCurrentHealth(float MoreCurrentHealth)
    {
        if((playerStats.currHealth + MoreCurrentHealth) < playerStats.MaxHealth)
            playerStats.currHealth += MoreCurrentHealth;
        else 
            playerStats.currHealth = playerStats.MaxHealth;

        uiManager.SetHealth(playerStats.currHealth);
    }

    public void AddHealthRegen(float MoreHealthRegen)
    {
        playerStats.healthRegen += MoreHealthRegen;
    }

    public void AddLifeSteal(float MoreLifeSteal)
    {
        weaponData[index].lifeStealPercentageValue = MoreLifeSteal;
    }

    // SHIELD
    public void AddMaxShield(float moreMaxShield)
    {
        playerStats.MaxShield += moreMaxShield;

        uiManager.SetMaxShield(playerStats.MaxShield, playerStats.currShield);
    }

    public void AddShieldRegen(float moreShieldRegen) // in seconds
    {
        playerStats.shieldRegenSpeed -= moreShieldRegen;
    }

    #endregion

    #region PlayerController

    // SPEED AND HITBOX 
    // Player Controller
    public void AddPlayerSpeed(float MorePlayerSpeed)
    {
        playerController._moveClamp += MorePlayerSpeed;
    }

    public void SubtractPlayerSpeed(float LessPlayerSpeed)
    {
        playerController._moveClamp -= LessPlayerSpeed;
    }

    public void AddJumpHeight(float MoreJumpHeight)
    {
        playerController._jumpHeight += MoreJumpHeight;
    }

    public void SubtractJumpHeight(float LessJumpHeight)
    {
        playerController._jumpHeight -= LessJumpHeight;
    }

    #endregion

    #region InitValues
    // initialization
    private void InitValues()
    {
        weaponData[index].fireRateValue = weaponData[index].fireRate;
        weaponData[index].maxSpreadValue = weaponData[index].maxSpread;
        weaponData[index].reloadTimeValue = weaponData[index].reloadTime;
        weaponData[index].maxAmmoValue = weaponData[index].maxAmmo; 
        weaponData[index].isMultiBulletValue = weaponData[index].isMultiBullet;
        weaponData[index].bulletSpeedValue = weaponData[index].bulletSpeed;
        weaponData[index].maxDistanceValue = weaponData[index].maxDistance;
        weaponData[index].damageValue = weaponData[index].damage; 
        weaponData[index].critChanceValue = weaponData[index].critChance;
        weaponData[index].critDamageValue = weaponData[index].critDamage;
        weaponData[index].damageWithCritValue = weaponData[index].damage;
        weaponData[index].chanceToGetBulletBackValue = weaponData[index].chanceToGetBulletBack;
        weaponData[index].lifeStealPercentageValue = weaponData[index].lifeStealPercentage;
    }
    
    #endregion
}
