using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SingletonTag : MonoBehaviour
{
	private readonly static Dictionary<string, SingletonTag> _instances = new();
	public static IReadOnlyDictionary<string, SingletonTag> Instances => _instances;

	public bool AddTag(string tag)
	{
		if (tag == null
			|| (Instances.ContainsKey(tag) && Instances[tag] != this))
			return false;
		_instances[tag] = this;
		return true;
	}

	public bool AddTag()
	{
		return this.AddTag(this.gameObject.tag);
	}

	public void RemoveTag(string tag)
	{
		if (tag == null || !Instances.ContainsKey(tag) || Instances[tag] != this)
			return; 
		_instances.Remove(this.OldTag);
	}

	public void RemoveTag()
	{
		this.RemoveTag(this.gameObject.tag);
	}

	public string OldTag { get; private set; } = null;

	public bool UpdateTag(string tag)
	{
		if (this.OldTag == tag)
			return true;
		this.RemoveTag(this.OldTag);
		this.OldTag = tag;
		return this.AddTag(tag);
	}

	public bool UpdateTag()
	{
		return this.UpdateTag(this.gameObject.tag);
	}

	private void Awake()
	{
		if (!this.AddTag())
			Destroy(this.gameObject);
	}

	private void Update()
	{
		if (!this.UpdateTag())
			Destroy(this.gameObject);
	}

	private void OnDestroy()
	{
		this.RemoveTag();
	}
}
