using System;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.CompetitorsServise;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Logic;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
  {
    private const string Initial = "Initial";
 

        private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;
        

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _services = services;

      RegisterServices(); 
    }

    public void Enter()
    {
      _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
    }

    public void Exit()
    {
    }

    private void RegisterServices()
    {
      _services.RegisterSingle<IAssetProvider>(new AssetProvider());
      _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
      _services.RegisterSingle<ICompetitorsServise>(new CompetitorsServise(new AgeGroupsAdder(_services.Single<IAssetProvider>())));
      _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));
      _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>(), _services.Single<IGameFactory>()));
      _services.RegisterSingle<ISlideServise>(new SlideServise(_services.Single<IAssetProvider>()));
      _services.RegisterSingle<ICompetitorAdderPanelServise>(new CompetitorAdderPanelServise(_services.Single<ISlideServise>()));

            RegisterSlides();
        }

        private void RegisterSlides()
        {
            _services.Single<ISlideServise>().RegisterSlide(SlidesConstants.AD_COMPETITOR_PANEL);
            _services.Single<ISlideServise>().RegisterSlide(SlidesConstants.ALL_USERS_SLIDE);
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadProgressState>();
  }
}