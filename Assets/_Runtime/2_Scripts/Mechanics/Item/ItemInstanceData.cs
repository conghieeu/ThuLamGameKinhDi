using System;
using System.Collections.Generic; 
using Unity.Collections;
using UnityEngine;

public class ItemInstanceData
{
	public Guid m_guid;

	public HashSet<ItemDataEntry> m_dataEntries = new HashSet<ItemDataEntry>();

	public float timeSinceGrounded;

	private bool isHeld;

	private bool isHeldByMe;

	public float timeInHand;

	public ItemInstanceData(Guid guid)
	{
		m_guid = guid;
	}

	public bool TryGetEntry<T>(out T t) where T : ItemDataEntry
	{
		foreach (ItemDataEntry dataEntry in m_dataEntries)
		{
			if (dataEntry is T val)
			{
				t = val;
				return true;
			}
		}
		t = null;
		return false;
	}

	public void TryGetElseAdd<T>(ref T startValue) where T : ItemDataEntry
	{
		if (TryGetEntry<T>(out var t))
		{
			startValue = t;
		}
		else
		{
			AddDataEntry(startValue);
		}
	}

	public bool TryGetEntry(Type type, out ItemDataEntry t)
	{
		foreach (ItemDataEntry dataEntry in m_dataEntries)
		{
			if (dataEntry.GetType() == type)
			{
				t = dataEntry;
				return true;
			}
		}
		t = null;
		return false;
	}

	public void AddDataEntry(ItemDataEntry entry)
	{
		m_dataEntries.Add(entry);
	}

	public void RemoveDataEntry(ItemDataEntry entry)
	{
		m_dataEntries.Remove(entry);
	}


	public bool IsDirty()
	{
		foreach (ItemDataEntry dataEntry in m_dataEntries)
		{
			if (dataEntry.IsDirty())
			{
				return true;
			}
		}
		return false;
	}

	public bool IsForceDirty()
	{
		foreach (ItemDataEntry dataEntry in m_dataEntries)
		{
			if (dataEntry.IsForceDirty())
			{
				return true;
			}
		}
		return false;
	}

	public void ClearForceDirty()
	{
		foreach (ItemDataEntry dataEntry in m_dataEntries)
		{
			dataEntry.ClearForceDirty();
		}
	}

	public void ClearDirty()
	{
		foreach (ItemDataEntry dataEntry in m_dataEntries)
		{
			dataEntry.ClearDirty();
		}
	}

}
