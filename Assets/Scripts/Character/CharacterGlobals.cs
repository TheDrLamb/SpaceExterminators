using System.Collections;
using UnityEngine;

public static class CharacterGlobals
{
    public const string walkingString = "Walking";
    public const string sprintingString = "Sprinting";
    public const string crouchingString = "Crouch";
    public const string equipmentString = "Equipment";

    public enum Equipment : int
    {
        Gun,
        Tool,
        Consumable,
        Throwable
    }
}
