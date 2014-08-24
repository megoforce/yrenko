﻿using UnityEngine;
using System.Collections;

public class CharacterProperties : MonoBehaviour {
	public bool AI = false;
	public float horizontal;
	public float vertical;
	public string spriteName;
	public void Init(bool enemy){
		AI = enemy;
		spriteName = (enemy) ? "enemy" : "player";
		CharacterAnimations ca = GetComponent<CharacterAnimations>();
		ca.sprite.spriteId = ca.sprite.GetSpriteIdByName(spriteName+"/1");
	}
}