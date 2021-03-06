﻿using UnityEngine;


//
// Script Name: End Game  Check
//Script by: Victor L Josey
// Description: Check game board for end game conditions and triggers the end game state.
// (c) 2015 Shoori Studios LLC  All rights reserved.



public class EndGameCheck : MonoBehaviour {

	public  int playablePegsNum;
	
	public GameManger Game;

	  

	void OnEnable () 
	{
		Messenger.AddListener("Check Empties", EmptyCheck);
		Messenger.MarkAsPermanent("Check Empties");
	
	}

	void Start()
	{

	
	}
	

// Look for  Empty peg types
	public void EmptyCheck()
	{

		playablePegsNum = 0;

		GameManger.CURRENT_NUM_EMPTY = 0;
		
		for(int i = 0; i < board.TokenData.Count; i++)
		{
			
			if (board.TokenData[i].PegType.blockType == PegTypeMach.BlockType.Empty){
				GameManger.CURRENT_NUM_EMPTY++;
				board.TokenData[i].posStatus.Closed = true;
			}else{

				board.TokenData[i].posStatus.Closed = false;
			}

			board.TokenData[i].pagState_pUpdater.CheckNeighbor();

			// find EndPegs
			if(board.TokenData[i].posStatus.posState == PosStatus.PosState.ReadyPeg)
			{
				playablePegsNum++;
			}


		}

		if(playablePegsNum == 0 && Time.timeSinceLevelLoad > 10f)
		{
			// End Game
			Game.EndGame();
		}

	} 


	void OnDisable()
	{
		Messenger.RemoveListener("Check Empties", EmptyCheck);
	}

}
