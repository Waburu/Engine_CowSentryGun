using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    private Transform target;
    private int T_Hit;

    public float speed = 70f;

    public void find_Target (Transform _target)
    {
        target = _target;

    }

    public void TargetHitPoint (int t_hit)
    {
        T_Hit = t_hit;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        if (T_Hit >= 6)
        {
            Destroy(target.gameObject);
        }
        
        Destroy(gameObject, 1f);
    }
}
