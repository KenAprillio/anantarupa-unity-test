using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cooldown
{
	[SerializeField] private float cooldownTime = 1;
	private float nextInteractTime;
	
	public bool IsCoolingDown => Time.time < nextInteractTime;
	
	public void StartCooldown() => nextInteractTime = Time.time + cooldownTime;
}
