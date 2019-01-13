// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using System.IO;
using UMA;
using UMA.CharacterSystem;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UMA2")]
	public class Uma2AvatarDataSaveToString : ComponentAction<DynamicCharacterAvatar>
	{
		[RequiredField]
		[CheckForComponent(typeof(DynamicCharacterAvatar))]
		public FsmOwnerDefault gameObject;

        [UIHint(UIHint.Variable)]
		public FsmString GetData;
		
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
			GetData.Value = tno.GetCurrentRecipe();
			tno.BuildCharacter();

		}

	}
}