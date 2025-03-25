using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleStateMachine : MonoBehaviour
{
    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION
    }
    public PerformAction battleState;

    public List<HandleAttacks> turns = new List<HandleAttacks>();
    public List<GameObject> HerosInGame = new List<GameObject>();
    public List <GameObject> EnemysInBattle = new List <GameObject>();

    public enum HeroGUI
    {
        ACTIVATE,
        WAITING,
        INPUT1,
        INPUT2,
        DONE
    }
    public HeroGUI HeroInput;
    public GameObject enemyButton;
    public Transform Spacer;


    public List<GameObject> HerosToManage = new List<GameObject>();
    private HandleAttacks HeroChoice;


    // Start is called before the first frame update
    void Start()
    {
        battleState = PerformAction.WAIT;
        EnemysInBattle.AddRange (GameObject.FindGameObjectsWithTag("Enemy"));
        HerosInGame.AddRange (GameObject.FindGameObjectsWithTag("Hero"));

        EnemyButtons();
    }

    // Update is called once per frame
    void Update()
    {
       switch (battleState)
       {
       case (PerformAction.WAIT):
        if (turns.Count > 0 )
        {
            battleState = PerformAction.TAKEACTION;
        }
       break;
        case (PerformAction.TAKEACTION):
            GameObject performer = GameObject.Find(turns[0].Attacker);
            if(turns[0].Type == "Enemy")
            {
                EnemyStateMachine ESM = performer.GetComponent<EnemyStateMachine>();
               // ESM.HeroToAttack = turns[0].AttackersTarget;
                performer = turns[0].AttackGameObject;
                ESM.currentState = EnemyStateMachine.TurnState.ACTION;
            }
            if (turns[0].Type == "Hero")
            {

            }
            battleState = PerformAction.PERFORMACTION;
       break;
        case (PerformAction.PERFORMACTION):
       break;
       }
    }
    public void CollectActions(HandleAttacks input)
    {
        turns.Add(input);
    }

    void EnemyButtons()
    {
        foreach(GameObject enemy in EnemysInBattle)
        {
            GameObject newButton = Instantiate (enemyButton) as GameObject;
            SelectTarget button = newButton.GetComponent<SelectTarget>();
            EnemyStateMachine cur_enemy = enemy.GetComponent<EnemyStateMachine> ();

            button.EnemyPrefab = enemy;
            Text buttonText = newButton.transform.FindChild("Text").gameObject.GetComponent<Text> ();
            buttonText.text = cur_enemy.enemy.name;

            button.EnemyPrefab = enemy;
            newButton.transform.SetParent (Spacer, false);
        }
    }
}
