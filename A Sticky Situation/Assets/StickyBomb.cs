﻿using UnityEngine;
using System.Collections;

public class StickyBomb : MonoBehaviour {

	[HideInInspector]
	public int ownerID;
	[HideInInspector]
	public int stuckID;
	[HideInInspector]
	public bool isStuck = false;
	[HideInInspector]
	public bool hitGround = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		//if youre not a player (IE if you are part of the level)
		if (c.gameObject.transform.root.GetComponent<PlayerController>() == null && 
		    c.gameObject.GetComponent<StickyBomb>() == null)
		{
			if(PhotonNetwork.isMasterClient)
			{
				GetComponent<PhotonView>().RPC("HitGround", PhotonTargets.All, null);
			}
		}
	}
}
