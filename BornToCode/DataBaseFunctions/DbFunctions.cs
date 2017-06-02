namespace BornToCode.DataBaseFunctions
{
    public abstract class DbActions
    {
        protected BornToCodeContext context;

        public DbActions(BornToCodeContext context)
        {
            this.context = context;
        }

        public abstract void Seed();


        public abstract void DeleteAll();
    }
}