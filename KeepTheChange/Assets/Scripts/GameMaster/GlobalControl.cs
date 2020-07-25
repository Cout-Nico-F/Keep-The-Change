using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    float health, lastSpeed;
    Inventory inventory;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
            public float Health { get { return this.health; } set { this.health = value; } }
            public float LastSpeed { get { return this.lastSpeed; } set { this.lastSpeed = value; } }
            public Inventory Inventory { get { return this.inventory; } set { this.inventory = value; } }

}

//getters


