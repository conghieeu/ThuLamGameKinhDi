
public class PropContentEvent : ContentEvent
{
	public PropContent content;

    public override Comment GenerateComment()
    {
        throw new System.NotImplementedException();
    }

    public override float GetContentValue()
	{
		return content.contentValue;
	}

	public override ushort GetID()
	{
		return content.id;
	}

	public override string GetName()
	{
		return content.name;
	} 

	public override int GetUniqueID()
	{
		return 0;
	} 
}
