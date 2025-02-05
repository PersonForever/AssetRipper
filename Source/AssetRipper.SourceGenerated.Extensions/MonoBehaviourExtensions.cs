﻿using AssetRipper.SourceGenerated.Classes.ClassID_114;
using AssetRipper.SourceGenerated.Classes.ClassID_115;

namespace AssetRipper.SourceGenerated.Extensions;

public static class MonoBehaviourExtensions
{
	/// <summary>
	/// Does this MonoBehaviour belongs to scene/prefab hierarchy? In other words, is <see cref="IMonoBehaviour.GameObject"/> a non-null pptr?
	/// </summary>
	public static bool IsSceneObject(this IMonoBehaviour monoBehaviour) => !monoBehaviour.GameObject.IsNull();

	/// <summary>
	/// Does this MonoBehaviour have a name?
	/// </summary>
	public static bool IsScriptableObject(this IMonoBehaviour monoBehaviour) => !monoBehaviour.Name.IsEmpty;

	public static bool TryGetScript(this IMonoBehaviour monoBehaviour, [NotNullWhen(true)] out IMonoScript? script)
	{
		script = monoBehaviour.ScriptP;
		return script is not null;
	}

	public static bool IsTimelineAsset(this IMonoBehaviour monoBehaviour)
	{
		return monoBehaviour.IsType("UnityEngine.Timeline", "TimelineAsset");
	}

	private static bool IsType(this IMonoBehaviour monoBehaviour, string @namespace, string name)
	{
		return TryGetScript(monoBehaviour, out IMonoScript? script) && script.IsType(@namespace, name);
	}
}
