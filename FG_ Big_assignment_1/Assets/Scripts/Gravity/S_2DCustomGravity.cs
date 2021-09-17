using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class S_2DCustomGravity
{
	/*
	* This script adds gravitational force to all objects in the gravitySource list.
	*/
	static List<S_2DGravitySource> sources = new List<S_2DGravitySource>();

	public static Vector2 GetGravity(Vector2 position) //Loops trough all active sources of gravity and acumulates thier gravity
	{
		Vector2 g = Vector2.zero;
		for (int i = 0; i < sources.Count; i++)
		{
			g += sources[i].GetGravity(position);
		}
		return g;
	}

	public static Vector2 GetGravity(Vector2 position, out Vector2 upAxis) //Loops trough all active sources of gravity and acumulates thier gravity and gets the up vector of them
	{
		Vector2 g = Vector2.zero;
		for (int i = 0; i < sources.Count; i++)
		{
			g += sources[i].GetGravity(position);
		}
		upAxis = -g.normalized;
		return g;
	}

	public static Vector2 GetUpAxis(Vector2 position) //Loops trough all active sources of gravity and returns thier up axis
	{
		Vector2 g = Vector2.zero;
		for (int i = 0; i < sources.Count; i++)
		{
			g += sources[i].GetGravity(position);
		}
		return -g.normalized;
	}

	public static void Register(S_2DGravitySource source) // Registers the gravity sources to the list
	{
		Debug.Assert(!sources.Contains(source), "Duplicate registration of gravity source!", source);
		sources.Add(source);
	}

	public static void Unregister(S_2DGravitySource source) // Unregisters the gravity sources from the list
	{
		Debug.Assert(sources.Contains(source), "Unregistration of unknown gravity source!", source);
		sources.Remove(source);
	}
}
