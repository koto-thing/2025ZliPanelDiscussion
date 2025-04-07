namespace OSCSample
{
    public class OSCSampleStateModel
    {
        private OSCSampleState state;
        
        public OSCSampleState State { get => state; set => state = value; }
    }
    
    public enum OSCSampleState
    {
        TUTORIAL,
        RECORDING,
        GAMEPLAY,
        GAMEOVER
    }
}