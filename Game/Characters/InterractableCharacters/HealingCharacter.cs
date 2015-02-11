namespace Game.Characters.InterractableCharacters
{
    using Game.Characters.Interfaces;

    class HealingCharacter : InterractableCharacter, IHeal
    {
        private int healingPoints;

        public int HealingPoints
        { 
            get
            {
                return this.healingPoints;
            }

            set
            {
                this.healingPoints = this.UpdatePoints(value);
            }
        }


    }
}
