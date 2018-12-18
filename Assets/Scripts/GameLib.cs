using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCheckAttribute : System.Attribute
{
}

public static class GameLib
{
    public static void CKMove(this CharacterController cc,
        Vector3 targetPosition,
        CharacterStat stat)
    {
        Transform t = cc.transform;

        Vector3 deltaMove = Vector3.zero;
        Vector3 moveDir = targetPosition - t.position;
        moveDir.y = 0.0f;
        if (moveDir != Vector3.zero)
        {
            t.rotation = Quaternion.RotateTowards(
                t.rotation,
                Quaternion.LookRotation(moveDir),
                stat.TurnSpeed * Time.deltaTime);
        }

        Vector3 nextMove = Vector3.MoveTowards(
            t.position,
            targetPosition,
            stat.MoveSpeed * Time.deltaTime);

        deltaMove = nextMove - t.position;
        deltaMove += Physics.gravity * Time.deltaTime;
        cc.Move(deltaMove);
    }

    public static bool DetectCharacter(Camera sight, CharacterController cc)
    {
        Plane[] ps = GeometryUtility.CalculateFrustumPlanes(sight);
        return GeometryUtility.TestPlanesAABB(ps, cc.bounds);
    }
}