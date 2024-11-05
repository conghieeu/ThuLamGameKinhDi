using System;

[Serializable]
public class ItemKeyTooltip : IHaveUIData
{
	public string m_key;

	public ItemKeyTooltip(string key)
	{
		m_key = key;
	}

	public string GetString()
	{
		return m_key;
	}
}
