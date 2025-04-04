using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Title
{
    public class TitleLifetimeScope : LifetimeScope
    {
        [Header("依存関係")] 
        [SerializeField] private TitleButtonsView view;
    
        protected override void Configure(IContainerBuilder builder)
        {
        
        }
    }
}