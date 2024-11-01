using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

// Tạo một menu trong Unity để tạo các đối tượng Item
[CreateAssetMenu(fileName = "Item", menuName = "W/Item", order = -1)]
public class Item : ScriptableObject
{
    // Định nghĩa các loại Item
    public enum ItemType
    {
        Camera = 0,
        Tool = 1,
        Artifact = 2,
        Disc = 3
    }

    // Tên hiển thị của Item
    [FormerlySerializedAs("shopName")]
    public string displayName;

    // Biểu tượng của Item
    public Sprite icon;

    // Đối tượng GameObject đại diện cho Item
    public GameObject itemObject;

    // Loại của Item, mặc định là Tool
    public ItemType itemType = ItemType.Tool;

    // Chi phí ngân sách cho công cụ
    [FormerlySerializedAs("toolBudget")]
    public int toolBudgetCost = 1;

    // Xác định xem Item có thể spawn hay không
    public bool spawnable;

    // Độ hiếm khi spawn của công cụ
    public Rarity toolSpawnRarity = Rarity.common;

    // Chi phí ngân sách
    public int budgetCost;

    // Độ hiếm của Item
    public float rarity = 1f;

    // Nội dung của Prop
    public PropContent content;

    // Hệ số kích thước khi đặt trên mặt đất
    public float groundSizeMultiplier = 1f;

    // Hệ số khối lượng khi đặt trên mặt đất
    public float groundMassMultiplier = 1f;

    // Khối lượng của Item
    public float mass = 3f;

    // Vị trí cầm Item
    public Vector3 holdPos;

    // Sử dụng vị trí cầm thay thế
    public bool useAlternativeHoldingPos;

    // Vị trí cầm thay thế
    public Vector3 alternativeHoldPos;

    // Góc xoay khi cầm Item
    public Vector3 holdRotation;

    // Sử dụng góc xoay thay thế
    public bool useAlternativeHoldingRot;

    // Góc xoay thay thế
    public Vector3 alternativeHoldRot;

    // ID của Item
    public byte id;

    // ID duy trì của Item
    public string persistentID;

    // Xác định xem Item có thể mua được không
    public bool purchasable;

    // Danh mục của Item trong cửa hàng
    public ShopItemCategory Category;

    // Giá của Item
    public int price;

    // Số lượng Item
    public int quantity;

    // Thông tin về Emote
    public Emote emoteInfo;

    // Danh sách các tooltip của Item
    public List<ItemKeyTooltip> Tooltips = new List<ItemKeyTooltip>();

    // Tính toán độ hiếm của công cụ dựa trên độ hiếm khi spawn
    public float ToolRarity => toolSpawnRarity switch
    {
        Rarity.always => 1000f, 
        Rarity.superCommon => 2f, 
        Rarity.moreCommon => 1.25f, 
        Rarity.common => 1f, 
        Rarity.lessCommon => 0.75f, 
        Rarity.uncommon => 0.5f, 
        Rarity.rare => 0.1f, 
        Rarity.epic => 0.05f, 
        Rarity.legendary => 0.025f, 
        Rarity.mythic => 0.01f, 
        _ => throw new ArgumentOutOfRangeException(), 
    };

    // Thuộc tính để lấy và đặt PersistentID dưới dạng Guid
    public Guid PersistentID
    {
        get
        {
            if (Guid.TryParse(persistentID, out var result))
            {
                return result;
            }
            return Guid.Empty;
        }
        set
        {
            persistentID = value.ToString();
        }
    }

    // Kiểm tra xem có hiển thị thông tin Emote không
    private bool ShowEmoteInfo()
    {
        if (Category != ShopItemCategory.Emotes)
        {
            return Category == ShopItemCategory.Emotes2;
        }
        return true;
    }

    // Lệnh console để spawn một Item
    [ConsoleCommand]
    public static void SpawnItem(Item item)
    {
        Debug.Log("Spawn item: " + item.name);
        Vector3 debugItemSpawnPos = MainCamera.instance.GetDebugItemSpawnPos();
        Player.localPlayer.RequestCreatePickup(item, new ItemInstanceData(Guid.NewGuid()), debugItemSpawnPos, Quaternion.identity);
    }

    // Lệnh console để trang bị một Item
    [ConsoleCommand]
    public static void EquipItem(Item item)
    {
        Debug.Log("Equip item: " + item.name);
        Player.localPlayer.TryGetInventory(out var o);
        o.TryAddItem(new ItemDescriptor(item, new ItemInstanceData(Guid.NewGuid())));
    }

    // Lấy dữ liệu tooltip cho Item
    public IEnumerable<IHaveUIData> GetTootipData()
    {
        if (Tooltips.Count > 0)
        {
            string text = base.name.Trim().Replace(" ", "") + "_ToolTips";
            if (Enum.TryParse<LocalizationKeys.Keys>(text, out var result))
            {
                string[] array = LocalizationKeys.GetLocalizedString(result).Split(';');
                Tooltips = new List<ItemKeyTooltip>();
                string[] array2 = array;
                foreach (string key in array2)
                {
                    Tooltips.Add(new ItemKeyTooltip(key));
                }
            }
            else
            {
                Debug.LogError("Could not find LOC_Key: " + text);
            }
        }
        return Tooltips;
    }

    // Lấy tên hiển thị đã được địa phương hóa
    public string GetLocalizedDisplayName()
    {
        string text = base.name.Trim().Replace(" ", "");
        if (Enum.TryParse<LocalizationKeys.Keys>(text, out var result))
        {
            return LocalizationKeys.GetLocalizedString(result);
        }
        Debug.LogError("Failed to get Localized displayName for: " + text);
        return displayName;
    }
}