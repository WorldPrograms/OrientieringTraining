using CodeBase.Data.Slides;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public interface ISlideServise: IService
    {
        Transform Canvas { get; set; }

        Slide GetSlide(string name);
        SlideController InstantiateSlide(string name);
        SlideController InstantiateSlide(Slide slide);
        void RegisterSlide(string slideController, string name = null);
    }
}