using FluentValidation;
using FluentValidation.Results;
using SmartMedChallenge.Application.Interfaces;
using SmartMedChallenge.Domain.Models;
using SmartMedChallenge.Domain.Notifications;

namespace SmartMedChallenge.Application.Services
{
    public class BaseService
    {
        private readonly INotificator _notificator;

        protected BaseService(INotificator notificator) =>
            _notificator = notificator;

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid)
                return true;

            Notify(validator);

            return false;
        }
    }
}
