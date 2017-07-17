using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniBind.Components
{
	public class ActiveBinding : UIComponentBinding
	{
		public List<GameObject> gameObjects = new List<GameObject>();

		protected override void OnValueChanged()
		{
			bool value = GetValue<bool>();
			foreach (GameObject go in gameObjects) 
			{
				go.SetActive(value);
			}
		}
	}
}