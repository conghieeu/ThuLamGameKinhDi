public class Comment
{
	public int Likes;

	public string Text { get; set; }

	public float Time { get; set; }

	public byte Face { get; set; }

	public byte FaceColor { get; set; }

	public Comment(string text)
	{
		Text = text;
	}
}
