namespace CodeBase.Data.Slides
{
    public class Slide
    {
        public Slide(string slideController, string name = null)
        {
            if (name == null)
                Name = slideController;
            else
                Name = name;
            SlideObject = slideController;
        }

        public string Name;
        public string SlideObject;
    }
}