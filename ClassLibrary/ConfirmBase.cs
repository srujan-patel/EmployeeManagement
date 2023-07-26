using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }


        [Parameter]
        public string ConfirmationTitle { get; set; } = "DeleteConfiramtion";


        [Parameter]
        public string ConfirmationMessage { get; set; } = "Are you sure you want to delete?";

        public void Show()
        {

            ShowConfirmation = true;
            StateHasChanged();
        }


        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }


        protected async Task OnConfirmationChanged(bool value)
        {
            ShowConfirmation=false;
            await ConfirmationChanged.InvokeAsync(value);

        }
    }
}
