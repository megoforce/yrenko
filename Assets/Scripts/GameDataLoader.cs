﻿using UnityEngine;
using System.Collections;
using SimpleJSON;


public class GameDataLoader : MonoBehaviour {
	public bool forceReset = false;
	public float lat;
	public float lng;
	public string country;
	public float temperature;
	public float humidity;
	public float pressure;
	public float weather;
	IEnumerator Start() {
		Debug.Log ("Searching for weather data...");
		
		GlobalStuff.instance.gUIManager.labelTop.text = "CONNECTING...";
		GlobalStuff.instance.gUIManager.labelBottom.text = "";
		lat=RandomExt.RandomFloatBetween(-90,90);
		lng=RandomExt.RandomFloatBetween(-180,180);
		Debug.Log (lat);
		string url = "http://api.openweathermap.org/data/2.5/weather?lat=" + lat.ToString () + "&lon=" + lng.ToString ();
		Debug.Log(url);
		WWW request = new WWW(url);
		Debug.Log (request);
		yield return request;

		if (request.error == null || request.error == "")
		{
			// {"coord":{"lon":"-94.61", "lat":"41.63"}
			// "sys":{"type":"1", "id":"848", "message":"0.1384", "country":"US", "sunrise":"1408793759", "sunset":"1408842346"}
			// "weather":[ {"id":"802", "main":"Clouds", "description":"scattered clouds", "icon":"03d"} ]
			// "base":"cmc stations"
			// "main":{"temp":"300.46", "pressure":"1013", "humidity":"83", "temp_min":"299.15", "temp_max":"302.15"}
			// "wind":{"speed":"3.6", "deg":"160"}
			// "clouds":{"all":"40"}
			// "dt":"1408822294"
			// "id":"4859491"
			// "name":"Guthrie Center"
			// "cod":"200"}


			var N = JSON.Parse(request.text);
			
			Debug.Log(N);
			country=N["sys"]["country"].Value;
			temperature=float.Parse(N["main"]["temp"].Value);
			humidity=float.Parse(N["main"]["humidity"].Value);
			pressure=float.Parse(N["main"]["pressure"].Value);
			Debug.Log(N["weather"][0]["id"].Value);

			weather=float.Parse(N["weather"][0]["id"].Value);


			GlobalStuff.instance.gUIManager.labelTop.text = "olakease";

		}
		else
		{
			Debug.Log("WWW error: " + request.error);
		}


	}
	void Awake(){
		if(PlayerPrefs.GetInt("isNotFirstTime") != 1 || forceReset){
			print("Is first time");
			ResetData();
		}
	}
	public static void ResetData(){
		Debug.Log("Reset Data!");
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("isNotFirstTime",1);
		
	}
}
