namespace AutomationPractice.Tests.Drivers
{
    public class ElementParameters
    {
        public ElementParameters(System.Drawing.Size elementSize, System.Drawing.Point elementLocation)
        {
            Size = elementSize;
            Location = elementLocation;
        }

        public System.Drawing.Size Size { get; private set; }

        public System.Drawing.Point Location { get; private set; }
    }
}