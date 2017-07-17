namespace MiniBind.Components
{
	public class ListItemBinding : UIComponentBinding
	{
		protected override void OnValueChanged() { }

		public override void SetKey(string newKey)
		{
			base.SetKey(newKey);
			UpdateChildKeys();
		}

		private void UpdateChildKeys()
		{
			UIComponentBinding[] components = gameObject.GetComponentsInChildren<UIComponentBinding>(true);
			for (int i = 0; i < components.Length; i++)
			{
				if (components[i] == this) continue;
				string oldkey = components[i].originalKey;
				components[i].SetKey(GetKey() + oldkey);
			}
		}
	}
}