﻿using UnityEngine;
using System.Collections;

public class AudioSingleton : MonoBehaviour {
	private static AudioSingleton _instance;
	
	public static AudioSingleton instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<AudioSingleton>();
				
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}

}
