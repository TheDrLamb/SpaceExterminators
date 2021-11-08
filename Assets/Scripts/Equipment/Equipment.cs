﻿using UnityEngine;
using System.Collections;

public class Equipment : MonoBehaviour
{
    public string Name;
    public GameObject obj;
    public EquipmentType type;
    public EquipmentAction action;

    private void Start()
    {
        action = GetComponent<EquipmentAction>();
    }
}

public enum EquipmentType
{
    Gun,
    Tool,
    Consumable,
    Throwable
}