// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UMA;
using UMA.CharacterSystem;


namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("UMA2")]
	public class Uma2SetDna : ComponentAction<DynamicCharacterAvatar>
	{ 
		public Dictionary< string, DnaSetter> dna;

		[RequiredField]
		[CheckForComponent(typeof(DynamicCharacterAvatar))]
		public FsmOwnerDefault gameObject;

		public FsmString DnaName;
		public FsmFloat SetValue;
		
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

			
				dna = tno.GetDNA();
				dna[DnaName.Value] .Set(SetValue.Value);
				tno.BuildCharacter();	
		}

	}
}