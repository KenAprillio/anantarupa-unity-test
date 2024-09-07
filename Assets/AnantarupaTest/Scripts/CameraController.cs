using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProgrammerTest
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField] private Transform followTarget;
		[SerializeField] private Vector3 offset;

		void LateUpdate()
		{
			transform.position = followTarget.position + offset;
		}
	}
}