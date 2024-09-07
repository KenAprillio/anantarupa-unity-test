using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/* Rather than using a new script for each object actions,
	we will use this single ObjectInteract Script as an
	executor for all the actions it gets fed to. */
public class ObjectInteract : MonoBehaviour
{
	[SerializeField] Cooldown cooldown;
	[SerializeField] private SpriteRenderer buttonPrompt;
	[SerializeField] private Sprite interactSprite;
	[SerializeField] private Sprite uninteractSprite;
	
	// Actions to do when interacted
	public UnityEvent onInteract;
	
	// Actions to do when interacted but will run on Update
	public UnityEvent onInteractUpdate;
	
	// Actions to do after cooldown has ended
	public UnityEvent afterCooldown;
	
	
	Collider[] colliderArr = new Collider[10];
	int col;
	
	
	private void Start() 
	{
		// Using Invoke Repeating rather than update so it doesnt check every frame but once every few frames
		InvokeRepeating("CheckPlayer", .5f, .2f);
	}
	
	private void Update() {
		if(!cooldown.IsCoolingDown)
		{
			afterCooldown.Invoke();
		} else
		{
			onInteractUpdate.Invoke();
		}
	}
	
	// Method to detect if player is around using OverlapSphereNonAlloc
	private void CheckPlayer()
	{
		col = Physics.OverlapSphereNonAlloc(transform.position, 1.2f, colliderArr);
		
		for (int i = 0; i < col; i++)
		{
			if(colliderArr[i].tag == "Player")
			{
				if (cooldown.IsCoolingDown) buttonPrompt.sprite = uninteractSprite;
				else buttonPrompt.sprite = interactSprite;
				
				buttonPrompt.gameObject.SetActive(true);
			} else
			{
				buttonPrompt.gameObject.SetActive(false);
			}
		}
	}
	
	// Method to be called when player press E or interact
	public void Interact()
	{
		if (cooldown.IsCoolingDown) return;
		
		onInteract.Invoke();
		cooldown.StartCooldown();
	}
}
