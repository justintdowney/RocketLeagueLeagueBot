using RLLBot.DAL;
using RLLBot.DAL.Models;

namespace RLLBot.Api
{
    public interface IReplayParser
    {
        // Input - Accepts .replay file downloaded from discord attachment URL.
        // Output - Information related to the parsed replay in the form of our Domain objects
        // Notes - Would like to have a local/web parser abstracted behind this interface
        // Ideally would like to have this interchangeable through the configuration settings
        Task ParseReplay();
    }
}
