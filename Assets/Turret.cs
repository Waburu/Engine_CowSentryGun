using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{

    private Transform target;

    [SerializeField] // 적중 횟수 체크.
    private int _target_Hit;
    public int target_Hit { get { return _target_Hit; } }

    [Header("Attributes")] //사격범위와 터렛 속도 조절.

    public float _range;

    public float turnSpeed;
    public float fireRate;

    private float fireCountdown = 0f;

    [Header("Setup Field")] // 회전 위치와 적, 총알 설정.

    public Transform partToRotate;
    public string enemyTag = "Enermy";

    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // 다음 타겟으로 넘어가는 속도.

    }

    void UpdateTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;

            }
        }

        if (nearestEnemy != null && shortestDistance <= _range)
        {
            target = nearestEnemy.transform;
        }
    }

    private void Update()
    {
        if (target == null) return;

        // 적 추적과 회전값 설정.
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);

        //발사 속도 설정.
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot() // 발사
    {
        _target_Hit += 1;

        GameObject bulletGo = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        bullet.TargetHitPoint(_target_Hit);

       if (bullet != null) bullet.find_Target(target);

       if (target_Hit >= 7) _target_Hit = 0;

    }

    private void OnDrawGizmosSelected() // 사격범위 그리기.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

}
