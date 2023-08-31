using Discord;
using Discord.Interactions;

namespace RLLBot.Attributes
{
    public class DoFileExtensionCheck : ParameterPreconditionAttribute
    {
        private readonly string _fileExtension;

        public DoFileExtensionCheck(string requiredFileExtension)
        {
            _fileExtension = requiredFileExtension;
        }

        public override Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, IParameterInfo commandInfo, object obj, IServiceProvider services)
        {
            if(obj.ToString() is null)
                return Task.FromResult(PreconditionResult.FromError("Parameter is null."));

            var fileExtension = System.IO.Path.GetExtension(obj.ToString());

            return fileExtension == _fileExtension ? 
                Task.FromResult(PreconditionResult.FromSuccess()) : 
                Task.FromResult(PreconditionResult.FromError($"File extension does not match {_fileExtension}."));
        }
    }
}
