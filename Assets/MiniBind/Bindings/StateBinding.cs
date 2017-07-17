using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniBind.Components
{
	public class StateBinding : UIComponentBinding
	{
		public List<State> states;

		protected override void OnValueChanged()
		{
			string stateId = GetValue<string>();
			UpdateGameObjects(stateId);
		}

		private void UpdateGameObjects(string stateId) 
		{
			foreach (State state in states) 
			{
				if (stateId != null && stateId.Equals(state.stateId))
				{
					SetState(state, true);
				}
				else 
				{
					SetState(state, false);
				}
			}
		}

		private void SetState(State state, bool value) 
		{ 
			foreach (GameObject go in state.enabledGameObjects)
			{
				go.SetActive(value);
			}

			foreach (GameObject go in state.disabledGameObjects)
			{
				go.SetActive(!value);
			}
		} 

	}

	[System.Serializable]
	public class State 
	{
		public string stateId;
		public List<GameObject> enabledGameObjects = new List<GameObject>();
		public List<GameObject> disabledGameObjects = new List<GameObject>();
	}
}