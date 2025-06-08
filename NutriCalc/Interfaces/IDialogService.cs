using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriCalc.Interfaces
{
    public interface IDialogService
    {
        Task<string> ShowActionsAsync(string title, string message, string destruction, params string[] buttons);
        Task<bool> ShowAlertAsync(string title, string message, string accept, string cancel);
        Task<bool> ShowConfirmationAsync(string title, string message);
    }
}
