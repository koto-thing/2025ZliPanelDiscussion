namespace OSCSample
{
    public class OSCSampleStateModel
    {
        private OSCSampleState state = OSCSampleState.WAITFORSTART;
        
        public OSCSampleState State { get => state; set => state = value; }
    }
    
    public enum OSCSampleState
    {
        TUTORIAL,
        WAITFORSTART,
        RECORDING,
        ANIMATION,
        GAMEOVER
    }
}