using UnityEngine;
[System.Serializable]
public enum Resource
{
    Plants,       // Coin: +1 / Food: +2
    Animals,      // Coin: +1 / Food: +3
    Metals,       // Coin: +3 / Food: -1
    Fossilfuel,   // Coin: +5 / Food: -3
    Luxury,       // Coin: +4 / Food: -1
    Pollution     // Coin: -3 / Food: -3
}
