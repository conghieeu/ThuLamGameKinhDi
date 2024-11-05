using System;

// [Serializable] là một thuộc tính (attribute) trong C# cho phép đối tượng của lớp này có thể được tuần tự hóa (serialize).
[Serializable]
public class ItemKeyTooltip : IHaveUIData
{
    // Biến thành viên m_key lưu trữ một chuỗi (string) đại diện cho khóa của mục.
    public string m_key;

    // Hàm khởi tạo (constructor) nhận một tham số kiểu string và gán giá trị của nó cho biến m_key.
    public ItemKeyTooltip(string key)
    {
        m_key = key;
    }

    // Phương thức GetString() trả về giá trị của biến m_key.
    public string GetString()
    {
        return m_key;
    }
}