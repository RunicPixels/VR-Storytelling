//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: This object will get hover events and can be attached to the hands
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class Interactable : MonoBehaviour
	{
		public delegate void OnAttachedToHandDelegate( Hand hand );
		public delegate void OnDetachedFromHandDelegate( Hand hand );
        private AudioSource source;
        public AudioClip attachSound;
        public AudioClip detachSound;

		[HideInInspector]
		public event OnAttachedToHandDelegate onAttachedToHand;
		[HideInInspector]
		public event OnDetachedFromHandDelegate onDetachedFromHand;

        private void Awake() {
            if (GetComponent<AudioSource>() != null) {
                source = GetComponent<AudioSource>();
            }
            else {
                source = gameObject.AddComponent<AudioSource>();
            }
        }
        //-------------------------------------------------
        private void OnAttachedToHand( Hand hand )
		{
            source.PlayOneShot(attachSound);
            if ( onAttachedToHand != null )
			{
                
				onAttachedToHand.Invoke( hand );
			}
		}


		//-------------------------------------------------
		private void OnDetachedFromHand( Hand hand )
		{
            source.PlayOneShot(detachSound);
            if ( onDetachedFromHand != null )
			{
                
				onDetachedFromHand.Invoke( hand );
			}
		}
	}
}
