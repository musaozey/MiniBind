using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniBind.Components
{
	public class ListBinding : UIComponentBinding
	{
		private const char LIST_STRING_SEPERATOR = ',';
		private Action<List<ListItemBinding>> OnItemsCreated;

		public ListItemBinding listItem;
		List<ListItemBinding> items = new List<ListItemBinding>();
		List<ListItemBinding> pooledItems = new List<ListItemBinding>();

		Coroutine notifyCoroutine;

		protected override void OnValueChanged()
		{
			string value = GetValue<string>();
			ClearItems();
			if (!string.IsNullOrEmpty(value))
			{
				CreateItems(value);
			}
		}

		private ListItemBinding GetItemFromPool()
		{
			ListItemBinding item;
			if (pooledItems.Count == 0)
			{
				item = Instantiate(listItem, null) as ListItemBinding;
			}
			else
			{
				item = pooledItems[0];
				pooledItems.Remove(item);
			}
			return item;
		}

		private void ReturnItemToPool(ListItemBinding item)
		{
			item.gameObject.SetActive(false);
			item.transform.SetParent(null);
			pooledItems.Add(item);
		}

		private void ClearItems()
		{
			for (int i = 0; i < items.Count; i++)
			{
				ReturnItemToPool(items[i]);
			}
			items.Clear();
		}

		private void CreateItems(string s)
		{
			string[] splittedString = s.Split(LIST_STRING_SEPERATOR);

			for (int i = 0; i < splittedString.Length; i++)
			{
				ListItemBinding item = GetItemFromPool();
				item.transform.SetParent(transform);
				item.SetKey(splittedString[i]);
				item.transform.localScale = Vector3.one;
				item.transform.position = Vector3.zero;
				items.Add(item);
				item.gameObject.SetActive(true);
			}

			if (gameObject.activeInHierarchy)
			{
				notifyCoroutine = StartCoroutine(NotifyOnItemsCreated());
			}
		}

		private IEnumerator NotifyOnItemsCreated()
		{
			yield return new WaitForEndOfFrame();
			if (OnItemsCreated != null)
			{
				OnItemsCreated(GetCurrentListItems());
			}
			notifyCoroutine = null;
		}

		void OnDisable() 
		{
			if (notifyCoroutine != null)
			{
				StopCoroutine(notifyCoroutine);
				notifyCoroutine = null;
			}
		}

		/// <summary>
		/// Adds listener to OnItemsCreated action;
		/// </summary>
		public void AddListener(Action<List<ListItemBinding>> action)
		{
			OnItemsCreated += action;
			action(GetCurrentListItems());
		}

		public List<ListItemBinding> GetCurrentListItems()
		{
			return new List<ListItemBinding>(items);
		}

		public static string CreateListString(string itemKey, int count)
		{
			List<string> items = new List<string>();
			for (int i = 0; i < count; i++)
			{
				items.Add(string.Format(itemKey, i));
			}
			string itemString = string.Join(LIST_STRING_SEPERATOR.ToString(), items.ToArray());
			return itemString;
		}
	}
}