using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    /// <summary>
    /// This is the Experience manager script
    /// It... manages.. experience.. if you didn't get it still
    /// </summary>
    
    public static ExperienceManager Instance;
    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChange;

    private void Awake()
    {
        // singleton check
        // makes sure there's just one instance of this
        if(Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void AddExperience(int amount)
    {
        OnExperienceChange?.Invoke(amount);
    }
}
