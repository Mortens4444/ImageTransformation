namespace ImageTransformation.Colors
{
	public class Argb<TComponentType> : Rgb<TComponentType> where TComponentType : struct
	{
		protected TComponentType Alpha { get; set; }
	}
}