namespace KirillQuestion.Implementations
{
    public class Warturtle : InsertSpacesFixture 
    {
        public override string InsertSpaceBetweenCrLfs(string input)
        {
            return FS.warturtle.fix(input);
        }
    }
}
