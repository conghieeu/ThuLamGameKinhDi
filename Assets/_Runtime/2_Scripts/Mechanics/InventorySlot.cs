public class InventorySlot
{
	private PlayerInventory m_inventory;
	public int SlotID { get; private set; }
	public ItemDescriptor ItemInSlot { get; private set; }

	public InventorySlot(int slotID, PlayerInventory playerInventory)
	{
		SlotID = slotID;
		m_inventory = playerInventory;
	}

	public void Clear()
	{
		if (ItemInSlot.item != null)
		{
		}
	}

	public void ClearLocal()
	{
		if (!(ItemInSlot.item == null))
		{
			ItemInSlot = ItemDescriptor.Empty;
		}
	}

	public void Add(ItemDescriptor item)
	{
		if (ItemInSlot.item == null)
		{
		}
	}
}
