using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[SerializeField]
public class DialougeObj{
    public string[] DiaLouges;
    public string CharacterName;
    public int questNumber;
    public float textSpeed;
}
public class DialougeObject : MonoBehaviour
{
    public PlayerData data;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialougeText;
    private int currentDialougeNum = 0;
    private DialougeObj currentDia = null;

    [Header("Dialouge objects")]
    public DialougeObj Dialouge1;
    
    private void start(){
        data = FindObjectOfType<PlayerData>();
    }
 
   private void OnEnable(){
    switch (data.DialougeNumber){

        case 1:
        PlayDialouge(Dialouge1);
        currentDia = Dialouge1;
            break;
    }

   }
   void PlayDialouge(DialougeObj temp){
    nameText.text = temp.CharacterName;
    if(currentDialougeNum < temp.DiaLouges.Length){
    DialougeText.text = temp.DiaLouges[currentDialougeNum];
    }
    else{
//end
    }
   }
 

   public void next(){
    if (currentDia != null){
        currentDialougeNum++;
        PlayDialouge(currentDia);
    }
   }
  
}
