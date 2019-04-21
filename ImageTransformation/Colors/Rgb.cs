namespace ImageTransformation.Colors
{
	public class Rgb<TComponentType> where TComponentType : struct
    {
        public TComponentType Red { get; set; }

        public TComponentType Green { get; set; }

        public TComponentType Blue { get; set; }
    }
}
