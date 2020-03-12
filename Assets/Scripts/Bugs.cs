﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class Bugs : MonoBehaviour
{
    private NavMeshAgent nav;
    [SerializeField]private GameObject target;
    [SerializeField] private GameObject boom;
    [SerializeField] private int attackPower;

    public static event UnityAction<int> damage;
    private void Awake() {
        nav = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator WaitToStart() {
        YieldInstruction wait = new WaitForSeconds(1f);
        yield return wait;
        nav.SetDestination(target.transform.position);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Hardrive")) {
            if (boom != null) {
                Instantiate(boom,transform.position,Quaternion.identity);

            }
            
            if (damage != null) {
                damage(attackPower);
            }
            

        }
         Destroy(gameObject);
    }
}