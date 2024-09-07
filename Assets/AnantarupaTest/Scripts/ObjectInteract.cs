using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectInteract : MonoBehaviour
{
	[SerializeField] Cooldown cooldown;
	[SerializeField] private SpriteRenderer buttonPrompt;
	[SerializeField] private Sprite interactSprite;
	[SerializeField] private Sprite uninteractSprite;
	
	public UnityEvent onInteract;
	public UnityEvent onInteractUpdate;
	public UnityEvent afterCooldown;
	
	
	Collider[] colliderArr = new Collider[10];
	
	private void Start() {
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
	
	private void CheckPlayer()
	{
		int col = Physics.OverlapSphereNonAlloc(transform.position, 1.3f, colliderArr);
		
		for (int i = 0; i < col; i++)
		{
			if(colliderArr[i].tag == "Player")
			{
				if (cooldown.IsCoolingDown)
				{
					buttonPrompt.sprite = uninteractSprite;
				} else
				{
					buttonPrompt.sprite = interactSprite;
				}
				buttonPrompt.gameObject.SetActive(true);
			} else
			{
				buttonPrompt.gameObject.SetActive(false);
			}
		}
	}
	
	public void Interact()
	{
		if (cooldown.IsCoolingDown) return;
		
		onInteract.Invoke();
		cooldown.StartCooldown();
	}
}
