using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AppStateTriggerButton : MonoBehaviour
{
   [SerializeField] private AppTrigger _trigger;

   public void OnClick()
   {
      Context.Instance.AppSystem.Trigger(_trigger);
      
   }
}
