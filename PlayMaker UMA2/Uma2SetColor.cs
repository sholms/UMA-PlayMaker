// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using System.Collections;
using UnityEngine;
using System.IO;
using UMA;
using UMA.CharacterSystem;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UMA2")]
	public class Uma2SetColor : ComponentAction<DynamicCharacterAvatar>
	{ 
		[RequiredField]
		[CheckForComponent(typeof(DynamicCharacterAvatar))]
		public FsmOwnerDefault gameObject;

		public FsmString SlotName;
		public FsmColor Color;
		
		[System.NonSerialized]
		 DynamicCharacterAvatar tno;

		public override void OnEnter()
		{
			if (UpdateCache (Fsm.GetOwnerDefaultTarget (gameObject))) {
				tno = (DynamicCharacterAvatar)this.cachedComponent;
				OnSet();
			}
			
		}
        public void OnSet(){
			tno.SetColor(SlotName.Value,Color.Value);
			tno.BuildCharacter();

		}

	}
}