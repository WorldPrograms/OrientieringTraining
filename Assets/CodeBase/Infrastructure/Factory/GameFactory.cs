using System;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.CompetitorsServise;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private ICompetitorsServise _competitorsServise;
        private IAgeGroupsAdder _ageGroupsAdder;

        public event Action ProtocolCreated;

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        //public GameObject ProtocolGameObject { get; private set; }

        public GameFactory(IAssetProvider assets, ICompetitorsServise competitorsServise, IAgeGroupsAdder ageGroupsAdder)
        {
            _assets = assets;
            _competitorsServise = competitorsServise;
            _ageGroupsAdder = ageGroupsAdder;
        }

        public void CreateProtocol(GameObject at)
        {

            _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Mark", gender: Gender.Male, group: AgeGroupExample.OG.ToString()));
            _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Ivananina", gender: Gender.Female, AgeGroupExample.OG.ToString()));

            _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Masha", gender: Gender.Female, group: AgeGroupExample.G10.ToString()));
            _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Misha", gender: Gender.Male, group: AgeGroupExample.G10.ToString()));
            _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Кабачок", gender: Gender.Male, group: AgeGroupExample.G16.ToString()));
            _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Savostina", gender: Gender.Male, group: AgeGroupExample.G16.ToString()));
            _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Ярослав", lastName: "Грязин", gender: Gender.Male, group: AgeGroupExample.G16.ToString()));

            _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Svetka", gender: Gender.Female, group: "GChemp"));
            _competitorsServise.GameCompetitors.AdCompetitor(new Competitor("Ania", gender: Gender.Female, group: "GChemp"));

            foreach (var group in _competitorsServise.GameCompetitors.AllGroups)
            {
                _ageGroupsAdder.InstantiateGroup(group, at.transform);
            }

            //GameObject protocol = InstantiateRegistered(AssetPath.HeroPat, at.transform.position);
            //ProtocolGameObject = protocol;
            ProtocolCreated?.Invoke();
            //return protocol;
        }

        public void CreateHud() =>
            InstantiateRegistered(AssetPath.HudPath);

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);

            RegisterProgressWatchers(gameObject);
            return gameObject;
        } 
    
        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(path: prefabPath);

            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
      
            ProgressReaders.Add(progressReader);
        }
    }
}