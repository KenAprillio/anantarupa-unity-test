using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is a Scriptable Object to store all the object actions/methods
	rather than using multiple scripts for each object with different 
	actions */

[CreateAssetMenu(fileName = "Object Action SO")]
public class ObjectActionsSO : ScriptableObject
{
	Cooldown cooldown;
		
	public void ShowDialogue(GameObject dialogue) => dialogue.SetActive(true);
	public void HideDialogue(GameObject dialogue) => dialogue.SetActive(false);
	
	bool isScaled = false;
	public void ScaleObject(GameObject obj)
	{
		if (!isScaled)
		{
			obj.transform.localScale = new Vector3(2,2,2);
			isScaled = true;
		} else
		{
			obj.transform.localScale = new Vector3(1,1,1);
			isScaled = false;
		}
	}
	
	GameObject playerObj;
	public void MoveObject(GameObject self)
	{
		if(!playerObj) playerObj = GameObject.FindGameObjectWithTag("Player");
		
		if (playerObj.transform.position.x > self.transform.position.x)
		{
			self.transform.Translate(Vector3.left * 4 * Time.deltaTime);
		} else
		{
			self.transform.Translate(Vector3.right * 4 * Time.deltaTime);
		}
	}
}
