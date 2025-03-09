using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject player;

    private float updateTime = 0;
    // Start is called before the first frame update
    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        //Invoke("FindTarget", 2);
    }      

    public void Update()
    {
        updateTime += Time.deltaTime;
    }

    private void LateUpdate()
    {
        if(updateTime > 2)
        {
            nav.destination = player.transform.position;
            updateTime = 0;
        }
        
    }
}
