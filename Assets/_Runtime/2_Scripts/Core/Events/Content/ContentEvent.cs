
// Lớp trừu tượng ContentEvent đại diện cho một sự kiện nội dung
public abstract class ContentEvent
{
    // Phương thức trừu tượng để lấy giá trị nội dung của sự kiện
    public abstract float GetContentValue();

    // Phương thức trừu tượng để lấy ID của sự kiện
    public abstract ushort GetID();

    // Phương thức trừu tượng để lấy tên của sự kiện
    public abstract string GetName();

    // Phương thức trừu tượng để tạo một đối tượng Comment cho sự kiện
    public abstract Comment GenerateComment();

    // Phương thức ảo để lấy ID duy nhất của sự kiện, mặc định trả về 0
    public virtual int GetUniqueID()
    {
        return 0;
    }
}