using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRUN : FSMState {

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

        Vector3 dest = _manager.Marker.transform.position;
        dest.y = 0.0f;
        Vector3 playerPos = transform.position;
        playerPos.y = 0.0f;
        if(Vector3.Distance(dest, playerPos) < 0.01f)
        {
            _manager.SetState(PlayerState.IDLE);
            return;
        }

        //Vector3 deltaMove = Vector3.zero;
        //Vector3 moveDir = _manager.Marker.position - transform.position;
        //moveDir.y = 0.0f;
        //if(moveDir != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.RotateTowards(
        //        transform.rotation,
        //        Quaternion.LookRotation(moveDir),
        //        _manager.Stat.TurnSpeed * Time.deltaTime);
        //}

        //Vector3 nextMove = Vector3.MoveTowards(
        //    transform.position,
        //    _manager.Marker.position,
        //    _manager.Stat.MoveSpeed * Time.deltaTime);

        //deltaMove = nextMove - transform.position;
        //deltaMove += Physics.gravity * Time.deltaTime;
        //_manager.CC.Move(deltaMove);

        _manager.CC.CKMove(_manager.Marker.position, _manager.Stat);
    }

}
