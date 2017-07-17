# MiniBind
Simple DataBinding framework for Unity3D

#How to use
Add any binding component to gameobject and set key. Eg. Add <b>TextBinding</b> to an <b>UI Text</b> gameobject and set key to <b>"test.text"</b>

Before setting value of this text, add this MiniBind field to your code to use it easily:

```csharp
private MiniBind uiContext
{
	get
	{
		return MBManager.Inst[MBContexts.UI_CONTEXT];
	}
}
```

To set value, call this code:


```csharp
uiContext.SetValue("test.text", "Hello world!");
```
