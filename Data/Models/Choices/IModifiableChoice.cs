namespace Data.Models.Choices
{
    public interface IModifiableChoice : IChoice
    {
        void AddChoiceOption(IChoiceOption option);
    }
}
