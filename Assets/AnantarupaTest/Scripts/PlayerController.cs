using System.Collections.Generic;
using UnityEngine;

namespace ProgrammerTest
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private Transform playerView;
		private bool _facingRight = true;
		private const float Speed = 10f;
		[SerializeField] private List<ObjectInteract> objectList;
		private int col;


		void Update()
		{
			if (Input.GetKey(KeyCode.A))
			{
				MoveHorizontal(Vector3.left);
				if (_facingRight)
				{
					_facingRight = false;
					UpdateFacing();
				}
			}
			else if (Input.GetKey(KeyCode.D))
			{
				MoveHorizontal(Vector3.right);
				if (!_facingRight)
				{
					_facingRight = true;
					UpdateFacing();
				}
			}
			
			if (Input.GetKeyDown(KeyCode.E))
			{
				StartInteract();
			}
		}

		private void MoveHorizontal(Vector3 direction)
		{
			transform.position += (direction * Speed * Time.deltaTime);
		}

		private void UpdateFacing()
		{
			playerView.localScale = new Vector3(_facingRight ? 1 : -1, 1, 1);
		}
		
		private void StartInteract()
		{
			// Checks if List has items
			if (objectList.Count == 0) return;
			
			// Interacts with the first item on the list
			objectList[0].Interact();
		}
		
		private void OnTriggerEnter(Collider other) {
			// Adds the ObjectInteract object to the list when trigger enter
			if(other.TryGetComponent(out ObjectInteract obj)) 
				objectList.Add(obj);
		}
		
		private void OnTriggerExit(Collider other) {
			// Removes the ObjectInteract object to the list when trigger exit
			if(other.TryGetComponent(out ObjectInteract obj))
				objectList.Remove(obj);
		}
	}
}