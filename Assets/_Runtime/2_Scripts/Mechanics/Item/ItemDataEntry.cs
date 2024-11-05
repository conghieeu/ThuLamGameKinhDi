
public abstract class ItemDataEntry
{
	private bool m_dirty;

	private bool m_forceDirty;

	public void SetDirty()
	{
		m_dirty = true;
	}

	public void SetForceDirty()
	{
		m_forceDirty = true;
	}

	public bool IsDirty()
	{
		return m_dirty;
	}

	public bool IsForceDirty()
	{
		return m_forceDirty;
	}

	public void ClearDirty()
	{
		m_dirty = false;
	}

	public void ClearForceDirty()
	{
		m_forceDirty = false;
	}
}
