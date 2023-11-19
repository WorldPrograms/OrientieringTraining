using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
  {
    private const string ProtocolParentTag = "ProtocolParent";
        private const string CanvasTag = "Canvas";

        private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _loadingCurtain;
    private readonly IGameFactory _gameFactory;
    private readonly IPersistentProgressService _progressService;
    private readonly ISlideServise _slideServise;
    private readonly ICompetitorAdderPanelServise _competitorAdderPanelServise;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory, IPersistentProgressService progressService, ISlideServise slideServise, ICompetitorAdderPanelServise competitorAdderPanelServise)
    {
      _stateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _loadingCurtain = loadingCurtain;
      _gameFactory = gameFactory;
      _progressService = progressService;
      _slideServise = slideServise;
            _competitorAdderPanelServise = competitorAdderPanelServise;
    }

    public void Enter(string sceneName)
    {
      _loadingCurtain.Show();
      _gameFactory.Cleanup();
      _sceneLoader.Load(sceneName, OnLoaded);
    }

    public void Exit() =>
      _loadingCurtain.Hide();

    private void OnLoaded()
    {
      InitGameWorld();
      InformProgressReaders();
      
      _stateMachine.Enter<GameLoopState>();
    }

    private void InformProgressReaders()
    {
      foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
        progressReader.LoadProgress(_progressService.Progress);
    }

    private void InitGameWorld()
    {
      
      _slideServise.Canvas = GameObject.FindGameObjectWithTag(CanvasTag).transform;
      _slideServise.InstantiateSlide(SlidesConstants.ALL_USERS_SLIDE);
      _competitorAdderPanelServise.InstantiatePanel();

       //_gameFactory.CreateProtocol(GameObject.FindWithTag(ProtocolParentTag));
       }
  }
}