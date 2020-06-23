using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier_Base : MonoBehaviour {

    public float hp;
    public GameObject target;
    public float attackRange;
    public float attackCoolDown;

    private float timer;
    private NavMeshAgent NMA;


    void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        if (target == null) return;

        timer += Time.fixedDeltaTime;
        float dist = Vector3.Distance(target.transform.position, transform.position);

        if (dist > attackRange)
        {
            NMA.SetDestination(target.transform.position);

        }
        else
        {
            NMA.ResetPath();
            if (timer > attackCoolDown)
            {
                transform.LookAt(target.transform.position);
                   //这边加一个攻击动作
                   timer = 0f;
            }
        }

    }
}
