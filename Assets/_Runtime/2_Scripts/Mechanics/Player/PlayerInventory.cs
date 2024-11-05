using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
public class PlayerInventory : MonoBehaviour
{
    public Item[] itemsToSpawnWith;

    // Hằng số định nghĩa vị trí của slot dành cho Artifact
    public const int ARTIFACT_SLOT = 3;

    // Mảng các slot trong inventory, có 4 slot
    public InventorySlot[] slots = new InventorySlot[4];

    // Item dành cho emote
    public Item emote;

    // Biến để kiểm tra trạng thái đồng bộ ban đầu
    private bool m_syncedInitialState;

    // Hàm Awake được gọi khi đối tượng được khởi tạo
    private void Awake()
    {
        // Khởi tạo các slot trong inventory
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new InventorySlot(i, this);
        }
    }

    // Hàm thử lấy slot chứa item cụ thể
    public bool TryGetSlotWithItem(Item item, out InventorySlot slot)
    {
        // Kiểm tra nếu item là null
        if (item == null)
        {
            Debug.LogError("Failed to get slot with item: item is null");
            slot = null;
            return false;
        }
        // Duyệt qua các slot để tìm item
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].ItemInSlot.item == item)
            {
                slot = slots[i];
                return true;
            }
        }
        slot = null;
        return false;
    }

    // Hàm thử lấy slot chứa loại item cụ thể
    public bool TryGetSlotWithItemType(Item.ItemType itemType, out InventorySlot slot)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].ItemInSlot.item != null && slots[i].ItemInSlot.item.itemType == itemType)
            {
                slot = slots[i];
                return true;
            }
        }
        slot = null;
        return false;
    }

    // Hàm thử lấy slot trống
    public bool TryGetFeeSlot(out InventorySlot slot)
    {
        for (int i = 0; i < 3; i++)
        {
            if (slots[i].ItemInSlot.item == null)
            {
                slot = slots[i];
                return true;
            }
        }
        slot = null;
        return false;
    }

    // Hàm thử lấy slot theo ID
    public bool TryGetSlot(int slotID, out InventorySlot slot)
    {
        if (slotID >= 0 && slotID < slots.Length)
        {
            slot = slots[slotID];
            return true;
        }
        slot = null;
        return false;
    }

    // Hàm thử thêm item vào inventory
    public bool TryAddItem(ItemDescriptor item)
    {
        InventorySlot slot;
        return TryAddItem(item, out slot);
    }

    // Hàm thử thêm item vào inventory và trả về slot
    public bool TryAddItem(ItemDescriptor item, out InventorySlot slot)
    {
        Item.ItemType itemType = item.item.itemType;
        if (itemType == Item.ItemType.Artifact || itemType == Item.ItemType.Disc)
        {
            slot = slots[3];
            if (slot.ItemInSlot.item != null)
            {
                return false;
            }
            slots[3].Add(item);
            return true;
        }
        if (TryGetFeeSlot(out slot) && slot.SlotID < 3)
        {
            slot.Add(item);
            return true;
        }
        slot = null;
        return false;
    }

    // Hàm thử xóa item khỏi slot theo ID
    public bool TryRemoveItemFromSlot(int slotID, out ItemDescriptor item)
    {
        if (TryGetSlot(slotID, out var slot) && slot.ItemInSlot.item != null)
        {
            item = slot.ItemInSlot;
            slot.Clear();
            return true;
        }
        item = ItemDescriptor.Empty;
        return false;
    }

    // Hàm thử xóa item theo loại
    public bool TryRemoveItemOfType(Item item, out InventorySlot slot)
    {
        if (TryGetSlotWithItem(item, out slot))
        {
            slot.Clear();
            return true;
        }
        slot = null;
        return false;
    }

    // Hàm thử lấy item trong slot theo ID
    public bool TryGetItemInSlot(int slotID, out ItemDescriptor item)
    {
        if (TryGetSlot(slotID, out var slot) && slot.ItemInSlot.item != null)
        {
            item = slot.ItemInSlot;
            return true;
        }
        item = ItemDescriptor.Empty;
        return false;
    }

    // Hàm đồng bộ thêm item vào slot

    // Hàm đồng bộ xóa slot

    // Hàm RPC để thêm item vào slot

    // Hàm RPC để xóa slot

    // Hàm tuần tự hóa inventory

    // Hàm cập nhật inventory
    private void UpdateInventory(byte[] inventory)
    {
      
    }

    // Hàm đồng bộ inventory với người khác

    // Hàm RPC để đồng bộ inventory với người khác
    public void RPC_SyncInventoryToOthers(byte[] inventory)
    {
        UpdateInventory(inventory);
    }

    // Hàm LateUpdate, hiện tại không có chức năng
    private void LateUpdate()
    {
    }

    // Hàm lấy danh sách các item trong inventory
    public List<ItemDescriptor> GetItems()
    {
        List<ItemDescriptor> list = new List<ItemDescriptor>();
        InventorySlot[] array = slots;
        foreach (InventorySlot inventorySlot in array)
        {
            if (inventorySlot.ItemInSlot.item != null)
            {
                list.Add(inventorySlot.ItemInSlot);
            }
        }
        return list;
    }

    // Hàm xóa toàn bộ inventory
    public void Clear()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Clear();
        }
    }
}