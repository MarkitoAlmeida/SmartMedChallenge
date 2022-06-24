using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SmartMedChallenge.Application.Interfaces;
using SmartMedChallenge.Domain.Notifications;
using System.Linq;

namespace SmartMedChallenge.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        #region Properties

        private readonly INotificator _notificator;

        #endregion

        #region Constructor

        protected BaseController() { }

        protected BaseController(INotificator notificator) =>
            _notificator = notificator;

        #endregion

        #region Methods

        protected bool ValidOperatation()
        {
            return !_notificator.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperatation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }
            else if (!ValidOperatation() && result is not null)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _notificator.GetNotifications().Select(n => n.Message),
                    data = result
                });
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _notificator.GetNotifications().Select(n => n.Message)
                });
            }
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                NotifyErrorInvalidModel(modelState);

            return CustomResponse();
        }

        protected void NotifyErrorInvalidModel(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string message)
        {
            _notificator.Handle(new Notification(message));
        }
    }

    #endregion
}
