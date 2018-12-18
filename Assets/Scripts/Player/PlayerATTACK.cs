using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TargetCheck]
public class PlayerATTACK : FSMState
{
    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }

    protected override void Update()
    {
        base.Update();

    }

    public void AttackCheck()
    {
        Debug.Log("AttackCheck");

        CharacterStat targetStat =
            _manager.Target.GetComponent<CharacterStat>();

        CharacterStat.ProcessDamage(_manager.Stat, targetStat);
    }

}
