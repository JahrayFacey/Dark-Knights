using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private BattleStateMachine BSH;
    public EnemyData enemy;
     public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        DEAD
    }

    public TurnState currentState;
    private float cur_cooldown = 0f;
    private float max_cooldown = 5f;
   
   private Vector3 StartPosition;

   //timeforaction stuff
   private bool actionStarted = false;
   public GameObject HeroToAttack;
   private float animSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnState.PROCESSING;
        BSH = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>(); 
        StartPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
         switch (currentState)
        {
            case (TurnState.PROCESSING):
                    UpgradeProgressBar();
            break;

            case (TurnState.CHOOSEACTION):
                ChooseAction();
                currentState = TurnState.WAITING;
             break;
            case (TurnState.WAITING):

            break;
            case (TurnState.ACTION):
                StartCoroutine (TimeForAction ()); 
            break;
            case (TurnState.DEAD):

            break;
    }

}
void UpgradeProgressBar()
        {
            cur_cooldown = cur_cooldown + Time.deltaTime;
            if (cur_cooldown >= max_cooldown)
            {
                currentState = TurnState.CHOOSEACTION;
            }
        

        }

void ChooseAction()
{
    HandleAttacks myAttack = new HandleAttacks();
    myAttack.Attacker = enemy.name;
    myAttack.Type = "Enemy";
    myAttack.AttackGameObject = this.gameObject;
    myAttack.AttackersTarget = BSH.HerosInGame[Random.Range(0, BSH.HerosInGame.Count)];
    BSH.CollectActions (myAttack);
}

    private IEnumerator TimeForAction()
    {
        if(actionStarted)
        {
            yield break;
        }
        actionStarted = true;

        //animate the enemy near the hero to attack
        Vector3 heroPosition = new Vector3(HeroToAttack.transform.position.x, HeroToAttack.transform.position.y, HeroToAttack.transform.position.z);
        while(MoveTowardsEnemy(heroPosition)){ yield return null;}

        // wait abit
        yield return new WaitForSeconds(0.5f);
        //do damage

        //animate back to startpositon
        Vector3 firstPosition = StartPosition;
        while (MoveTowardsStart (firstPosition)) {yield return null;}
        //remove this perfomer from the list in BSM
        BSH.turns.RemoveAt(0);
        //reset battle state machine
        BSH.battleState = BattleStateMachine.PerformAction.WAIT;
        //end coroutine
        actionStarted = false;
        //reset this enemy
        cur_cooldown = 0f;
        currentState = TurnState.PROCESSING;
    }
    private bool MoveTowardsEnemy(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }
    private bool MoveTowardsStart(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }
}
