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

    public GameObject AttackPanel;
    public GameObject EnemySelectPanel;


    // Start is called before the first frame update
    void Start()
    {
        battleState = PerformAction.WAIT;
        EnemysInBattle.AddRange (GameObject.FindGameObjectsWithTag("Enemy"));
        HerosInGame.AddRange (GameObject.FindGameObjectsWithTag("Hero"));
        HeroInput = HeroGUI.ACTIVATE;

        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive(false);

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
           GameObject performer = turns[0].AttackGameObject;
            if(turns[0].Type == "Enemy")
            {
                EnemyStateMachine ESM = performer.GetComponent<EnemyStateMachine>();
                ESM.HeroToAttack = turns[0].AttackersTarget;
                ESM.currentState = EnemyStateMachine.TurnState.ACTION;
            }
            if (turns[0].Type == "Hero")
            {
                    Debug.Log("Hero is here to perform");
            }
            battleState = PerformAction.PERFORMACTION;
       break;
        case (PerformAction.PERFORMACTION):
       break;
       }
       switch (HeroInput)
       {
         case(HeroGUI.ACTIVATE):
         if(HerosToManage.Count > 1)
         {
            HerosToManage[1].transform.Find("Selector").gameObject.SetActive(true);
            HeroChoice = new HandleAttacks();
            AttackPanel.SetActive(true);
            HeroInput = HeroGUI.WAITING;
         }

         break;
         case(HeroGUI.WAITING):

         break;

         case(HeroGUI.DONE):

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
            Text buttonText = newButton.transform.Find("Text").gameObject.GetComponent<Text> ();
            buttonText.text = cur_enemy.enemy.name;

            button.EnemyPrefab = enemy;
            newButton.transform.SetParent (Spacer, false);
        }
    }
    public void Input1()//attack button
    {
        HeroChoice.Attacker = HerosToManage[0].GetComponent<HeroStateMachine>().hero.Name;
        HeroChoice.AttackGameObject = HerosToManage[0];
        HeroChoice.Type = "Hero";

        AttackPanel.SetActive(false);
        EnemySelectPanel.SetActive (true);

    }
    public void Input2(GameObject choosenEnemy){
        HeroChoice.AttackersTarget = choosenEnemy;
        HeroInput = HeroGUI.DONE;
    }

    void HeroInputDone(){
        turns.Add(HeroChoice);
        EnemySelectPanel.SetActive(false);
        HerosToManage[0].transform.Find("Selector").gameObject.SetActive(false);
        HerosToManage.RemoveAt(0);
        HeroInput = HeroGUI.ACTIVATE;
    }
}   
