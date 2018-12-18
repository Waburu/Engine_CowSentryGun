using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : CharacterStat
{
    public StatData playerStat;

    private void Awake()
    {
        Debug.Log(playerStat.maxHp);
    }
}
