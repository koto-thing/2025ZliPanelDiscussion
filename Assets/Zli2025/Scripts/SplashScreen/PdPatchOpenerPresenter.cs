using System;
using VContainer.Unity;

namespace SplashScreen
{
    public class PdPatchOpenerPresenter : IInitializable, IDisposable
    {
        private PdPatchOpenerModel model;

        public PdPatchOpenerPresenter(PdPatchOpenerModel model)
        {
            this.model = model;
        }

        public void Initialize()
        {
            model.SetProcessInfo();
        }

        public void Dispose()
        {
            
        }
    }
}