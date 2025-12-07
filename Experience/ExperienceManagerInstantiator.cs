using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManagerInstantiator : MonoBehaviour
{
    /// <summary>
    /// This is a script that instantiates a experience manager object
    /// everytime it loads a new scene to avoid bugs seen before
    /// </summary>
    
    [SerializeField] private GameObject ExperienceManager;
    private void Awake()
    {
        Instantiate(ExperienceManager);
    }
}
