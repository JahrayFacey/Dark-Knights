using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject player;
    public Animator anim;
    private float updateTime = 0;

    private bool IsAttacking;
    private PlayerData data;
    public float minDamage;
    public float maxDamage;
    // Start is called before the first frame update
    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        data = FindObjectOfType<PlayerData>();
        //Invoke("FindTarget", 2);
    }      

    

    public void Update()
    {
        updateTime += Time.deltaTime;

        float dist = Vector3.Distance(this.transform.position, player.transform.position);
        if(dist <= 3)
        {
            if(!IsAttacking){

            }
            StartCoroutine(Attack());
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    IEnumerator Attack()
    {
        if(!IsAttacking){
            IsAttacking = true;
            anim.SetBool("Attack", false);
            yield return new WaitForSeconds(1.2f);
            data.TakeDamage(Random.Range(minDamage, maxDamage));
            IsAttacking = false;
        }
    }

    private void LateUpdate()
    {
        transform.LookAt(player.transform);
        if(updateTime > 2)
        {
            nav.destination = player.transform.position;
            updateTime = 0;
        }
        
    }
}
