using System.Collections.Generic;
using CodeBase.Data.Slides;
using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class SlideServise : ISlideServise
    {
        public SlideServise(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        private IAssetProvider _assetProvider;

        private List<Slide> _slides = new List<Slide>();

        public Transform Canvas { get; set; }

        public void RegisterSlide(string slideController, string name = null) =>
            _slides.Add(new Slide(slideController, name));

        public Slide GetSlide(string name)
        {
            foreach (var slide in _slides)
            {
                if (slide.Name == name)
                    return slide;
            }
            return null;
        }

        public SlideController InstantiateSlide(string name)
        {
            Slide slide = GetSlide(name);
            return _assetProvider.Instantiate(slide.SlideObject, Canvas).GetComponent<SlideController>();
        }

        public SlideController InstantiateSlide(Slide slide) =>
            InstantiateSlide(slide.Name);
    }
}