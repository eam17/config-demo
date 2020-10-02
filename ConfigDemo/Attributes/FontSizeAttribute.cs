using System;
namespace AttributeDemo.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class FontSizeAttribute : Attribute
    {
        public float TextSize;

        public FontSizeAttribute(float textSize)
        {
            this.TextSize = textSize;
        }
    }
}
