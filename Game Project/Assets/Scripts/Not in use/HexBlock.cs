﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexBlock : MonoBehaviour {
//	public Transform[] checkPoints = new Transform[6]; 
//
//
//
//	public enum BlockType {
//		Flow,
//		Stone,
//		Fire,
//		Lite,
//		Shield,
//		Sword,
//		Spear,
//		Wealth,
//		Wisdom,
//		TimeType,
//		Destruction,
//		Darkness,
//		Empty
//	}
//	
//
//
//	public BlockType blockType = BlockType.Flow;
//
//
//	public enum BlockState{
//		Uncapable,
//		Active,
//		Normal,
//		Dissolve,
//		Hover,
//		Selected,
//		Move
//	}
//
//	public BlockState blockState = BlockState.Normal;
//
//	 
//	public HexBlock[] neighborHEX = new HexBlock[6];
//
//	public bool isJumpable = false;
//	public bool moveIn  = false;  // if a block is empty and block can move into there set true 
//	public int 	tokenIndex;      //indcate what side the sending  neighbor is on.
//
//	private int _ping = 0;
//	private int _nullPing = 0;
//
//
//	public HexType hexType;
//
//	public int bonusPoints = 0;
//
//	public ItemAttachment AttachedItem;
//
//	public HexPositionStatus posStatus;
//
//
//
//	void Awake(){
//		
//
//		hexType = new HexType(HexType.BlockType.Fire);
//
//	}
//	
//	// Use this for initialization
//	void Start () {
//		Messenger.AddListener( "Check Neighbor", CheckNeighbor );
//		ChangeBlockType();
//	}
//
//
//	#region Check Peg's Neighbor
//
//	public void CheckNeighbor(){
//
//		// check Peg neighbors
//	
//		RaycastHit hit;
//
//		for(int c = 0; c < checkPoints.Length; c++){
//
//			Ray ray = new Ray (checkPoints[c].position,  checkPoints[c].forward);
//
//		if (Physics.Raycast(ray , out hit,1)){
//
//				if (hit.collider.tag == "Peg"){ 
//
//
//					//Debug.Log ("Hit object at check point " + (c + 1 ) + " "+ hit.collider.name );
//					if(neighborHEX[c] == null){
//					neighborHEX[c] = hit.collider.gameObject.GetComponent<HexBlock>();
//					}
//
//					if(blockType != BlockType.Empty){
//					if (neighborHEX[c].blockType != BlockType.Empty ){
//						//Debug.Log (" check next");
//						neighborHEX[c].SecondNeighborCheck(c); }
//					}else{
//
//
//						if (neighborHEX[c].blockType != BlockType.Empty ){
//
//						}
//
//					}
//
//					// use for end game condition n = null side
//
//					if (neighborHEX[c].blockType == BlockType.Empty )
//					{
//						posStatus.side[c] = 'E';
//					}else
//					{
//						posStatus.side[c] = 'C';
//					}
//
//				}else{
//					// if ray hit any other object onther then Peg tag
//					posStatus.side[c] = 'N';
//				}
//
//			}else{
//				// if ray doesnt hit any thing
//				posStatus.side[c] = 'N';
//			}
//		
//		}
//
//
//		// Set Status
//		SetHexPosStat();
//
//	}
//	#endregion
//
//
//
//
//
//	void OnMouseOver() {
//
//		if(blockState != BlockState.Active && blockType != BlockType.Empty && blockState != BlockState.Uncapable ){
//		blockState = BlockState.Hover;
//		ChangeBlockState();
//		}else
//
//		if (moveIn == true && blockType == BlockType.Empty){
//			blockState = BlockState.Hover;
//			ChangeBlockState();
//		}
//
//	}
//
//	void OnMouseExit() {
//		if(blockState != BlockState.Active && blockState != BlockState.Uncapable ){
//		blockState = BlockState.Normal;
//			ChangeBlockState();
//		}
//
//		//if active set empty blocks back false
//		if(GameManger.ACTIVE == false){
//			moveIn = false;
//		}
//
//	}
//
//	void OnMouseUp() {
//		//Debug.Log("Drag ended!");
//	}
//
//
//	void OnMouseDown() {
//	
//		//if a block is full, when click on check if there are any other active blocks. if not set to active
//		if(blockState != BlockState.Active && GameManger.ACTIVE == false && blockType != BlockType.Empty)
//		{
//			blockState = BlockState.Active;
//		//	GameManger.CURRENT_OPEN_BLOCK.moveIn = false;
//
//		}else if(blockState == BlockState.Active){
//			// if this block is active when clicked on de-activeate it
//			GameManger.ACTIVE = false;
//			GameManger.CURRENT_OPEN_BLOCK.moveIn = false;
//			blockState = BlockState.Normal;
//			//if this block a empty block and another  block is  active, check  if this block can be moved into
//			}else if( GameManger.ACTIVE == true && blockType == BlockType.Empty && moveIn == true){
//			blockState = BlockState.Move;
//			GameManger.ACTIVE = false;
//
//		}
//
//		ChangeBlockState();
//		//Debug.Log("Click!");
//	}
//
//
//	public void ChangeBlockState(){
//
//		switch (blockState){
//		case BlockState.Uncapable :
//			GetComponent<Renderer>().material.color = new Color(0, 0.5f, 0.3f);
//
//			break;
//		case BlockState.Active :
//			GameManger.ACTIVE = true;
//			GameManger.CURRENT_ACTIVE_BLOCK = this.GetComponent<HexBlock>();
//			CheckNeighbor();
//			GetComponent<Renderer>().material.color = new Color(0, 1, 1);
//
//			break;
//		case BlockState.Normal : 
//			ChangeBlockType();
//			break;
//
//		case BlockState.Dissolve :
//			if(isJumpable == true){
//
//
//				//Use for Itemsystems to st peg's point worth
//				if(bonusPoints == 0)
//				{
//				GameManger.TOTAL_POINTS_COUNT += hexType.points; 
//
//				}else if(bonusPoints > 0)
//				{
//					GameManger.TOTAL_POINTS_COUNT += bonusPoints; 
//
//				}else if(bonusPoints < 0)
//				
//				{
//
//					//Do Nothing
//
//				}
//
//				// Check if item  is use on dissolve and attached
//				if(AttachedItem.AttachedItem != null && AttachedItem.AttachedItem.onDissolve == true)
//				{
//					AttachedItem.AttachedItem.OnItemDissolve();
//				}
//
//
//				bonusPoints = 0;
//				isJumpable = false;
//			}
//
//			// clear the Item thats is attach
//			AttachedItem.AttachedItem = null;
//
//			blockType = BlockType.Empty; // Call change type on normal state
//
//			blockState = BlockState.Normal;
//			//Update the number of empty blocks
//			EmptyPing();
//			UpdateNeighbor();
//			ChangeBlockState();
//			break;
//		case BlockState.Hover	:
//			ChangeBlockType();
//			GetComponent<Renderer>().material.color = new Color(0, 30, 1);
//
//			break;
//		case BlockState.Selected : 
//
//			GetComponent<Renderer>().material.color = new Color(0, 30, 1);
//			
//			break;
//		case BlockState.Move :
//			if(GameManger.CURRENT_ACTIVE_BLOCK != null){
//				blockType = GameManger.CURRENT_ACTIVE_BLOCK.blockType; 
//
//				RaycastHit hit;
//				Ray ray = new Ray (checkPoints[tokenIndex].position,  checkPoints[tokenIndex].forward);
//				
//				if (Physics.Raycast(ray , out hit,1)){
//					if (hit.collider != null){ 
//						neighborHEX[tokenIndex] = hit.collider.gameObject.GetComponent<HexBlock>();
//						neighborHEX[tokenIndex].blockState = BlockState.Dissolve;
//						neighborHEX[tokenIndex].ChangeBlockState();
//					}}
//
//				GameManger.CURRENT_ACTIVE_BLOCK.blockState = BlockState.Dissolve;
//				//GameManger.CURRENT_ACTIVE_BLOCK.blockType  = BlockType.Empty;
//				//GameManger.CURRENT_ACTIVE_BLOCK.ChangeBlockType();
//				GameManger.CURRENT_ACTIVE_BLOCK.ChangeBlockState();
//				GameManger.CURRENT_ACTIVE_BLOCK  = null;
//
//				GameManger.TOTAL_PINGS -= _ping;
//				_ping = 0;
//				GameManger.TOTAL_NULL_PINGS -= _nullPing ;
//				_nullPing = 0;
//				UpdateNeighbor();
//
//				Messenger.Broadcast("Check Empties");
//				Debug.Log ("Check for Empties");
//			}
//			break;
//
//		}
//	}
//
//	public void ChangeBlockType(){
//
//		switch(blockType){
//		case BlockType.Flow : 
//			hexType.ChangeHexType(HexType.BlockType.Flow);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//		case BlockType.Stone : 
//			hexType.ChangeHexType(HexType.BlockType.Stone);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//		case BlockType.Fire : 
//			hexType.ChangeHexType(HexType.BlockType.Fire);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//		case BlockType.Lite : 
//			
//			hexType.ChangeHexType(HexType.BlockType.Lite);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//		case BlockType.Shield : 
//			
//			hexType.ChangeHexType(HexType.BlockType.Shield);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//		case BlockType.Sword : 
//			
//			hexType.ChangeHexType(HexType.BlockType.Sword);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//		case BlockType.Spear : 
//			hexType.ChangeHexType(HexType.BlockType.Spear);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//		case BlockType.Wealth : 
//			hexType.ChangeHexType(HexType.BlockType.Wealth);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//		case BlockType.Wisdom : 
//			
//			hexType.ChangeHexType(HexType.BlockType.Wisdom);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//		case BlockType.TimeType : 
//			hexType.ChangeHexType(HexType.BlockType.TimeType);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//			
//		case BlockType.Destruction : 
//			
//			hexType.ChangeHexType(HexType.BlockType.Destruction);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//		case BlockType.Darkness : 
//			
//			hexType.ChangeHexType(HexType.BlockType.Darkness);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//			
//		case BlockType.Empty : 
//			
//			hexType.ChangeHexType(HexType.BlockType.Empty);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//			
//		default:
//			hexType.ChangeHexType(HexType.BlockType.Fire);
//			GetComponent<Renderer>().material = hexType.blockMaterial;
//			break;
//			
//		}
//
//	
//	}
//
//	int PointIndex(int num){
//		// tell block what checkpoint to send a ray too
//		int pointNum = num;
//
//		switch(num){
//		case 0 : pointNum = 3;  break;
//		case 1 : pointNum = 4;  break;
//		case 2 : pointNum = 5;  break;
//		case 3 : pointNum = 0;  break;
//		case 4 : pointNum = 1;  break;
//		case 5 : pointNum = 2;  break;
//		default : Debug.LogWarning("Index number out of range!!"); break;
//
//		}
//		return pointNum;
//
//	}
//
//
//
//	// If block is a middle block. check next if its empty type
//
//	void SecondNeighborCheck(int index){
//		RaycastHit hit;
//
//		Ray ray = new Ray (checkPoints[index].position,  checkPoints[index].forward);
//		
//		if (Physics.Raycast(ray , out hit,1)){
//			if (hit.collider != null){ 
//	//			Debug.Log ("Hit object at check point " + (index + 1 ) + " "+ hit.collider.name );
//				neighborHEX[index] = hit.collider.gameObject.GetComponent<HexBlock>();
//
//				if (neighborHEX[index].blockType == BlockType.Empty ){
//
//					// if block one and to are compatible
//
//
//					// check avctived neighbor via revase index direction and check if the type is jumpable
//					if(CompareType(neighborHEX[PointIndex(index)].blockType ) == true){
//					isJumpable = true;
//						neighborHEX[index].moveIn = true;
//						neighborHEX[index].tokenIndex = PointIndex(index);
//						GameManger.CURRENT_OPEN_BLOCK = neighborHEX[index];
//					}else{   
//						isJumpable = false;
//						blockState = BlockState.Uncapable;
//						ChangeBlockState();
//						neighborHEX[index].moveIn = false;
//						neighborHEX[index].tokenIndex = PointIndex(index);
//					}
//				
//
//					Debug.Log (" check two! done");
//
//				}
//
//			}
//			
//		}
//	//	Debug.Log ("Index # " + index);
//	}
//
//
//	public void EmptyPing(){
//
//		RaycastHit hit;
//		
//		for(int c = 0; c < checkPoints.Length; c++){
//			
//			Ray ray = new Ray (checkPoints[c].position,  checkPoints[c].forward);
//			
//			if (Physics.Raycast(ray , out hit,1)){
//				if (hit.collider != null){ 
//						//Debug.Log ("Hit object at check point " + (c + 1 ) + " "+ hit.collider.name );
//						if(neighborHEX[c] == null){
//							neighborHEX[c] = hit.collider.gameObject.GetComponent<HexBlock>();
//						}
//
//						if (neighborHEX[c].blockType != BlockType.Empty ){
//							_ping++;
//							GameManger.TOTAL_PINGS ++;
//						}
//				}}
//
//				if(neighborHEX[c] == null){
//					_nullPing ++;
//					GameManger.TOTAL_NULL_PINGS ++;     
//				}
//			
//		
//
//		}
//
//	}  
//
//
//	// check if there a peg next to this one
//	public void UpdateNeighbor(){
//		// check block neighbors
//		
//		RaycastHit hit;
//		
//		for(int c = 0; c < checkPoints.Length; c++){
//			
//			Ray ray = new Ray (checkPoints[c].position,  checkPoints[c].forward);
//			
//			if (Physics.Raycast(ray , out hit,1)){
//				if (hit.collider != null){ 
//		
//					if (neighborHEX[c].blockType == BlockType.Empty ){
//						GameManger.TOTAL_PINGS -= neighborHEX[c]._ping ;
//						neighborHEX[c]._ping = 0;
//						GameManger.TOTAL_NULL_PINGS -= neighborHEX[c]._nullPing ;
//						neighborHEX[c]._nullPing = 0;
//						neighborHEX[c].EmptyPing();
//						}
//				}
//			}}
//	}
//
//
//
//	public  bool CompareType( BlockType hex){
//		
//		switch(hex){
//			
//		case BlockType.Flow : 
//			
//			if( hexType.Flow == true){ return true; } else {return false;}
//			
//			break;
//			
//		case BlockType.Stone : 
//			if( hexType.Stone == true){ return true; } else {return false;}
//			break;
//			
//		case BlockType.Fire : 
//			if( hexType.Fire == true){ return true; } else {return false;}
//			break;
//			
//		case BlockType.Lite : 
//			if( hexType.Lite == true){ return true; } else {return false;}
//			break;
//			
//		case BlockType.Shield : 
//			
//			if( hexType.Shield == true){ return true; } else {return false;}
//			break;
//			
//		case BlockType.Sword : 
//		      if( hexType.Sword == true){ return true; } else {return false;}
//			break;
//			
//		case BlockType.Spear : 
//			if( hexType.Spear == true){ return true; } else {return false;}
//			break;
//			
//		case BlockType.Wealth : 
//			if( hexType.Wealth == true){ return true; } else {return false;}
//			break;
//			
//		case BlockType.Wisdom : 
//			if( hexType.Wisdom == true){ return true; } else {return false;}
//			
//			break;
//		case BlockType.TimeType : 
//			
//			if( hexType.TimeType == true){ return true; } else {return false;}
//			break;
//
//		case BlockType.Destruction : 
//			
//			if( hexType.Destruction == true){ return true; } else {return false;}
//			break;
//			
//		case BlockType.Darkness : 
//			if( hexType.Darkness == true){ return true; } else {return false;}
//			
//			break;
//			
//		case BlockType.Empty : 
//			
//			if( hexType.Flow == true){ return true; } else {return false;}
//			break;
//			
//		default : if( hexType.Flow == true){ return true; } else {return false;}
//			break;
//		}
//		
//		
//	}
//
//
//
//	void SetHexPosStat()
//	{
//		posStatus.SetPositionState();
//		
//		// Check if end peg is cennected to a group
//		if( posStatus.posState == HexPositionStatus.PosState.EndPeg )
//		{
//			
//			for(int i =0; i < neighborHEX.Length; i++)
//			{
//				
//				if(neighborHEX[i] != null  && neighborHEX[i].posStatus.posState == HexPositionStatus.PosState.AlignPeg )
//				{
//					// end peg is in a group
//					posStatus.cennectedGroup = true;
//					
//					neighborHEX[i].posStatus.cennectedGroup = true;
//					
//					// set up a new group
//					if(posStatus.groupIndex == 0)
//					{
//						
//						EndGameCheck.TotalNum_GroupIndex++;
//						
//						posStatus.groupIndex = EndGameCheck.TotalNum_GroupIndex;
//						
//						EndGameCheck.groups.Add(posStatus.groupIndex, new List<HexPositionStatus>());
//						
//						EndGameCheck.groups[posStatus.groupIndex].Add(posStatus);
//						
//					}
//					
//					neighborHEX[i].posStatus.groupIndex = posStatus.groupIndex;
//				}
//				
//				
//			}
//			
//			
//			
//		}else if(posStatus.posState == HexPositionStatus.PosState.AlignPeg && posStatus.cennectedGroup == true)
//		{
//			
//			for(int i =0; i < neighborHEX.Length; i++)
//			{
//				
//				if(neighborHEX[i] != null  && neighborHEX[i].posStatus.posState == HexPositionStatus.PosState.AlignPeg )
//				{
//					neighborHEX[i].posStatus.groupIndex = posStatus.groupIndex;
//					neighborHEX[i].posStatus.cennectedGroup = true;
//				}
//			}
//		}else { posStatus.cennectedGroup = true; }
//	}
//
//
//
//	void OnDisable(){
//		
//		Messenger.RemoveListener( "Check Neighbor", CheckNeighbor  );
//
//	}
}
