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

    // Đối tượng PhotonView để đồng bộ hóa qua mạng
    private PhotonView m_photonView;

    // Biến để kiểm tra trạng thái đồng bộ ban đầu
    private bool m_syncedInitialState;

    // Hàm Awake được gọi khi đối tượng được khởi tạo
    private void Awake()
    {
        // Lấy PhotonView từ component
        m_photonView = GetComponent<PhotonView>();
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
    public void SyncAddToSlot(int slotID, ItemDescriptor itemDescriptor)
    {
        byte[] array = itemDescriptor.data.Serialize();
        m_photonView.RPC("RPC_AddToSlot", RpcTarget.All, slotID, itemDescriptor.item.id, array);
    }

    // Hàm đồng bộ xóa slot
    public void SyncClearSlot(int slotID)
    {
        m_photonView.RPC("RPC_ClearSlot", RpcTarget.All, slotID);
    }

    // Hàm RPC để thêm item vào slot
    [PunRPC]
    public void RPC_AddToSlot(int slotID, byte itemID, byte[] data)
    {
        ItemInstanceData itemInstanceData = new ItemInstanceData(Guid.Empty);
        itemInstanceData.Deserialize(data);
        if (ItemDatabase.TryGetItemFromID(itemID, out var item))
        {
            if (TryGetSlot(slotID, out var slot))
            {
                slot.AddLocal(new ItemDescriptor(item, itemInstanceData));
                VerboseDebug.Log($"adding item:{itemID} to slot: {slotID}");
            }
            else
            {
                Debug.LogError($"Failed to get slot {slotID}");
            }
        }
    }

    // Hàm RPC để xóa slot
    [PunRPC]
    public void RPC_ClearSlot(int slotID)
    {
        if (TryGetSlot(slotID, out var slot))
        {
            slot.ClearLocal();
            VerboseDebug.Log($"clearing slot: {slotID}");
        }
        else
        {
            Debug.LogError($"Failed to get slot {slotID}");
        }
    }

    // Hàm tuần tự hóa inventory
    private byte[] SerializeInventory()
    {
        BinarySerializer binarySerializer = new BinarySerializer(96, Allocator.Temp);
        for (int i = 0; i < slots.Length; i++)
        {
            bool flag = slots[i].ItemInSlot.item != null;
            binarySerializer.WriteByte((!flag) ? byte.MaxValue : slots[i].ItemInSlot.item.id);
            if (flag)
            {
                slots[i].ItemInSlot.data.Serialize(binarySerializer, createNewGuid: false);
            }
        }
        byte[] array = binarySerializer.buffer.ToArray();
        binarySerializer.Dispose();
        Debug.Log("Serializing inventory: " + array.Length);
        return array;
    }

    // Hàm cập nhật inventory
    private void UpdateInventory(byte[] inventory)
    {
        VerboseDebug.Log("Updating inventory: " + inventory.Length);
        if (m_syncedInitialState)
        {
            return;
        }
        m_syncedInitialState = true;
        BinaryDeserializer binaryDeserializer = new BinaryDeserializer(new NativeArray<byte>(inventory, Allocator.Temp));
        ItemDescriptor[] array = new ItemDescriptor[slots.Length];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = default(ItemDescriptor);
            byte b = binaryDeserializer.ReadByte();
            if (b < byte.MaxValue)
            {
                ItemInstanceData itemInstanceData = new ItemInstanceData(Guid.Empty);
                itemInstanceData.Deserialize(binaryDeserializer);
                if (ItemDatabase.TryGetItemFromID(b, out var item))
                {
                    array[i] = new ItemDescriptor(item, itemInstanceData);
                }
                else
                {
                    Debug.LogError($"Failed to get item from id {b}");
                }
            }
            else
            {
                array[i] = ItemDescriptor.Empty;
            }
        }
        binaryDeserializer.Dispose();
        for (int j = 0; j < array.Length; j++)
        {
            ItemDescriptor item2 = array[j];
            if (item2.item != null)
            {
                slots[j].AddLocal(item2);
            }
            else
            {
                slots[j].ClearLocal();
            }
        }
    }

    // Hàm đồng bộ inventory với người khác
    public void SyncInventoryToOthers()
    {
        byte[] array = SerializeInventory();
        m_photonView.RPC("RPC_SyncInventoryToOthers", RpcTarget.Others, array);
    }

    // Hàm RPC để đồng bộ inventory với người khác
    [PunRPC]
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