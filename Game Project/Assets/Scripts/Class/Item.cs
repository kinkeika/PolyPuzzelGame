﻿using UnityEngine;
using System.Collections;



public class Item : MonoBehaviour {

	public Sprite spriteNeutral;

	[HideInInspector]
	public int maxSize = 1;

	public float itemTime;

	public bool onDissolve = false;

//	public string type = "Item";

	public enum Rarity
	{
		Common,
		Uncommon,
		Rare,
		VeryRare
	}

	public Rarity rarity = Rarity.Common;


	public bool timeIsActive = true;

	[HideInInspector]
	public PegStateMachine PegObject;


	// Use this for initialization
	public virtual void Start () {
		maxSize = 1;
	}

	public Item(Item item)
	{
		spriteNeutral = item.spriteNeutral;
		itemTime = 		item.itemTime;
		timeIsActive = item.timeIsActive;

	}

	public Item()
	{

	}


	
	public virtual void Use()
	{
		Debug.Log ("Using this Item Plus 11000 points");
		GameManger.TOTAL_POINTS_COUNT += 11000;
	}


	public virtual void OnItemDissolve()
	{


	}

}