namespace Game.Core
{
    using System;

    [Serializable]
    public class SaveGame
    {
        #region Field
        private Player player;
        private MapGenerator lastMapState;
        private Position playerPosition;
        private int lastWorld;
        private char prevMapElement;
        #endregion

        #region Constructors
        public SaveGame(Player player, MapGenerator lastMapState, Position playerPosition, int lastWorld, char prevMapElement)
        {
            this.Player = player;
            this.LastMapState = lastMapState;
            this.PlayerPosition = playerPosition;
            this.LastWorld = lastWorld;
            this.PrevMapElement = prevMapElement;
        }
        #endregion

        #region Properties
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public MapGenerator LastMapState
        {
            get { return lastMapState; }
            set { lastMapState = value; }
        }

        public Position PlayerPosition
        {
            get { return playerPosition; }
            set { playerPosition = value; }
        }

        public int LastWorld
        {
            get { return lastWorld; }
            set { lastWorld = value; }
        }

        public char PrevMapElement
        {
            get { return prevMapElement; }
            set { prevMapElement = value; }
        }
        #endregion
    }
}