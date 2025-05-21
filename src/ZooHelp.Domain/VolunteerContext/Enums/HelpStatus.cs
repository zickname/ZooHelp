namespace ZooHelp.Domain.VolunteerContext;

public enum HelpStatus
{
    /// <summary>
    /// Нуждается в помощи
    /// </summary>
    NeedHelp = 0,

    /// <summary>
    ///Ищет дом
    /// </summary>
    LookingHome = 1,

    /// <summary>
    /// Нашел дом
    /// </summary>
    FoundHome = 2
}