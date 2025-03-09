using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace UnityStandardAssets.Characters.FirstPerson
{

[Serializable]
public class DialougeObj{
    public string[] DiaLouges;
    public string CharacterName;
    public float textSpeed;
    
}
public class DialougeObject : MonoBehaviour
{
    public PlayerData data;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialougeText;
    public RigidbodyFirstPersonController rigid;
    private QuestObject obj;
    private int currentDialougeNum = 0;
    private DialougeObj currentDia = null;

    [Header("Dialouge objects")]
    public DialougeObj Dialouge1;
    public DialougeObj Dialogue105;
    
    [Header("NPCS")]
    public NPC1 npc1;

    private void Awake()
    {
        obj = FindObjectOfType<QuestObject>();
    }

    private void start(){
        data = FindObjectOfType<PlayerData>();
    }
 
   private void OnEnable(){
    switch (data.DialougeNumber){

        case 1:
        PlayDialouge(Dialouge1);
        currentDia = Dialouge1;
            break;
        case 1.5f:
            PlayDialouge(Dialogue105);
            currentDia = Dialogue105;
            break;
    }

   }
   void PlayDialouge(DialougeObj temp){
    nameText.text = temp.CharacterName;
    if(currentDialougeNum < temp.DiaLouges.Length){
    DialougeText.text = temp.DiaLouges[currentDialougeNum];
    }
    else{
         
                rigid.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                switch (data.DialougeNumber)
                {
                    case 1:
                        npc1.hasTalked = true;
                        npc1.isDialogue = false;
                        obj.StartNewQuest(obj.questObjs[0]);
                        break;
                    case 1.5f:
                        npc1.isDialogue = false;
                        break;
                }
                data.DialougeNumber = 0;
                
                currentDialougeNum = 0;
                currentDia = null;
                this.gameObject.SetActive(false);
                

    }
   }
 

   public void next(){
    if (currentDia != null){
        currentDialougeNum++;
        PlayDialouge(currentDia);
    }
   }
  
}
}
