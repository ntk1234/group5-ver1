using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    // Start is called before the first frame update
    int _currentHealth;
    int _currentMaxHealth;
    
    public int Health
    {
        get
        {
            return _currentHealth;
        }
        set
            {
            _currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
    }


}
